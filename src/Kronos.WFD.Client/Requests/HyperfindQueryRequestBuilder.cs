using System;
using System.Collections.Generic;
using System.Text;

namespace Kronos.WFD.Client.Requests
{
    public class HyperfindQueryRequestBuilder : BaseRequestBuilder, IHyperfindQueryRequestBuilder
    {
        public HyperfindQueryRequestBuilder(string requestUrl, IBaseClient client)
            : base(requestUrl, client)
        {

        }

        public IHyperfindQueryRequest Request()
        {
            return this.Request(null);
        }

        public IHyperfindQueryRequest Request(string options)
        {
            return new HyperfindQueryRequest(this.RequestUrl, this.Client, options)
        }
    }

    public interface IHyperfindQueryRequestBuilder
    {

    }
}
