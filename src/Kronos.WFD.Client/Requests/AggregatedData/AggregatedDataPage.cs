namespace Kronos.WFD.Client.Requests
{
    public class AggregatedDataPage : CollectionPage<AggregatedData>, IAggregatedDataPage
    {
        public IAggregatedDataRequest NextPageRequest { get; private set; }

        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString, string metadataKey = null)
        {
            var request = new AggregatedDataRequest(nextPageLinkString, client, null);
            request.Parameters.Index++;
            if (!string.IsNullOrWhiteSpace(metadataKey) && request.Parameters.Options == null)
            {
                request.Parameters.Options = new AggregatedDataRequestOptions
                {
                    MetadataKey = metadataKey
                };
            }
            this.NextPageRequest = request;
        }
    }

    public interface IAggregatedDataPage : ICollectionPage<AggregatedData>
    {
        IAggregatedDataRequest NextPageRequest { get; }

        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString, string metadataKey);
    }
}
