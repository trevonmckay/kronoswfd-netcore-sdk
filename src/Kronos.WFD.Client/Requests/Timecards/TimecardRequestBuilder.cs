using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    internal class TimecardRequestBuilder : BaseRequestBuilder, ITimecardRequestBuilder
    {
        private readonly string _employeeId;
        private readonly string _personNumber;

        private TimecardRequestBuilder(string requestUrl, IBaseClient client)
            : base(requestUrl, client)
        {

        }

        public TimecardRequestBuilder(string personNumber, string employeeId, string requestUrl, IBaseClient client)
            : this(requestUrl, client)
        {
            _employeeId = employeeId;
            _personNumber = personNumber;
        }

        public ITimecardRequest Request(IEnumerable<Option> options)
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

            var request = new TimecardRequest(this.RequestUrl, this.Client, options);
            return request;
        }

        public ITimecardRequest Request()
        {
            return this.Request(null);
        }
    }

    public interface ITimecardRequestBuilder
    {
        ITimecardRequest Request(IEnumerable<Option> options);

        ITimecardRequest Request();
    }
}
