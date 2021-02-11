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

        public IAggregatedDataRequest AggregatedData
        {
            get
            {
                return new AggregatedDataRequest(this.BaseUrl + "/commons/data/multi_read", this);
            }
        }

        public IDataDictionaryCollectionRequestBuilder DataDictionary
        {
            get
            {
                return new DataDictionaryCollectionRequestBuilder(this.BaseUrl + "/commons/data_dictionary/data_elements", this);
            }
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

        public IPayCodesRequestBuilder PayCodes
        {
            get
            {
                return new PayCodesRequestBuilder(this.BaseUrl + "/timekeeping/setup", this);
            }
        }

        public ITimecardsRequestBuilder Timecards
        {
            get
            {
                return new TimecardsRequestBuilder(this.BaseUrl + "/timekeeping", this);
            }
        }


        public ITimezonesCollectionRequestBuilder Timezones
        {
            get
            {
                return new TimezonesCollectionRequestBuilder(this.BaseUrl + "/commons/setup/timezones", this);
            }
        }

        public ISchedulesRequestBuilder Schedules
        {
            get
            {
                return new SchedulesRequestBuilder(this.BaseUrl + "/scheduling", this);

            }
        }
    }

    public interface IWorkforceDimensionsClient
    {
        IAggregatedDataRequest AggregatedData { get; }

        IDataDictionaryCollectionRequestBuilder DataDictionary { get; }

        IHyperfindQueriesCollectionRequestBuilder HyperfindQueries { get; }

        ILocationsCollectionRequestBuilder Locations { get; }

        IPayCodesRequestBuilder PayCodes { get; }

        ITimecardsRequestBuilder Timecards { get; }


        ITimezonesCollectionRequestBuilder Timezones { get; }

        ISchedulesRequestBuilder Schedules { get; }

    }
}
