using Kronos.WFD.Client.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    public class LocationsMultiReadParameters
    {
        [JsonProperty(PropertyName = "where", NullValueHandling = NullValueHandling.Ignore)]
        public LocationsWhereClause Where { get; set; }
    }

    public class LocationsWhereClause
    {
        [JsonProperty(PropertyName = "childrenOf", NullValueHandling = NullValueHandling.Ignore)]
        public LocationsChildrenOfClause ChildrenOf { get; set; }

        [JsonProperty(PropertyName = "descendantsOf", NullValueHandling = NullValueHandling.Ignore)]
        public LocationsDescendantsOfClause DescendantsOf { get; set; }
    }

    public class LocationsChildrenOfClause
    {
        [JsonProperty(PropertyName = "context", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public LocationContext Context { get; set; }

        [JsonProperty(PropertyName = "date", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "locationRef", NullValueHandling = NullValueHandling.Ignore)]
        public LocationReference LocationReference { get; set; }

        [JsonProperty(PropertyName = "includeLocationTypes", NullValueHandling = NullValueHandling.Ignore)]
        public LocationTypesSelector IncludeLocationTypes { get; set; }
    }

    public class LocationsDescendantsOfClause
    {
        [JsonProperty(PropertyName = "context", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public LocationContext Context { get; set; }

        [JsonProperty(PropertyName = "date", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "locationRef", NullValueHandling = NullValueHandling.Ignore)]
        public LocationReference LocationReference { get; set; }

        [JsonProperty(PropertyName = "includeLocationTypes", NullValueHandling = NullValueHandling.Ignore)]
        public LocationTypesSelector IncludeLocationTypes { get; set; }
    }

    public class LocationTypesSelector
    {
        [JsonProperty(PropertyName = "ids", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Ids { get; set; }

        [JsonProperty(PropertyName = "qualifiers", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Qualifiers { get; set; }
    }
}
