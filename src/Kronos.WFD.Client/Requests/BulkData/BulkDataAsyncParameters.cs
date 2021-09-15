using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kronos.WFD.Client.Requests.BulkData
{
    public class BulkDataAsyncParameters
    {
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "payload", NullValueHandling = NullValueHandling.Ignore)]
        public BulkDataPayload Payload { get; set; }

        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }

    public class BulkDataPayload
    {
        [JsonProperty(PropertyName = "select", NullValueHandling = NullValueHandling.Ignore)]
        public List<BulkDataSelect> Select { get; set; }

        [JsonProperty(PropertyName = "from", NullValueHandling = NullValueHandling.Ignore)]
        public BulkDataFrom From { get; set; }

    }

    public class BulkDataSelect
    {
        [JsonProperty(PropertyName = "key", NullValueHandling = NullValueHandling.Ignore)]
        public String Key { get; set; }
    }
    public class BulkDataFrom
    {
        [JsonProperty(PropertyName = "view", NullValueHandling = NullValueHandling.Ignore)]
        public int View { get; set; }

        [JsonProperty(PropertyName = "locationSet", NullValueHandling = NullValueHandling.Ignore)]
        public BulkDataLocationSet LocationSet { get; set; }
        
    }

    public class HyperfindQuery
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public String Id { get; set; }
    }

    public class BulkDataLocationSet
    {
        [JsonProperty(PropertyName = "locations", NullValueHandling = NullValueHandling.Ignore)]
        public BulkDataLocationSetLocations Locations { get; set; }

        [JsonProperty(PropertyName = "dateRange", NullValueHandling = NullValueHandling.Ignore)]
        public BulkDataDateRange DateRange { get; set; }

        [JsonProperty(PropertyName = "hyperfind", NullValueHandling = NullValueHandling.Ignore)]
        public HyperfindQuery Hyperfind { get; set; }
    }

    public class BulkDataLocationSetLocations
    {
        [JsonProperty(PropertyName = "qualifiers", NullValueHandling = NullValueHandling.Ignore)]
        public String Qualifiers { get; set; }
    }
    public class BulkDataDateRange
    {
        [JsonProperty(PropertyName = "startDate", NullValueHandling = NullValueHandling.Ignore)]
        public String StartDate { get; set; }

        [JsonProperty(PropertyName = "endDate", NullValueHandling = NullValueHandling.Ignore)]
        public String EndDate { get; set; }
    }
}
