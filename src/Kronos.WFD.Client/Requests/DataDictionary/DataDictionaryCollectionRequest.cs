using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kronos.WFD.Client.Requests
{
    internal class DataDictionaryCollectionRequest : BaseRequest, IDataDictionaryCollectionRequest
    {
        public DataDictionaryCollectionRequest(string requestUrl, IBaseClient client, IEnumerable<Option> options = null)
            : base(requestUrl, client, options)
        {
        }

        public async Task<DataDictionaryCollectionPage> GetAsync(CancellationToken cancellationToken)
        {
            this.Method = "GET";
            var response = await this.SendAsync<DataDictionaryCollectionResponse>(null, cancellationToken).ConfigureAwait(false);
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

                    response.Value.AdditionalData = response.AdditionalData;
                }

                return response.Value;
            }

            return null;
        }

        public async Task<DataDictionaryCollectionPage> GetAsync()
        {
            return await GetAsync(CancellationToken.None);
        }
    }

    public interface IDataDictionaryCollectionRequest
    {
        Task<DataDictionaryCollectionPage> GetAsync(CancellationToken cancellationToken);

        Task<DataDictionaryCollectionPage> GetAsync();
    }
}
