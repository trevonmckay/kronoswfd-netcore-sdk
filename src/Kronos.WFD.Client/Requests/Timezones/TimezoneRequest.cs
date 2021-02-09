using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kronos.WFD.Client.Requests
{
    internal class TimezoneRequest : BaseRequest, ITimezoneRequest
    {
        public TimezoneRequest(
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
        public async Task<Timezones> GetAsync(CancellationToken cancellationToken)
        {
            this.Method = "GET";
            var retrievedEntity = await this.SendAsync<Timezones>(null, cancellationToken).ConfigureAwait(false);
            return retrievedEntity;
        }

        /// <summary>
        /// Issues the GET request.
        /// </summary>
        public Task<Timezones> GetAsync()
        {
            return this.GetAsync(CancellationToken.None);
        }

        public ITimezoneRequest PersonNumber(string personNumber)
        {
            this.AddQueryOption("person_number", personNumber);
            return this;
        }

        // Add Name, EmployeeId ...
    }

    public interface ITimezoneRequest
    {
        Task<Timezones> GetAsync(CancellationToken cancellationToken);

        Task<Timezones> GetAsync();

        ITimezoneRequest PersonNumber(string personNumber);
    }
}
