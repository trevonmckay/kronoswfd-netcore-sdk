using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests.BulkData
{
    internal class BulkDataCollectionRequestBuilder : BaseRequest, IBulkDataCollectionRequestBuilder
    {
        public BulkDataCollectionRequestBuilder(string requestUrl, IBaseClient client, IEnumerable<Option> options = null) : base(requestUrl, client, options)
        {
        }

        public IBulkDataRequest Request()
        {
            return new BulkDataRequest(this.RequestUrl, this.Client, null);
        }
    }

    public interface IBulkDataCollectionRequestBuilder : IBaseRequest
    {
        IBulkDataRequest Request();
    }
}
