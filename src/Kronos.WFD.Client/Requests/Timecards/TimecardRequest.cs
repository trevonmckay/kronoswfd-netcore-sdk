using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kronos.WFD.Client.Requests
{
    internal class TimecardRequest : BaseRequest, ITimecardRequest
    {
        public TimecardRequest(
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
        public async Task<EmployeeTimecard> GetAsync(CancellationToken cancellationToken)
        {
            this.Method = "GET";
            var retrievedEntity = await this.SendAsync<EmployeeTimecard>(null, cancellationToken).ConfigureAwait(false);
            return retrievedEntity;
        }

        /// <summary>
        /// Issues the GET request.
        /// </summary>
        public Task<EmployeeTimecard> GetAsync()
        {
            return this.GetAsync(CancellationToken.None);
        }

        public ITimecardRequest From(DateTime startDate)
        {
            this.AddQueryOption("start_date", startDate.ToString("yyyy-MM-dd"));
            return this;
        }

        public ITimecardRequest To(DateTime endDate)
        {
            this.AddQueryOption("end_date", endDate.ToString("yyyy-MM-dd"));
            return this;
        }

        public ITimecardRequest Select(string select)
        {
            this.AddQueryOption("select", select);
            return this;
        }
    }

    public interface ITimecardRequest
    {
        Task<EmployeeTimecard> GetAsync(CancellationToken cancellationToken);

        Task<EmployeeTimecard> GetAsync();

        ITimecardRequest From(DateTime startDate);

        ITimecardRequest To(DateTime endDate);

        ITimecardRequest Select(string select);
    }
}
