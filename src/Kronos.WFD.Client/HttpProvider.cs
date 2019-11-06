using Kronos.WFD.Client.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Kronos.WFD.Client
{
    public class HttpProvider : IHttpProvider
    {
        internal bool disposeHandler;

        internal HttpClient httpClient;

        internal HttpMessageHandler httpMessageHandler;

        /// <summary>
        /// Constructs a new <see cref="HttpProvider"/>.
        /// </summary>
        /// <param name="serializer">A serializer for serializing and deserializing JSON objects.</param>
        public HttpProvider(string tenantName, ISerializer serializer = null)
            : this(tenantName, (HttpMessageHandler)null, true, serializer)
        {
        }

        /// <summary>
        /// Constructs a new <see cref="HttpProvider"/>.
        /// </summary>
        /// <param name="httpClientHandler">An HTTP client handler to pass to the <see cref="HttpClient"/> for sending requests.</param>
        /// <param name="disposeHandler">Whether or not to dispose the client handler on Dispose().</param>
        /// <param name="serializer">A serializer for serializing and deserializing JSON objects.</param>
        /// <remarks>
        ///     By default, HttpProvider disables automatic redirects and handles redirects to preserve authentication headers. If providing
        ///     an <see cref="HttpClientHandler"/> to the constructor and enabling automatic redirects this could cause issues with authentication
        ///     over the redirect.
        /// </remarks>
        public HttpProvider(string tenantName, HttpClientHandler httpClientHandler, bool disposeHandler, ISerializer serializer = null)
            : this(tenantName, (HttpMessageHandler)httpClientHandler, disposeHandler, serializer)
        {
        }

        /// <summary>
        /// Constructs a new <see cref="HttpProvider"/>.
        /// </summary>
        /// <param name="httpMessageHandler">An HTTP message handler to pass to the <see cref="HttpClient"/> for sending requests.</param>
        /// <param name="disposeHandler">Whether or not to dispose the client handler on Dispose().</param>
        /// <param name="serializer">A serializer for serializing and deserializing JSON objects.</param>
        public HttpProvider(string tenantName, HttpMessageHandler httpMessageHandler, bool disposeHandler, ISerializer serializer)
        {
            this.disposeHandler = disposeHandler;
            this.httpMessageHandler = httpMessageHandler;
            this.Serializer = serializer ?? new Serializer();

            // NOTE: Override our pipeline when a httpMessageHandler is provided - httpMessageHandler can implement custom pipeline.
            // This check won't be needed once we re-write the HttpProvider to work with GraphClientFactory.
            if (this.httpMessageHandler == null)
            {
                this.httpMessageHandler = WFDClientFactory.GetNativePlatformHttpHandler();
                this.httpClient = WFDClientFactory.Create(authenticationProvider: null, tenantName: tenantName, version: "v1", finalHandler: this.httpMessageHandler);
            }
            else
            {
                this.httpClient = new HttpClient(this.httpMessageHandler, this.disposeHandler);
            }
        }

        /// <summary>
        /// Gets or sets the cache control header for requests;
        /// </summary>
        public CacheControlHeaderValue CacheControlHeader
        {
            get
            {
                return this.httpClient.DefaultRequestHeaders.CacheControl;
            }

            set
            {
                this.httpClient.DefaultRequestHeaders.CacheControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the overall request timeout.
        /// </summary>
        public TimeSpan OverallTimeout
        {
            get
            {
                return this.httpClient.Timeout;
            }

            set
            {
                try
                {
                    this.httpClient.Timeout = value;
                }
                catch (InvalidOperationException exception)
                {
                    throw new ServiceException(
                        new Error
                        {
                            Code = ErrorConstants.Codes.NotAllowed,
                            Message = ErrorConstants.Messages.OverallTimeoutCannotBeSet,
                        },
                        exception);
                }
            }
        }

        /// <summary>
        /// Gets a serializer for serializing and deserializing JSON objects.
        /// </summary>
        public ISerializer Serializer { get; private set; }

        /// <summary>
        /// Disposes the HttpClient and HttpClientHandler instances.
        /// </summary>
        public void Dispose()
        {
            if (this.httpClient != null)
            {
                this.httpClient.Dispose();
            }
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to send.</param>
        /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return this.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to send.</param>
        /// <param name="completionOption">The <see cref="HttpCompletionOption"/> to pass to the <see cref="IHttpProvider"/> on send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
        public async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken)
        {
            var response = await this.SendRequestAsync(request, completionOption, cancellationToken).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                using (response)
                {
                    if (null != response.Content)
                    {
                        await response.Content.LoadIntoBufferAsync().ConfigureAwait(false);
                    }

                    var errorResponse = await this.ConvertErrorResponseAsync(response).ConfigureAwait(false);
                    Error error = null;

                    if (errorResponse == null || errorResponse.Error == null)
                    {
                        if (response != null && response.StatusCode == HttpStatusCode.NotFound)
                        {
                            error = new Error { Code = ErrorConstants.Codes.ItemNotFound };
                        }
                        else
                        {
                            error = new Error
                            {
                                Code = ErrorConstants.Codes.GeneralException,
                                Message = ErrorConstants.Messages.UnexpectedExceptionResponse,
                            };
                        }
                    }
                    else
                    {
                        error = errorResponse.Error;
                    }

                    if (string.IsNullOrEmpty(error.ThrowSite))
                    {
                        IEnumerable<string> throwsiteValues;

                        if (response.Headers.TryGetValues(CoreConstants.Headers.ThrowSiteHeaderName, out throwsiteValues))
                        {
                            error.ThrowSite = throwsiteValues.FirstOrDefault();
                        }
                    }

                    if (string.IsNullOrEmpty(error.ClientRequestId))
                    {
                        IEnumerable<string> clientRequestId;

                        if (response.Headers.TryGetValues(CoreConstants.Headers.ClientRequestId, out clientRequestId))
                        {
                            error.ClientRequestId = clientRequestId.FirstOrDefault();
                        }
                    }

                    if (response.Content?.Headers.ContentType.MediaType == "application/json")
                    {
                        string rawResponseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        throw new ServiceException(error,
                                                   response.Headers,
                                                   response.StatusCode,
                                                   rawResponseBody);
                    }
                    else
                    {
                        // Pass through the response headers and status code to the ServiceException.
                        // System.Net.HttpStatusCode does not support RFC 6585, Additional HTTP Status Codes.
                        // Throttling status code 429 is in RFC 6586. The status code 429 will be passed through.
                        throw new ServiceException(error, response.Headers, response.StatusCode);
                    }
                }
            }

            return response;
        }

        internal async Task<HttpResponseMessage> SendRequestAsync(
            HttpRequestMessage request,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken)
        {
            try
            {
                return await this.httpClient.SendAsync(request, completionOption, cancellationToken).ConfigureAwait(false);
            }
            catch (TaskCanceledException exception)
            {
                throw new ServiceException(
                        new Error
                        {
                            Code = ErrorConstants.Codes.Timeout,
                            Message = ErrorConstants.Messages.RequestTimedOut,
                        },
                        exception);
            }
            catch (ServiceException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw new ServiceException(
                        new Error
                        {
                            Code = ErrorConstants.Codes.GeneralException,
                            Message = ErrorConstants.Messages.UnexpectedExceptionOnSend,
                        },
                        exception);
            }
        }

        /// <summary>
        /// Converts the <see cref="HttpRequestException"/> into an <see cref="ErrorResponse"/> object;
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/> to convert.</param>
        /// <returns>The <see cref="ErrorResponse"/> object.</returns>
        private async Task<ErrorResponse> ConvertErrorResponseAsync(HttpResponseMessage response)
        {
            try
            {
                var errorResponse = new ErrorResponse
                {
                    AdditionalData = new Dictionary<string, object>
                    {
                        { "statusCode", response.StatusCode },
                    }
                };

                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    errorResponse.Error = this.Serializer.DeserializeObject<Error>(responseStream);
                }

                return errorResponse;
            }
            catch (Exception)
            {
                // If there's an exception deserializing the error response return null and throw a generic
                // ServiceException later.
                return null;
            }
        }
    }

    public interface IHttpProvider : IDisposable
    {
        /// <summary>
        /// Gets a serializer for serializing and deserializing JSON objects.
        /// </summary>
        ISerializer Serializer { get; }

        /// <summary>
        /// Gets or sets the timeout interval. The default value is 100 seconds.
        /// </summary>
        TimeSpan OverallTimeout { get; set; }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to send.</param>
        /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to send.</param>
        /// <param name="completionOption">The <see cref="HttpCompletionOption"/> to pass to the <see cref="IHttpProvider"/> on send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
        Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken);
    }
}
