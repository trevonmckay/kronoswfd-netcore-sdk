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
    }

    public interface IHyperfindQueryRequest
    {
        Task<HyperfindQuery> GetAsync(CancellationToken cancellationToken);

        Task<HyperfindQuery> GetAsync();
    }
}
