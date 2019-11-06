using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kronos.WFD.Client.Requests
{
    public class LocationRequest : BaseRequest, ILocationRequest
    {
        public LocationRequest(string requestUrl, IBaseClient client, IEnumerable<Option> options = null)
            : base(requestUrl, client, options)
        {
        }

        public async Task<Location> GetAsync(CancellationToken cancellationToken)
        {
            this.Method = "GET";
            var retrievedEntity = await this.SendAsync<Location>(null, cancellationToken).ConfigureAwait(false);
            return retrievedEntity;
        }

        public async Task<Location> GetAsync()
        {
            return await GetAsync(CancellationToken.None);
        }
    }

    public interface ILocationRequest : IBaseRequest
    {
        Task<Location> GetAsync(CancellationToken cancellationToken);

        Task<Location> GetAsync();
    }
}
