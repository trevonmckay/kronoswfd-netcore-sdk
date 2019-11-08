namespace Kronos.WFD.Client.Requests
{
    public class TimecardsCollectionPage : CollectionPage<EmployeeTimecard>, ITimecardsCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="IGraphServiceUsersCollectionRequest"/> instance.
        /// </summary>
        public ITimecardsCollectionRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                this.NextPageRequest = new TimecardsCollectionRequest(
                    nextPageLinkString,
                    client,
                    null);
            }
        }
    }

    public interface ITimecardsCollectionPage : ICollectionPage<EmployeeTimecard>
    {
        ITimecardsCollectionRequest NextPageRequest { get; }

        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
