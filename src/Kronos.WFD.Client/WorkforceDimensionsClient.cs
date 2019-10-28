using Kronos.WFD.Authentication;
using Kronos.WFD.Client.Requests;
using System.Net.Http;

namespace Kronos.WFD.Client
{
    public class WorkforceDimensionsClient : BaseClient, IWorkforceDimensionsClient
    {
        /// <summary>
        /// Instantiates a new GraphServiceClient.
        /// </summary>
        /// <param name="baseUrl">The base service URL. For example, "https://graph.microsoft.com/v1.0".</param>
        /// <param name="authenticationProvider">The <see cref="IAuthenticationProvider"/> for authenticating request messages.</param>
        /// <param name="httpProvider">The <see cref="IHttpProvider"/> for sending requests.</param>
        public WorkforceDimensionsClient(
            string baseUrl,
            IAuthenticationProvider authenticationProvider,
            IHttpProvider httpProvider = null)
            : base(baseUrl, authenticationProvider, httpProvider)
        {
        }

        /// <summary>
        /// Instantiates a new GraphServiceClient.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> to use for making requests to Microsoft Graph. Use the <see cref="GraphClientFactory"/>
        /// to get a pre-configured HttpClient that is optimized for use with the Microsoft Graph service API. </param>
        public WorkforceDimensionsClient(
            string instanceUrl,
            HttpClient httpClient)
            : base(instanceUrl, httpClient)
        {
        }

        public IHyperfindQueryRequestBuilder HyperfindQueries
        {
            get
            {
                return new HyperfindQueryRequestBuilder(this.BaseUrl + "/commons", this);
            }
        }
    }

    public interface IWorkforceDimensionsClient
    {

    }
}
