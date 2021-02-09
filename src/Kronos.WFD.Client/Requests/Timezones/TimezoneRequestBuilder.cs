using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    internal enum TimezoneRequestQueryParameter
    {
        TimezoneName,
        LocationID,
        EmployeeID,
        PersonNumber
    }

    internal class TimezoneRequestBuilder : BaseRequestBuilder, ITimezoneRequestBuilder
    {
        /*
         /v1/timekeeping/employee_timecard/multi-read
        /v1/commons/setup/timezones?name=""                 --> The name of the timezone
        /v1/commons/setup/timezones?employee_id=""          --> An ID that uniquely identifies an employee
        /v1/commons/setup/timezones?person_number=""        --> A unique identifier for a person
        /v1/commons/setup/timezones?location_id=""          --> The location ID associated with a timezone
        /v1/commons/setup/timezones?date=""                 --> The effective date for a location
         */
        private readonly TimezoneRequestQueryParameter _queryParmeter;
        private readonly string _queryParamValue;

        public TimezoneRequestBuilder(string requestUrl, IBaseClient client)
            : base(requestUrl, client)
        {

        }

        public TimezoneRequestBuilder(TimezoneRequestQueryParameter queryParam, string queryParamValue, string requestUrl, IBaseClient client)
            : this(requestUrl, client)
        {
            _queryParmeter = queryParam;
            _queryParamValue = queryParamValue;
        }


        public ITimezoneRequest Request(IEnumerable<Option> options)
        {
            if (options == null)
            {
                options = new List<Option>();
            }

            switch (_queryParmeter)
            {
                case TimezoneRequestQueryParameter.TimezoneName:
                    (options as List<Option>).Add(new QueryOption("name", _queryParamValue));
                    break;
                case TimezoneRequestQueryParameter.LocationID:
                    (options as List<Option>).Add(new QueryOption("location_id", _queryParamValue));
                    break;
                case TimezoneRequestQueryParameter.EmployeeID:
                    (options as List<Option>).Add(new QueryOption("employee_id", _queryParamValue));
                    break;
                case TimezoneRequestQueryParameter.PersonNumber:
                    (options as List<Option>).Add(new QueryOption("person_number", _queryParamValue));
                    break;
            }

            var request = new TimezoneRequest(this.RequestUrl, this.Client, options);
            return request;
        }

        public ITimezoneRequest Request()
        {
            return this.Request(null);
        }
    }

    public interface ITimezoneRequestBuilder
    {
        ITimezoneRequest Request(IEnumerable<Option> options);
        ITimezoneRequest Request();
    }
}
