using Newtonsoft.Json;

namespace Kronos.WFD
{
    public class Employee
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "qualifier")]
        public string Qualifier { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
