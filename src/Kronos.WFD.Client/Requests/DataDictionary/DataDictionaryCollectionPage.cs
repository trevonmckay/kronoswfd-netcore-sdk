using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    public class DataDictionaryCollectionPage : CollectionPage<IDictionary<string, object>>, IDataDictionaryCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="IDataDictionaryCollectionRequest"/> instance.
        /// </summary>
        public IDataDictionaryCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                this.NextPageRequest = new DataDictionaryCollectionRequest(
                    nextPageLinkString,
                    client,
                    null);
            }
        }
    }

    public interface IDataDictionaryCollectionPage : ICollectionPage<IDictionary<string, object>>
    {
        IDataDictionaryCollectionRequest NextPageRequest { get; }

        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
