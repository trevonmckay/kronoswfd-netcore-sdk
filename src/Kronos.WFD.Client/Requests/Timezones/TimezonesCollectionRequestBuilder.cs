namespace Kronos.WFD.Client.Requests
{
    internal class TimezonesCollectionRequestBuilder : BaseRequestBuilder, ITimezonesCollectionRequestBuilder
    {
        public TimezonesCollectionRequestBuilder(string requestUrl, IBaseClient client)
            : base(requestUrl, client)
        {
        }

        public ITimezoneRequestBuilder this[string id]
        {
            get
            {
                return new TimezoneRequestBuilder(this.AppendSegmentToRequestUrl(id), this.Client);
            }
        }

        public ITimezoneRequestBuilder GetTimezoneByName(string timezoneName)
        {
            return new TimezoneRequestBuilder(TimezoneRequestQueryParameter.TimezoneName, timezoneName, this.RequestUrl, this.Client);
        }

        public ITimezoneRequestBuilder GetTimezoneByPersonNumber(string personNumber)
        {
            return new TimezoneRequestBuilder(TimezoneRequestQueryParameter.PersonNumber, personNumber, this.RequestUrl, this.Client);
        }

        public ITimezoneRequestBuilder GetTimezoneByEmployeeId(string employeeId)
        {
            return new TimezoneRequestBuilder(TimezoneRequestQueryParameter.EmployeeID, employeeId, this.RequestUrl, this.Client);
        }

        public ITimezoneRequestBuilder GetTimezoneByLocationId(string locationId)
        {
            return new TimezoneRequestBuilder(TimezoneRequestQueryParameter.LocationID, locationId, this.RequestUrl, this.Client);
        }
    }

    public interface ITimezonesCollectionRequestBuilder : IBaseRequestBuilder
    {
        ITimezoneRequestBuilder this[string id] { get; }

        ITimezoneRequestBuilder GetTimezoneByName(string timezoneName);

        ITimezoneRequestBuilder GetTimezoneByEmployeeId(string employeeId);

        ITimezoneRequestBuilder GetTimezoneByPersonNumber(string personNumber);

        ITimezoneRequestBuilder GetTimezoneByLocationId(string locationId);
    }
}
