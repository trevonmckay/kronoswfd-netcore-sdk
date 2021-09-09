using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kronos.WFD.Client.Requests.BulkData
{
    internal class BulkDataRequest : BaseRequest, IBulkDataRequest
    {
        public BulkDataRequest(string requestUrl, IBaseClient client, IEnumerable<Option> options = null) : base(requestUrl, client, options)
        {
        }

        public async Task<BulkDataResponseInfo> ReadAsync(BulkDataAsyncParameters parameters, CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "POST";
            this.AppendSegmentToRequestUrl("async");
            Console.WriteLine();
            var response = await this.SendAsync<BulkDataResponseInfo>(parameters, cancellationToken).ConfigureAwait(false);

            if(response != null)
            {
                return response;
            }
            return null;
        }

        public async Task<String> ReadAsync(String executionKey, CancellationToken cancellationToken)
        {
            this.ContentType = "text/csv";
            this.Method = "GET";
            this.AppendSegmentToRequestUrl(executionKey);
            this.AppendSegmentToRequestUrl("file");
            Console.WriteLine();
            var response = await this.SendStreamRequestAsync(null, cancellationToken).ConfigureAwait(false);

            StreamReader reader = new StreamReader(response);
            string responseString = reader.ReadToEnd();

            if (response != null)
            {
                return responseString;
            }

            return null;
        }
    }

    public interface IBulkDataRequest : IBaseRequest
    {
        Task<BulkDataResponseInfo> ReadAsync(BulkDataAsyncParameters parameters, CancellationToken cancellationToken);
        Task<String> ReadAsync(String executionKey, CancellationToken cancellationToken);
    }
}
