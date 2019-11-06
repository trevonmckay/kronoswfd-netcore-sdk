using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    public class HyperfindQueryRequestBuilder : BaseRequestBuilder, IHyperfindQueryRequestBuilder
    {
        public HyperfindQueryRequestBuilder(string requestUrl, IBaseClient client)
            : base(requestUrl, client)
        {

        }

        public IHyperfindQueryRequest Request(IEnumerable<Option> options)
        {
            return new HyperfindQueryRequest(this.RequestUrl, this.Client, options);
        }

        public IHyperfindQueryRequest Request()
        {
            return this.Request(null);
        }
    }

    public interface IHyperfindQueryRequestBuilder
    {
        IHyperfindQueryRequest Request(IEnumerable<Option> options);

        IHyperfindQueryRequest Request();
    }
}
