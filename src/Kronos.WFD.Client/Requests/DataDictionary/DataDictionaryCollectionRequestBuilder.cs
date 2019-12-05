using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    internal class DataDictionaryCollectionRequestBuilder : BaseRequestBuilder, IDataDictionaryCollectionRequestBuilder
    {
        public DataDictionaryCollectionRequestBuilder(string requestUrl, IBaseClient client)
            : base(requestUrl, client)
        {
        }

        public IDataDictionaryCollectionRequest Request(IEnumerable<Option> options)
        {
            return new DataDictionaryCollectionRequest(this.RequestUrl, this.Client, options);
        }

        public IDataDictionaryCollectionRequest Request()
        {
            return Request(null);
        }

        public IDataDictionaryFilteredCollectionRequest GetDataByKeys(IEnumerable<string> keys, IEnumerable<Option> options)
        {
            return new DataDictionaryFilteredCollectionRequest(keys, this.AppendSegmentToRequestUrl("multi_read"), this.Client, options);
        }

        public IDataDictionaryFilteredCollectionRequest GetDataByKeys(IEnumerable<string> keys)
        {
            return GetDataByKeys(keys, null);
        }
    }

    public interface IDataDictionaryCollectionRequestBuilder
    {
        IDataDictionaryCollectionRequest Request(IEnumerable<Option> options);

        IDataDictionaryCollectionRequest Request();

        IDataDictionaryFilteredCollectionRequest GetDataByKeys(IEnumerable<string> keys, IEnumerable<Option> options);

        IDataDictionaryFilteredCollectionRequest GetDataByKeys(IEnumerable<string> keys);
    }
}
