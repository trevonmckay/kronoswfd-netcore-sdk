using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    class EmployeeTimecardRequestBuilder : BaseRequestBuilder
    {
        public EmployeeTimecardRequestBuilder(string requestUrl, IBaseClient client)
            : base(requestUrl, client)
        {

        }

        public IEmployeeTimecardRequest Request()
        {
            return this.Request(null);
        }

        public IEmployeeTimecardRequest Request(IEnumerable<Option> options)
        {
            return new EmployeeTimecardRequest(this.RequestUrl, this.Client, options);
        }
    }
}
