namespace Kronos.WFD.Client.Requests
{
    public class LocationsCollectionPage : CollectionPage<Location>, ILocationsCollectionPage
    {
        public ILocationsCollectionRequest NextPageRequest { get; private set; }

        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                this.NextPageRequest = new LocationsCollectionRequest(nextPageLinkString, client, null);
            }
        }
    }

    public interface ILocationsCollectionPage : ICollectionPage<Location>
    {
        ILocationsCollectionRequest NextPageRequest { get; }

        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
