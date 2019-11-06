using Kronos.WFD.Client.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [JsonConverter(typeof(DerivedTypeConverter))]
    public class LocationsCollectionResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "value", Required = Newtonsoft.Json.Required.Default)]
        public LocationsCollectionPage Value { get; set; }

        [JsonExtensionData(ReadData = true)]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
