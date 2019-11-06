using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    public class HyperfindQueriesCollectionRequestBuilder : BaseRequestBuilder, IHyperfindQueriesCollectionRequestBuilder
    {
        public HyperfindQueriesCollectionRequestBuilder(
            string requestUrl,
            IBaseClient client)
            : base (requestUrl, client)
        {

        }

        public IHyperfindQueriesCollectionRequest Request()
        {
            return this.Request(null);
        }

        public IHyperfindQueriesCollectionRequest Request(IEnumerable<Option> options)
        {
            return new HyperfindQueriesCollectionRequest(this.RequestUrl, this.Client, options);
        }

        public IHyperfindQueryRequestBuilder this[string id]
        {
            get
            {
                return new HyperfindQueryRequestBuilder(this.AppendSegmentToRequestUrl(id), this.Client);
            }
        }
    }

    public interface IHyperfindQueriesCollectionRequestBuilder
    {
        IHyperfindQueriesCollectionRequest Request();

        IHyperfindQueriesCollectionRequest Request(IEnumerable<Option> options);

        IHyperfindQueryRequestBuilder this[string id] { get; }
    }
}
