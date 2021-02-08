using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kronos.WFD.Client.Requests
{
    internal class SchedulesRequest : BaseRequest, ISchedulesRequest
    {
        public SchedulesRequest(string requestUrl, IBaseClient client, IEnumerable<Option> options = null)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Issues the GET request.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await for async call.</returns>
        public async Task<Schedule> ReadAsync(SchedulesMultiReadParameters parameters, CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "POST";
            this.AppendSegmentToRequestUrl("multi_read");
            Console.WriteLine();
            var response = await this.SendAsync<Schedule>(parameters, cancellationToken).ConfigureAwait(false);
            
            if (response != null)
            {
                return response;
            }
            return null;
        }

        public async Task<Schedule> ReadAsync(SchedulesMultiReadParameters parameters)
        {
            return await this.ReadAsync(parameters, CancellationToken.None);
        }
    }

    public interface ISchedulesRequest : IBaseRequest
    {
        Task<Schedule> ReadAsync(SchedulesMultiReadParameters parameters, CancellationToken cancellationToken);

        Task<Schedule> ReadAsync(SchedulesMultiReadParameters parameters);
    }
}
