using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    internal class SchedulesCollectionRequestBuilder : BaseRequest, ISchedulesCollectionRequestBuilder
    {
        public SchedulesCollectionRequestBuilder(string requestUrl, IBaseClient client, IEnumerable<Option> options = null)
            : base(requestUrl, client, options)
        {
        }

        public ISchedulesRequest Request(IEnumerable<Option> options)
        {
            return new SchedulesRequest(this.RequestUrl, this.Client, options);
        }

        public ISchedulesRequest Request()
        {
            return new SchedulesRequest(this.RequestUrl, this.Client, null);
        }

        public IScheduleRequestBuilder GetScheduleByPersonNumber(string personNumber)
        {
            return new ScheduleRequestBuilder(personNumber, null, this.RequestUrl, this.Client);
        }

        public IScheduleRequestBuilder GetScheduleByEmployeeId(string employeeId)
        {
            return new ScheduleRequestBuilder(null, employeeId, this.RequestUrl, this.Client);
        }
    }

    public interface ISchedulesCollectionRequestBuilder : IBaseRequest
    {
        ISchedulesRequest Request(IEnumerable<Option> options);

        ISchedulesRequest Request();

        IScheduleRequestBuilder GetScheduleByEmployeeId(string employeeId);

        IScheduleRequestBuilder GetScheduleByPersonNumber(string personNumber);
    }
}
