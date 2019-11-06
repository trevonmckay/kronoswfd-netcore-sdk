using Kronos.WFD.Extensions;
using System;
using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    public class LocationsCollectionRequestBuilder : BaseRequestBuilder, ILocationsCollectionRequestBuilder
    {
        public LocationsCollectionRequestBuilder(string requestUrl, IBaseClient client)
            : base(requestUrl, client)
        {
        }

        public ILocationsCollectionRequest Request(IEnumerable<Option> options)
        {
            return new LocationsCollectionRequest(this.RequestUrl, this.Client, options);
        }

        public ILocationsCollectionRequest Request()
        {
            return this.Request(null);
        }

        public ILocationRequest Query(string path, LocationContext context, DateTime date)
        {
            var locationRequest = new LocationRequest(this.RequestUrl, this.Client);
            if (locationRequest.QueryOptions == null)
            {
                locationRequest.QueryOptions = new List<QueryOption>();
            }

            locationRequest.QueryOptions.Add(new QueryOption("path", path));
            locationRequest.QueryOptions.Add(new QueryOption("context", context.Description()));
            locationRequest.QueryOptions.Add(new QueryOption("date", date.ToString("yyyy-MM-dd")));

            return locationRequest;
        }

        public ILocationRequest this[string id]
        {
            get
            {
                return new LocationRequest(this.AppendSegmentToRequestUrl(id), this.Client);
            }
        }
    }

    public interface ILocationsCollectionRequestBuilder : IBaseRequestBuilder
    {
        ILocationsCollectionRequest Request(IEnumerable<Option> options);

        ILocationsCollectionRequest Request();

        ILocationRequest Query(string path, LocationContext context, DateTime date);

        ILocationRequest this[string id] { get; }
    }
}
