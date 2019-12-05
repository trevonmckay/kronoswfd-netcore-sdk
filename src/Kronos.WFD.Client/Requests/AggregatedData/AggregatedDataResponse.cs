using Kronos.WFD.Client.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [JsonConverter(typeof(DerivedTypeConverter))]
    public class AggregatedDataResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "data", Required = Newtonsoft.Json.Required.Default)]
        public AggregatedDataPage Value { get; set; }

        [JsonExtensionData(ReadData = true)]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
