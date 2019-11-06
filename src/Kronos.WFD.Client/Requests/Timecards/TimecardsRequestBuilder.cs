using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    public class TimecardsRequestBuilder : BaseRequestBuilder, ITimecardsRequestBuilder
    {
        public TimecardsRequestBuilder(string requestUrl, IBaseClient client)
            : base(requestUrl, client)
        {

        }

        public TimecardsRequest Request(EmployeeTimecardsMultiReadParameters parameters)
        {
            return this.Request(parameters, null);
        }

        public TimecardsRequest Request(EmployeeTimecardsMultiReadParameters parameters, IEnumerable<Option> options)
        {
            return new TimecardsRequest(parameters, this.RequestUrl, this.Client, options);
        }
    }

    public interface ITimecardsRequestBuilder
    {
        TimecardsRequest Request(EmployeeTimecardsMultiReadParameters parameters);

        TimecardsRequest Request(EmployeeTimecardsMultiReadParameters parameters, IEnumerable<Option> options);
    }
}
