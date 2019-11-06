using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kronos.WFD.Client.Requests
{
    public class TimecardsRequest : BaseRequest, ITimecardsRequest
    {
        private readonly EmployeeTimecardsMultiReadParameters _parameters;

        public TimecardsRequest(
            EmployeeTimecardsMultiReadParameters parameters,
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base (requestUrl, client, options)
        {
            _parameters = parameters;
        }

        public async Task<TimecardsCollectionResponse> PostAsync(CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "POST";
            var executionResult = await this.SendAsync<TimecardsCollectionResponse>(_parameters, cancellationToken).ConfigureAwait(false);
            return executionResult;
        }

        public async Task<TimecardsCollectionResponse> PostAsync()
        {
            return await PostAsync(CancellationToken.None);
        }
    }

    public interface ITimecardsRequest
    {
        Task<TimecardsCollectionResponse> PostAsync(CancellationToken cancellationToken);

        Task<TimecardsCollectionResponse> PostAsync();
    }
}
