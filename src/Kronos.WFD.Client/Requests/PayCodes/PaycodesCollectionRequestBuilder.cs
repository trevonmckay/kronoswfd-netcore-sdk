using System;
using System.Collections.Generic;
using System.Text;

namespace Kronos.WFD.Client.Requests
{
    public class PaycodesCollectionRequestBuilder : BaseRequestBuilder, IPayCodesCollectionRequestBuilder
    {
        public PaycodesCollectionRequestBuilder(string requestUrl, IBaseClient client)
            : base(requestUrl, client)
        {
        }

        public IPayCodesCollectionRequest Request(IEnumerable<Option> options)
        {
            return new PayCodesCollectionRequest(this.RequestUrl, this.Client, options);
        }

        public IPayCodesCollectionRequest Request()
        {
            return new PayCodesCollectionRequest(this.RequestUrl, this.Client, null);
        }
    }

    public interface IPayCodesCollectionRequestBuilder : IBaseRequestBuilder
    {
        IPayCodesCollectionRequest Request(IEnumerable<Option> options);

        IPayCodesCollectionRequest Request();
    }
}
