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
            string responseString = "";
            bool isSuccess = false;
            var noOfTries = 0;
            while(noOfTries < 5 && !isSuccess)
            {
                await Task.Delay(TimeSpan.FromSeconds(90));
                try
                {
                    var response = await this.SendStreamRequestAsync(null, cancellationToken).ConfigureAwait(false);
                    using(StreamReader reader = new StreamReader(response))
                    {
                        responseString = reader.ReadToEnd();
                    }
                    isSuccess = true;
                }
                catch (Exception ex)
                {
                    isSuccess = false;
                    noOfTries += 1;
                    if(noOfTries == 5)
                    {
                        return "Exception Caught: " + ex.Message;
                    }
                }
            }
            return responseString;
        }
    }

    public interface IBulkDataRequest : IBaseRequest
    {
        Task<BulkDataResponseInfo> ReadAsync(BulkDataAsyncParameters parameters, CancellationToken cancellationToken);
        Task<String> ReadAsync(String executionKey, CancellationToken cancellationToken);
    }
}
