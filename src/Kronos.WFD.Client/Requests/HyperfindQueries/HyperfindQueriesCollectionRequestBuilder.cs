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

        public IHyperfindQueriesCollectionRequest Request(IEnumerable<Option> options)
        {
            return new HyperfindQueriesCollectionRequest(this.RequestUrl, this.Client, options);
        }

        public IHyperfindQueriesCollectionRequest Request()
        {
            return this.Request(null);
        }

        public IHyperfindQueryRequestBuilder this[string id]
        {
            get
            {
                return new HyperfindQueryRequestBuilder(this.AppendSegmentToRequestUrl(id), this.Client);
            }
        }

        public IPublicHyperfindQueriesCollectionRequestBuilder Public
        {
            get
            {
                return new PublicHyperfindQueriesCollectionRequestBuilder(this.RequestUrl + "/public", this.Client);
            }
        }
    }

    public interface IHyperfindQueriesCollectionRequestBuilder
    {
        IHyperfindQueriesCollectionRequest Request(IEnumerable<Option> options);

        IHyperfindQueriesCollectionRequest Request();

        IHyperfindQueryRequestBuilder this[string id] { get; }

        IPublicHyperfindQueriesCollectionRequestBuilder Public { get; }
    }
}
