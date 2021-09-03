namespace Kronos.WFD.Client.Requests.BulkData
{
    public class BulkDataRequestBuilder : BaseRequestBuilder, IBulkDataRequestBuilder
    {
        public BulkDataRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {

        }
        public IBulkDataCollectionRequestBuilder BulkDataAsync
        {
            get
            {
                return new BulkDataCollectionRequestBuilder(this.AppendSegmentToRequestUrl("exports"), this.Client);
            }
        }
    }
    public interface IBulkDataRequestBuilder
    {
            IBulkDataCollectionRequestBuilder BulkDataAsync { get; }
     }
}
