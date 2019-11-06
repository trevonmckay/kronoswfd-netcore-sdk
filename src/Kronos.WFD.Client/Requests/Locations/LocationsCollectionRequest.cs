using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kronos.WFD.Client.Requests
{
    public class LocationsCollectionRequest : BaseRequest, ILocationsCollectionRequest
    {
        private LocationsMultiReadParameters _multiReadParameters = null;

        public LocationsCollectionRequest(string requestUrl, IBaseClient client, IEnumerable<Option> options)
            : base (requestUrl, client, options)
        {

        }

        public ILocationsCollectionRequest ChildrenOf(LocationReference parentLocation, LocationContext context, DateTime date, LocationTypesSelector includeLocationTypes = null)
        {
            if (_multiReadParameters == null)
            {
                _multiReadParameters = new LocationsMultiReadParameters
                {
                    Where = new LocationsWhereClause()
                };
            }

            _multiReadParameters.Where.ChildrenOf = new LocationsChildrenOfClause
            {
                Context = context,
                Date = date,
                LocationReference = parentLocation,
                IncludeLocationTypes = includeLocationTypes,
            };

            this.RequestUrl += "/multi_read";
            return this;
        }

        public ILocationsCollectionRequest DescendantsOf(LocationReference ancestorLocation, LocationContext context, DateTime date, LocationTypesSelector includeLocationTypes = null)
        {
            if (_multiReadParameters == null)
            {
                _multiReadParameters = new LocationsMultiReadParameters
                {
                    Where = new LocationsWhereClause()
                };
            }

            _multiReadParameters.Where.DescendantsOf = new LocationsDescendantsOfClause
            {
                Context = context,
                Date = date,
                LocationReference = ancestorLocation,
                IncludeLocationTypes = includeLocationTypes,
            };

            this.RequestUrl += "/multi_read";
            return this;
        }

        public async Task<ILocationsCollectionPage> GetAsync(CancellationToken cancellationToken)
        {
            this.Method = "GET";
            var response = await this.SendAsync<LocationsCollectionResponse>(null, cancellationToken).ConfigureAwait(false);
            if (response != null && response.Value != null && response.Value.CurrentPage != null)
            {
                if (response.AdditionalData != null)
                {
                    response.AdditionalData.TryGetValue("@odata.nextLink", out object nextPageLink);

                    var nextPageLinkString = nextPageLink as string;
                    if (!string.IsNullOrEmpty(nextPageLinkString))
                    {
                        response.Value.InitializeNextPageRequest(
                            this.Client,
                            nextPageLinkString);
                    }

                    response.Value.AdditionalData = response.AdditionalData;
                }

                return response.Value;
            }

            return null;
        }

        public async Task<ILocationsCollectionPage> GetAsync()
        {
            return await this.GetAsync(CancellationToken.None);
        }

        public async Task<ILocationsCollectionPage> PostAsync(CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "POST";
            var response = await this.SendAsync<LocationsCollectionResponse>(_multiReadParameters, cancellationToken).ConfigureAwait(false);
            if (response != null && response.Value != null && response.Value.CurrentPage != null)
            {
                if (response.AdditionalData != null)
                {
                    response.AdditionalData.TryGetValue("@odata.nextLink", out object nextPageLink);

                    var nextPageLinkString = nextPageLink as string;
                    if (!string.IsNullOrEmpty(nextPageLinkString))
                    {
                        response.Value.InitializeNextPageRequest(
                            this.Client,
                            nextPageLinkString);
                    }

                    response.Value.AdditionalData = response.AdditionalData;
                }

                return response.Value;
            }

            return null;
        }

        public async Task<ILocationsCollectionPage> PostAsync()
        {
            return await this.PostAsync(CancellationToken.None);
        }
    }

    public interface ILocationsCollectionRequest : IBaseRequest
    {
        Task<ILocationsCollectionPage> GetAsync(CancellationToken cancellationToken);

        Task<ILocationsCollectionPage> GetAsync();

        Task<ILocationsCollectionPage> PostAsync(CancellationToken cancellationToken);

        Task<ILocationsCollectionPage> PostAsync();

        ILocationsCollectionRequest ChildrenOf(LocationReference parentLocation, LocationContext context, DateTime date, LocationTypesSelector includeLocationTypes = null);

        ILocationsCollectionRequest DescendantsOf(LocationReference ancestorLocation, LocationContext context, DateTime date, LocationTypesSelector includeLocationTypes = null);
    }
}
