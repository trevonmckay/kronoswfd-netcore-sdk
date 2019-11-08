using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kronos.WFD.Client.Requests
{
    internal class TimecardsCollectionRequest : BaseRequest, ITimecardsCollectionRequest
    {
        public TimecardsCollectionRequest(string requestUrl, IBaseClient client, IEnumerable<Option> options = null)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Issues the GET request.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await for async call.</returns>
        public async Task<TimecardsCollectionPage> ReadAsync(TimecardsMultiReadParameters parameters, CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "POST";
            this.AppendSegmentToRequestUrl("multi_read");
            var response = await this.SendAsync<TimecardsCollectionResponse>(parameters, cancellationToken).ConfigureAwait(false);
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

        public async Task<TimecardsCollectionPage> ReadAsync(TimecardsMultiReadParameters parameters)
        {
            return await this.ReadAsync(parameters, CancellationToken.None);
        }
    }

    public interface ITimecardsCollectionRequest : IBaseRequest
    {
        Task<TimecardsCollectionPage> ReadAsync(TimecardsMultiReadParameters parameters, CancellationToken cancellationToken);

        Task<TimecardsCollectionPage> ReadAsync(TimecardsMultiReadParameters parameters);
    }
}
