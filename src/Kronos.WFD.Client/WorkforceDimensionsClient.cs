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
        /// <param name="tenantName">The base service URL. For example, "https://graph.microsoft.com/v1.0".</param>
        /// <param name="authenticationProvider">The <see cref="IAuthenticationProvider"/> for authenticating request messages.</param>
        /// <param name="httpProvider">The <see cref="IHttpProvider"/> for sending requests.</param>
        public WorkforceDimensionsClient(
            string tenantName,
            IAuthenticationProvider authenticationProvider,
            ApiVersion apiVersion = ApiVersion.v1,
            IHttpProvider httpProvider = null)
            : base(tenantName, authenticationProvider, apiVersion, httpProvider)
        {
        }

        /// <summary>
        /// Instantiates a new GraphServiceClient.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> to use for making requests to Microsoft Graph. Use the <see cref="GraphClientFactory"/>
        /// to get a pre-configured HttpClient that is optimized for use with the Microsoft Graph service API. </param>
        public WorkforceDimensionsClient(
            string tenantName,
            HttpClient httpClient,
            ApiVersion apiVersion = ApiVersion.v1)
            : base(tenantName, httpClient, apiVersion)
        {
        }

        public IHyperfindQueriesCollectionRequestBuilder HyperfindQueries
        {
            get
            {
                return new HyperfindQueriesCollectionRequestBuilder(this.BaseUrl + "/commons/hyperfind", this);
            }
        }

        public ILocationsCollectionRequestBuilder Locations
        {
            get
            {
                return new LocationsCollectionRequestBuilder(this.BaseUrl + "/commons/locations", this);
            }
        }

        public ITimecardsRequestBuilder Timecards
        {
            get
            {
                return new TimecardsRequestBuilder(this.BaseUrl + "/timekeeping/timecard/multi_read", this);
            }
        }
    }

    public interface IWorkforceDimensionsClient
    {
        IHyperfindQueriesCollectionRequestBuilder HyperfindQueries { get; }

        ILocationsCollectionRequestBuilder Locations { get; }

        ITimecardsRequestBuilder Timecards { get; }
    }
}
