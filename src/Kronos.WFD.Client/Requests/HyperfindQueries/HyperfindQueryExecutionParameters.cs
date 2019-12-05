using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    public class HyperfindQueryExecutionParameters
    {
        [JsonIgnore]
        public const int MaxThreshold = 50000;

        [JsonProperty(PropertyName = "dateRange", NullValueHandling = NullValueHandling.Ignore)]
        public QueryableDateRange DateRange { get; set; }

        [JsonProperty(PropertyName = "hyperfind", NullValueHandling = NullValueHandling.Ignore)]
        public HyperfindLookupParameters Hyperfind { get; set; }

        [JsonProperty(PropertyName = "locations", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<HyperfindLocationParameters> Locations { get; set; }

        [JsonProperty(PropertyName = "isEmployee")]
        public bool IsEmployee { get; set; }

        [JsonProperty(PropertyName = "threshold", NullValueHandling = NullValueHandling.Ignore)]
        public int? Threshold { get; set; }
    }

    public class HyperfindLocationParameters
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "qualifier", NullValueHandling = NullValueHandling.Ignore)]
        public string Qualifier { get; set; }
    }
}
