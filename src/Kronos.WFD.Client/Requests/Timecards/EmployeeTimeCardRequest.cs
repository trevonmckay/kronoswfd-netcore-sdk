using System.Collections.Generic;
using System.Threading;

namespace Kronos.WFD.Client.Requests
{
    public class EmployeeTimecardRequest : BaseRequest, IEmployeeTimecardRequest
    {
        public EmployeeTimecardRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Issues the GET request.
        /// </summary>
        public System.Threading.Tasks.Task<IEnumerable<EmployeeTimecard>> GetAsync()
        {
            return this.GetAsync(CancellationToken.None);
        }

        /// <summary>
        /// Issues the GET request.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await for async call.</returns>
        public async System.Threading.Tasks.Task<IEnumerable<EmployeeTimecard>> GetAsync(
            CancellationToken cancellationToken)
        {
            this.Method = "GET";
            var response = await this.SendAsync<IEnumerable<EmployeeTimecard>>(null, cancellationToken).ConfigureAwait(false);
            /*
            if (response != null && response.Value != null && response.Value.CurrentPage != null)
            {
                if (response.AdditionalData != null)
                {
                    response.Value.AdditionalData = response.AdditionalData;

                    object nextPageLink;
                    response.AdditionalData.TryGetValue("@odata.nextLink", out nextPageLink);

                    var nextPageLinkString = nextPageLink as string;

                    if (!string.IsNullOrEmpty(nextPageLinkString))
                    {
                        response.Value.InitializeNextPageRequest(
                            this.Client,
                            nextPageLinkString);
                    }
                }

                return response.Value;
            }
            */
            return null;
        }
    }

    public interface IEmployeeTimecardRequest
    {

    }
}
