using Kronos.WFD.Client.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    /// <summary>
    /// The type HyperfindQueriesCollectionResponse.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [JsonConverter(typeof(DerivedTypeConverter))]
    public class HyperfindQueriesCollectionResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "hyperfindQueries", Required = Newtonsoft.Json.Required.Default)]
        public HyperfindQueriesCollectionPage Value { get; set; }

        [JsonExtensionData(ReadData = true)]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
