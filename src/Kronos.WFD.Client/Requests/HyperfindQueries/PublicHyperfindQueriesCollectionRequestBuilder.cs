using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    internal class PublicHyperfindQueriesCollectionRequestBuilder : BaseRequestBuilder, IPublicHyperfindQueriesCollectionRequestBuilder
    {
        public PublicHyperfindQueriesCollectionRequestBuilder(string requestUrl, IBaseClient client)
            : base(requestUrl, client)
        {
        }

        public IHyperfindQueriesCollectionRequest Request(IEnumerable<Option> options)
        {
            return new HyperfindQueriesCollectionRequest(this.RequestUrl, this.Client, options);
        }

        public IHyperfindQueriesCollectionRequest Request()
        {
            return Request(null);
        }
    }

    public interface IPublicHyperfindQueriesCollectionRequestBuilder : IBaseRequestBuilder
    {
        IHyperfindQueriesCollectionRequest Request(IEnumerable<Option> options);

        IHyperfindQueriesCollectionRequest Request();
    }
}
