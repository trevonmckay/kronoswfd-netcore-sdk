using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kronos.WFD.Client.Requests
{
    class HyperfindQueriesCollectionRequest : BaseRequest, IHyperfindQueriesCollectionRequest
    {
        public HyperfindQueriesCollectionRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base (requestUrl, client, options)
        {

        }

        public async Task<IHyperfindQueriesCollectionPage> GetAsync(CancellationToken cancellationToken)
        {
            this.Method = "GET";
            var response = await this.SendAsync<HyperfindQueriesCollectionResponse>(null, cancellationToken).ConfigureAwait(false);
            if (response != null && response.Value != null && response.Value.CurrentPage != null)
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

                    // Copy the additional data collection to the page itself so that information is not lost
                    response.Value.AdditionalData = response.AdditionalData;
                }

                return response.Value;
            }

            return null;
        }

        public async Task<IHyperfindQueriesCollectionPage> GetAsync()
        {
            return await this.GetAsync(CancellationToken.None);
        }

        public async Task<HyperfindQueryExecutionResponse> ExecuteAsync(HyperfindQueryExecutionParameters request, CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "POST";
            this.AppendSegmentToRequestUrl("execute");

            var executionResult = await this.SendAsync<HyperfindQueryExecutionResponse>(request, cancellationToken).ConfigureAwait(false);
            return executionResult;
        }

        public async Task<HyperfindQueryExecutionResponse> ExecuteAsync(HyperfindQueryExecutionParameters request)
        {
            return await ExecuteAsync(request, CancellationToken.None);
        }
    }

    public interface IHyperfindQueriesCollectionRequest
    {
        Task<IHyperfindQueriesCollectionPage> GetAsync(CancellationToken cancellationToken);

        Task<IHyperfindQueriesCollectionPage> GetAsync();

        Task<HyperfindQueryExecutionResponse> ExecuteAsync(HyperfindQueryExecutionParameters request, CancellationToken cancellationToken);

        Task<HyperfindQueryExecutionResponse> ExecuteAsync(HyperfindQueryExecutionParameters request);

    }
}
