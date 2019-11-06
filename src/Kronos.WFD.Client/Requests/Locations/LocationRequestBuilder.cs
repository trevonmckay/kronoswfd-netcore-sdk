using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    public class LocationRequestBuilder : BaseRequestBuilder, ILocationRequestBuilder
    {
        public LocationRequestBuilder(string requestUrl, IBaseClient client)
            : base(requestUrl, client)
        {
        }

        public ILocationRequest Request(IEnumerable<Option> options)
        {
            return new LocationRequest(this.RequestUrl, this.Client, options);
        }

        public ILocationRequest Request()
        {
            return this.Request(null);
        }
    }

    public interface ILocationRequestBuilder : IBaseRequestBuilder
    {
        ILocationRequest Request(IEnumerable<Option> options);

        ILocationRequest Request();
    }
}
