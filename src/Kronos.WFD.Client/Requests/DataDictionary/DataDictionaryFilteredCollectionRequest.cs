using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kronos.WFD.Client.Requests
{
    internal class DataDictionaryFilteredCollectionRequest : BaseRequest, IDataDictionaryFilteredCollectionRequest
    {
        public IEnumerable<string> SelectedKeys { get; private set; }

        public DataDictionaryFilteredCollectionRequest(IEnumerable<string> keys, string requestUrl, IBaseClient client, IEnumerable<Option> options = null)
            : base(requestUrl, client, options)
        {
            SelectedKeys = keys;
        }

        public async Task<DataDictionaryCollectionPage> PostAsync(CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "POST";
            var response = await this.SendAsync<DataDictionaryCollectionResponse>(SelectedKeys, cancellationToken).ConfigureAwait(false);
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

        public async Task<DataDictionaryCollectionPage> PostAsync()
        {
            return await PostAsync(CancellationToken.None);
        }
    }

    public interface IDataDictionaryFilteredCollectionRequest
    {
        Task<DataDictionaryCollectionPage> PostAsync(CancellationToken cancellationToken);

        Task<DataDictionaryCollectionPage> PostAsync();
    }
}
