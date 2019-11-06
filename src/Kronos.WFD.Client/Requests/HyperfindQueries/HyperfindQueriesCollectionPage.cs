namespace Kronos.WFD.Client.Requests
{
    public class HyperfindQueriesCollectionPage : CollectionPage<HyperfindQuery>, IHyperfindQueriesCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="IGraphServiceUsersCollectionRequest"/> instance.
        /// </summary>
        public IHyperfindQueriesCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                this.NextPageRequest = new HyperfindQueriesCollectionRequest(
                    nextPageLinkString,
                    client,
                    null);
            }
        }
    }

    public interface IHyperfindQueriesCollectionPage : ICollectionPage<HyperfindQuery>
    {
        IHyperfindQueriesCollectionRequest NextPageRequest { get; }

        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
