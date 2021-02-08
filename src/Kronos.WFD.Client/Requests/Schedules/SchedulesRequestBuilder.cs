namespace Kronos.WFD.Client.Requests
{
    public class SchedulesRequestBuilder : BaseRequestBuilder, ISchedulesRequestBuilder
    {
        public SchedulesRequestBuilder(string requestUrl, IBaseClient client)
            : base(requestUrl, client)
        {

        }
        
        public ISchedulesCollectionRequestBuilder Employee
        {
            get
            {
                return new SchedulesCollectionRequestBuilder(this.AppendSegmentToRequestUrl("schedule"), this.Client);
            }
        }                                               
    }

    public interface ISchedulesRequestBuilder
    {
        ISchedulesCollectionRequestBuilder Employee { get; }
    }
}
