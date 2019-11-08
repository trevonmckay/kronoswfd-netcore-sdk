namespace Kronos.WFD.Client.Requests
{
    public class TimecardsRequestBuilder : BaseRequestBuilder, ITimecardsRequestBuilder
    {
        public TimecardsRequestBuilder(string requestUrl, IBaseClient client)
            : base(requestUrl, client)
        {

        }

        public ITimecardsCollectionRequestBuilder Employee
        {
            get
            {
                return new TimecardsCollectionRequestBuilder(this.AppendSegmentToRequestUrl("employee_timecard"), this.Client);
            }
        }

        public ITimecardsCollectionRequestBuilder Manager
        {
            get
            {
                return new TimecardsCollectionRequestBuilder(this.AppendSegmentToRequestUrl("timecard"), this.Client);
            }
        }
    }

    public interface ITimecardsRequestBuilder
    {
        ITimecardsCollectionRequestBuilder Employee { get; }

        ITimecardsCollectionRequestBuilder Manager { get; }
    }
}
