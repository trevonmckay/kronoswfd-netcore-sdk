using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kronos.WFD.Client.Requests
{
    public class HyperfindQueryRequest : BaseRequest, IHyperfindQueryRequest
    {
        public HyperfindQueryRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {

        }

        public async Task<HyperfindQuery> GetAsync(CancellationToken cancellationToken)
        {
            this.Method = "GET";
            var retrievedEntity = await this.SendAsync<HyperfindQuery>(null, cancellationToken).ConfigureAwait(false);
            return retrievedEntity;
        }

        public async Task<HyperfindQuery> GetAsync()
        {
            return await GetAsync(CancellationToken.None);
        }

        public async Task<HyperfindQueryExecutionResponse> PostAsync(HyperfindQueryExecutionParameters request, CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "POST";

            var hyperfindIdPosition = this.RequestUrl.LastIndexOf('/') + 1;
            var hyperFindId = this.RequestUrl.Substring(hyperfindIdPosition, this.RequestUrl.Length - hyperfindIdPosition);
            this.RequestUrl = this.RequestUrl.Substring(0, hyperfindIdPosition) + "execute";

            if (request.Hyperfind == null)
            {
                request.Hyperfind = new HyperfindLookupParameters();
            }
            request.Hyperfind.Id = hyperFindId;

            var executionResult = await this.SendAsync<HyperfindQueryExecutionResponse>(request, cancellationToken).ConfigureAwait(false);
            return executionResult;
        }

        public async Task<HyperfindQueryExecutionResponse> PostAsync(HyperfindQueryExecutionParameters request)
        {
            return await PostAsync(request, CancellationToken.None);
        }
    }

    public interface IHyperfindQueryRequest
    {
        Task<HyperfindQuery> GetAsync(CancellationToken cancellationToken);

        Task<HyperfindQuery> GetAsync();

        Task<HyperfindQueryExecutionResponse> PostAsync(HyperfindQueryExecutionParameters request, CancellationToken cancellationToken);

        Task<HyperfindQueryExecutionResponse> PostAsync(HyperfindQueryExecutionParameters request);
    }
}
