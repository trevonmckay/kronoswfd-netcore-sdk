namespace Kronos.WFD.Client.Requests
{
    public class BaseRequestBuilder : IBaseRequestBuilder
    {
        public IBaseClient Client { get; private set; }

        public string RequestUrl { get; internal set; }

        public BaseRequestBuilder(string requestUrl, IBaseClient client)
        {
            Client = client;
            RequestUrl = requestUrl;
        }

        public string AppendSegmentToRequestUrl(string urlSegment)
        {
            return string.Format("{0}/{1}", this.RequestUrl.TrimEnd('/'), urlSegment);
        }
    }

    public interface IBaseRequestBuilder
    {
        /// <summary>
        /// Gets the <see cref="IBaseClient"/> for handling requests.
        /// </summary>
        IBaseClient Client { get; }

        /// <summary>
        /// Gets the URL for the built request, without query string.
        /// </summary>
        string RequestUrl { get; }

        /// <summary>
        /// Gets a URL that is the request builder's request URL with the segment appended.
        /// </summary>
        /// <param name="urlSegment">The segment to append to the request URL.</param>
        /// <returns>A URL that is the request builder's request URL with the segment appended.</returns>
        string AppendSegmentToRequestUrl(string urlSegment);
    }
}
