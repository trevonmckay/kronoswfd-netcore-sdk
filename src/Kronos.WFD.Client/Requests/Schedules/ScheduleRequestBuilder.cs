using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    internal class ScheduleRequestBuilder : BaseRequestBuilder, IScheduleRequestBuilder
    {
        private readonly string _employeeId;
        private readonly string _personNumber;

        private ScheduleRequestBuilder(string requestUrl, IBaseClient client)
            : base(requestUrl, client)
        {

        }

        public ScheduleRequestBuilder(string personNumber, string employeeId, string requestUrl, IBaseClient client)
            : this(requestUrl, client)
        {
            _employeeId = employeeId;
            _personNumber = personNumber;
        }

        public IScheduleRequest Request(IEnumerable<Option> options)
        {
            if (options == null)
            {
                options = new List<Option>();
            }

            if (!string.IsNullOrEmpty(_employeeId))
            {
                (options as List<Option>).Add(new QueryOption("employee_id", _employeeId));
            }
            else if (!string.IsNullOrEmpty(_personNumber))
            {
                (options as List<Option>).Add(new QueryOption("person_number", _personNumber));
            }

            var request = new ScheduleRequest(this.RequestUrl, this.Client, options);
            return request;
        }

        public IScheduleRequest Request()
        {
            return this.Request(null);
        }
    }

    public interface IScheduleRequestBuilder
    {
        IScheduleRequest Request(IEnumerable<Option> options);

        IScheduleRequest Request();
    }
}
