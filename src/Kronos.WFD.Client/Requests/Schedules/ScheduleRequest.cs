using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kronos.WFD.Client.Requests
{
    internal class ScheduleRequest : BaseRequest, IScheduleRequest
    {
        public ScheduleRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Issues the GET request.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await for async call.</returns>
        public async Task<Schedule> GetAsync(CancellationToken cancellationToken)
        {
            this.Method = "GET";
            var retrievedEntity = await this.SendAsync<Schedule>(null, cancellationToken).ConfigureAwait(false);
            return retrievedEntity;
        }

        /// <summary>
        /// Issues the GET request.
        /// </summary>
        public Task<Schedule> GetAsync()
        {
            return this.GetAsync(CancellationToken.None);
        }

        public IScheduleRequest From(DateTime startDate)
        {
            this.AddQueryOption("start_date", startDate.ToString("yyyy-MM-dd"));
            return this;
        }

        public IScheduleRequest To(DateTime endDate)
        {
            this.AddQueryOption("end_date", endDate.ToString("yyyy-MM-dd"));
            return this;
        }

        public IScheduleRequest Select(string select)
        {
            this.AddQueryOption("select", select);
            return this;
        }
    }

    public interface IScheduleRequest
    {
        Task<Schedule> GetAsync(CancellationToken cancellationToken);

        Task<Schedule> GetAsync();

        IScheduleRequest From(DateTime startDate);

        IScheduleRequest To(DateTime endDate);

        IScheduleRequest Select(string select);
    }
}
