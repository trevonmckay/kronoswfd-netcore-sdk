using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kronos.WFD.Client.Requests
{
    internal class AggregatedDataRequest : BaseRequest, IAggregatedDataRequest
    {
        public AggregatedDataRequestParameters Parameters { get; private set; }

        public AggregatedDataRequest(string requestUrl, IBaseClient client, IEnumerable<Option> options = null)
            : base(requestUrl, client, options)
        {
            Parameters = new AggregatedDataRequestParameters();
        }

        public IAggregatedDataRequest Count(int count)
        {
            Parameters.Count = count;
            return this;
        }

        public IAggregatedDataRequest From(AggregatedDataRequestFromParameters from)
        {
            Parameters.From = from;
            return this;
        }

        public IAggregatedDataRequest Select(IEnumerable<AggregatedDataRequestSelectParameter> select)
        {
            Parameters.Select = select;
            return this;
        }

        public IAggregatedDataRequest Where(IEnumerable<AggregatedDataRequestWhereParameters> where)
        {
            Parameters.Where = where;
            return this;
        }

        public IAggregatedDataRequest Page(int index)
        {
            Parameters.Index = index;
            return this;
        }

        public async Task<AggregatedDataPage> PostAsync(CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "POST";

            if (Parameters.Options == null)
            {
                Parameters.Options = new AggregatedDataRequestOptions
                {
                    RequestTag = "request",
                    SecondaryRequestTag = "subrequest1",
                };
            }

            var response = await this.SendAsync<AggregatedDataResponse>(Parameters, cancellationToken).ConfigureAwait(false);
            if (response != null && response.Value != null)
            {
                if (response.AdditionalData != null)
                {
                    response.AdditionalData.TryGetValue("@odata.nextLink", out object nextPageLink);

                    var nextPageLinkString = nextPageLink as string;
                    if (!string.IsNullOrEmpty(nextPageLinkString))
                    {
                        response.Value.InitializeNextPageRequest(
                            this.Client,
                            nextPageLinkString);
                    }

                    response.Value.AdditionalData = response.AdditionalData;
                }

                return response.Value;
            }

            return null;
        }

        public async Task<AggregatedDataPage> PostAsync()
        {
            return await PostAsync(CancellationToken.None);
        }
    }

    public interface IAggregatedDataRequest
    {
        IAggregatedDataRequest Count(int count);

        IAggregatedDataRequest From(AggregatedDataRequestFromParameters from);

        IAggregatedDataRequest Select(IEnumerable<AggregatedDataRequestSelectParameter> select);

        IAggregatedDataRequest Where(IEnumerable<AggregatedDataRequestWhereParameters> where);

        IAggregatedDataRequest Page(int index);

        Task<AggregatedDataPage> PostAsync(CancellationToken cancellationToken);

        Task<AggregatedDataPage> PostAsync();
    }
}
