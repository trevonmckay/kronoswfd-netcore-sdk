using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    /// <summary>
    /// The error response object from the service on an unsuccessful call.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ErrorResponse
    {
        /// <summary>
        /// The <see cref="Error"/> returned by the service.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public Error Error { get; set; }

        /// <summary>
        /// Additional data returned in the call.
        /// </summary>
        [JsonExtensionData(ReadData = true)]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
