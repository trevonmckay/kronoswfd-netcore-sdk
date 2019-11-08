using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    internal class TimecardsCollectionRequestBuilder : BaseRequest, ITimecardsCollectionRequestBuilder
    {
        public TimecardsCollectionRequestBuilder(string requestUrl, IBaseClient client, IEnumerable<Option> options = null)
            : base(requestUrl, client, options)
        {
        }

        public ITimecardsCollectionRequest Request(IEnumerable<Option> options)
        {
            return new TimecardsCollectionRequest(this.RequestUrl, this.Client, options);
        }

        public ITimecardsCollectionRequest Request()
        {
            return new TimecardsCollectionRequest(this.RequestUrl, this.Client, null);
        }

        public ITimecardRequestBuilder GetTimeCardByPersonNumber(string personNumber)
        {
            return new TimecardRequestBuilder(personNumber, null, this.RequestUrl, this.Client);
        }

        public ITimecardRequestBuilder GetTimeCardByEmployeeId(string employeeId)
        {
            return new TimecardRequestBuilder(null, employeeId, this.RequestUrl, this.Client);
        }
    }

    public interface ITimecardsCollectionRequestBuilder : IBaseRequest
    {
        ITimecardsCollectionRequest Request(IEnumerable<Option> options);

        ITimecardsCollectionRequest Request();

        ITimecardRequestBuilder GetTimeCardByEmployeeId(string employeeId);

        ITimecardRequestBuilder GetTimeCardByPersonNumber(string personNumber);
    }
}
