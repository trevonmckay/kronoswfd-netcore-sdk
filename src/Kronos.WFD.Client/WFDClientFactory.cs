using Kronos.WFD.Authentication;
using Kronos.WFD.Client.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;

namespace Kronos.WFD.Client
{
    class WFDClientFactory
    {
        /// The key for the SDK version header.
        private static readonly string SdkVersionHeaderName = CoreConstants.Headers.SdkVersionHeaderName;

        /// The version for current assembly.
        private static Version assemblyVersion = typeof(WFDClientFactory).GetTypeInfo().Assembly.GetName().Version;

        /// The value for the SDK version header.
        private static string SdkVersionHeaderValue = string.Format(
                    CoreConstants.Headers.SdkVersionHeaderValueFormatString,
                    "Graph",
                    assemblyVersion.Major,
                    assemblyVersion.Minor,
                    assemblyVersion.Build);

        /// The default value for the overall request timeout.
        private static readonly TimeSpan defaultTimeout = TimeSpan.FromSeconds(100);

        /// <summary>
        /// Creates a new <see cref="HttpClient"/> instance configured with the handlers provided.
        /// </summary>
        /// <param name="authenticationProvider">The <see cref="IAuthenticationProvider"/> to authenticate requests.</param>
        /// <param name="version">The graph version to use.</param>
        /// <param name="tenantName">The national cloud endpoint to use.</param>
        /// <param name="proxy">The proxy to be used with created client.</param>
        /// <param name="finalHandler">The last HttpMessageHandler to HTTP calls.
        /// The default implementation creates a new instance of <see cref="HttpClientHandler"/> for each HttpClient.</param>
        /// <returns></returns>
        public static HttpClient Create(
            IAuthenticationProvider authenticationProvider,
            string tenantName,
            string version = "v1",
            IWebProxy proxy = null,
            HttpMessageHandler finalHandler = null)
        {
            IList<DelegatingHandler> handlers = CreateDefaultHandlers(authenticationProvider);
            return Create(handlers, tenantName, version, proxy, finalHandler);
        }

        /// <summary>
        /// Creates a new <see cref="HttpClient"/> instance configured with the handlers provided.
        /// </summary>
        /// <param name="version">The graph version to use.</param>
        /// <param name="tenantName">The national cloud endpoint to use.</param>
        /// <param name="handlers">An ordered list of <see cref="DelegatingHandler"/> instances to be invoked as an
        /// <see cref="HttpRequestMessage"/> travels from the <see cref="HttpClient"/> to the network and an
        /// <see cref="HttpResponseMessage"/> travels from the network back to <see cref="HttpClient"/>.
        /// The handlers are invoked in a top-down fashion. That is, the first entry is invoked first for
        /// an outbound request message but last for an inbound response message.</param>
        /// <param name="proxy">The proxy to be used with created client.</param>
        /// <param name="finalHandler">The last HttpMessageHandler to HTTP calls.</param>
        /// <returns>An <see cref="HttpClient"/> instance with the configured handlers.</returns>
        public static HttpClient Create(
            IEnumerable<DelegatingHandler> handlers,
            string tenantName,
            string version = "v1",
            IWebProxy proxy = null,
            HttpMessageHandler finalHandler = null)
        {
            if (finalHandler == null)
            {
                finalHandler = GetNativePlatformHttpHandler(proxy);
            }
            else if ((finalHandler is HttpClientHandler) && (finalHandler as HttpClientHandler).Proxy == null && proxy != null)
            {
                (finalHandler as HttpClientHandler).Proxy = proxy;
            }
            else if ((finalHandler is HttpClientHandler) && (finalHandler as HttpClientHandler).Proxy != null && proxy != null)
            {
                throw new ArgumentException(ErrorConstants.Messages.InvalidProxyArgument);
            }

            var pipeline = CreatePipeline(handlers, finalHandler);
            HttpClient client = new HttpClient(pipeline);
            client.DefaultRequestHeaders.Add(SdkVersionHeaderName, SdkVersionHeaderValue);
            client.Timeout = defaultTimeout;
            client.BaseAddress = DetermineBaseAddress(tenantName, version);
            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true, NoStore = true };
            return client;
        }

        /// <summary>
        /// Create a default set of middleware for calling Microsoft Graph
        /// </summary>
        /// <param name="authenticationProvider">The <see cref="IAuthenticationProvider"/> to authenticate requests.</param>
        /// <returns></returns>
        public static IList<DelegatingHandler> CreateDefaultHandlers(IAuthenticationProvider authenticationProvider)
        {
            return new List<DelegatingHandler> {
                new AuthenticationHandler(authenticationProvider),
                new CompressionHandler(),
                new RetryHandler(),
                new RedirectHandler()
            };
        }

        /// <summary>
        /// Creates an instance of an <see cref="HttpMessageHandler"/> using the <see cref="DelegatingHandler"/> instances
        /// provided by <paramref name="handlers"/>. The resulting pipeline can be used to manually create <see cref="HttpClient"/>
        /// or <see cref="HttpMessageInvoker"/> instances with customized message handlers.
        /// </summary>
        /// <param name="finalHandler">The inner handler represents the destination of the HTTP message channel.</param>
        /// <param name="handlers">An ordered list of <see cref="DelegatingHandler"/> instances to be invoked as part
        /// of sending an <see cref="HttpRequestMessage"/> and receiving an <see cref="HttpResponseMessage"/>.
        /// The handlers are invoked in a top-down fashion. That is, the first entry is invoked first for
        /// an outbound request message but last for an inbound response message.</param>
        /// <returns>The HTTP message channel.</returns>
        public static HttpMessageHandler CreatePipeline(IEnumerable<DelegatingHandler> handlers, HttpMessageHandler finalHandler = null)
        {
            if (finalHandler == null)
            {
                finalHandler = GetNativePlatformHttpHandler();
            }

            if (handlers == null)
            {
                return finalHandler;
            }

            HttpMessageHandler httpPipeline = finalHandler;
            IEnumerable<DelegatingHandler> reversedHandlers = handlers.Reverse();
            HashSet<Type> existingHandlerTypes = new HashSet<Type>();
            foreach (DelegatingHandler handler in reversedHandlers)
            {
                if (handler == null)
                {
                    throw new ArgumentNullException(nameof(handlers), "DelegatingHandler array contains null item.");
                }

                #if iOS
                // Skip CompressionHandler since NSUrlSessionHandler automatically handles decompression on iOS and it can't be turned off.
                // See issue https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues/481 for more details.
                if (finalHandler.GetType().Equals(typeof(NSUrlSessionHandler)) && handler.GetType().Equals(typeof(CompressionHandler)))
                {
                    // Skip chaining of CompressionHandler.
                    continue;
                }
                #endif

                // Check for duplicate handler by type.
                if (!existingHandlerTypes.Add(handler.GetType()))
                {
                    throw new ArgumentException($"DelegatingHandler array has a duplicate handler. {handler} has a duplicate handler.", "handlers");
                }

                // Existing InnerHandlers on handlers will be overwritten
                handler.InnerHandler = httpPipeline;
                httpPipeline = handler;
            }

            return httpPipeline;
        }

        /// <summary>
        /// Gets a platform's native http handler i.e. NSUrlSessionHandler for Xamarin.iOS, AndroidClientHandler for Xamarin.Android and HttpClientHandler for others.
        /// </summary>
        /// <param name="proxy">The proxy to be used with created client.</param>
        /// <returns>
        /// 1. NSUrlSessionHandler for Xamarin.iOS 
        /// 2. AndroidClientHandler for Xamarin.Android.
        /// 3. HttpClientHandler for other platforms.
        /// </returns>
        internal static HttpMessageHandler GetNativePlatformHttpHandler(IWebProxy proxy = null)
        {
            #if iOS
            return new NSUrlSessionHandler { AllowAutoRedirect = false };
            #elif ANDROID
            return new Xamarin.Android.Net.AndroidClientHandler { Proxy = proxy, AllowAutoRedirect = false, AutomaticDecompression = DecompressionMethods.None };
            #else
            return new HttpClientHandler { Proxy = proxy, AllowAutoRedirect = false, AutomaticDecompression = DecompressionMethods.None };
            #endif
        }

        private static Uri DetermineBaseAddress(string hostName, string version)
        {
            string cloudAddress = $"https://{hostName}.mykronos.com/api/{version}/";
            return new Uri(cloudAddress);

        }
    }
}
