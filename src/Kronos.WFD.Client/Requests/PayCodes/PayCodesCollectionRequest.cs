using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kronos.WFD.Client.Requests
{
    public class PayCodesCollectionRequest : BaseRequest, IPayCodesCollectionRequest
    {
        public PayCodesCollectionRequest(string requestUrl, IBaseClient client, IEnumerable<Option> options = null)
            : base(requestUrl, client, options)
        {
        }

        public async Task<IPayCodesCollectionPage> GetAsync(CancellationToken cancellationToken)
        {
            this.Method = "GET";
            var response = await this.SendAsync<PayCodesCollectionResponse>(null, cancellationToken).ConfigureAwait(false);
            if (response != null && response.Value != null && response.Value.CurrentPage != null)
            {
                if (response.AdditionalData != null)
                {
                    response.Value.AdditionalData = response.AdditionalData;
                }

                return response.Value;
            }

            return null;
        }

        public async Task<IPayCodesCollectionPage> GetAsync()
        {
            return await this.GetAsync(CancellationToken.None);
        }
    }

    public interface IPayCodesCollectionRequest : IBaseRequest
    {
        Task<IPayCodesCollectionPage> GetAsync(CancellationToken cancellationToken);

        Task<IPayCodesCollectionPage> GetAsync();
    }
}
