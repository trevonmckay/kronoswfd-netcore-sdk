namespace Kronos.WFD.Client.Requests
{
    public class SchedulesCollectionPage : CollectionPage<Schedule>, ISchedulesCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="IGraphServiceUsersCollectionRequest"/> instance.
        /// </summary>
        public ISchedulesRequest NextPageRequest { get; private set; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                this.NextPageRequest = new SchedulesRequest(
                    nextPageLinkString,
                    client,
                    null);
            }
        }
    }

    public interface ISchedulesCollectionPage : ICollectionPage<Schedule>
    {
        ISchedulesRequest NextPageRequest { get; }

        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
