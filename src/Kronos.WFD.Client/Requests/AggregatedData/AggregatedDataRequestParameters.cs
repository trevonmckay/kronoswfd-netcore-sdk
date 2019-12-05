using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kronos.WFD.Client.Requests
{
    public enum DataSourceView
    {
        [EnumMember(Value = "EMP")]
        Employee = 0,

        [EnumMember(Value = "ORGANIZATION")]
        Organization = 1
    }

    public class AggregatedDataRequestParameters
    {
        /// <summary>
        /// The count of data (rows) per page
        /// </summary>
        [JsonProperty(PropertyName = "count", NullValueHandling = NullValueHandling.Ignore)]
        public int? Count { get; set; }

        /// <summary>
        /// The index of the page to retrieve
        /// </summary>
        [JsonProperty(PropertyName = "index", NullValueHandling = NullValueHandling.Ignore)]
        public int Index { get; set; } = 0;

        [JsonProperty(PropertyName = "from", NullValueHandling = NullValueHandling.Ignore)]
        public AggregatedDataRequestFromParameters From { get; set; }

        [JsonProperty(PropertyName = "options", NullValueHandling = NullValueHandling.Ignore)]
        public AggregatedDataRequestOptions Options { get; set; }

        [JsonProperty(PropertyName = "where", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<AggregatedDataRequestWhereParameters> Where { get; set; }

        [JsonProperty(PropertyName = "select", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<AggregatedDataRequestSelectParameter> Select { get; set; }
    }

    public class AggregatedDataRequestOptions
    {
        [JsonProperty(PropertyName = "metadatakey", NullValueHandling = NullValueHandling.Ignore)]
        public string MetadataKey { get; set; }

        public bool Refresh { get; set; }

        [JsonProperty(PropertyName = "requestTag", NullValueHandling = NullValueHandling.Ignore)]
        public string RequestTag { get; set; }

        [JsonProperty(PropertyName = "secondaryRequestTag", NullValueHandling = NullValueHandling.Ignore)]
        public string SecondaryRequestTag { get; set; }
    }

    public class AggregatedDataRequestFromParameters
    {
        /// <summary>
        /// Specifies the data source
        /// </summary>
        public DataSourceView View { get; set; }

        [JsonProperty(PropertyName = "employeeSet", NullValueHandling = NullValueHandling.Ignore)]
        public AggregatedDataRequestEmployeeSet EmployeeSet { get; set; }

        [JsonProperty(PropertyName = "locationSet", NullValueHandling = NullValueHandling.Ignore)]
        public AggregatedDataRequestLocationSet LocationSet { get; set; }
    }

    public class AggregatedDataRequestWhereParameters
    {
        [JsonProperty(PropertyName = "alias", NullValueHandling = NullValueHandling.Ignore)]
        public string Alias { get; set; }

        [JsonProperty(PropertyName = "key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "operator", NullValueHandling = NullValueHandling.Ignore)]
        public string Operator { get; set; }

        [JsonProperty(PropertyName = "values", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Values { get; set; }
    }

    public class AggregatedDataRequestEmployeeSet
    {
        [JsonProperty(PropertyName = "dateRange", NullValueHandling = NullValueHandling.Ignore)]
        public QueryableDateRange DateRange { get; set; }
    }

    public class AggregatedDataRequestLocationSet
    {
        [JsonProperty(PropertyName = "dateRange", NullValueHandling = NullValueHandling.Ignore)]
        public QueryableDateRange DateRange { get; set; }

        [JsonProperty(PropertyName = "locations", NullValueHandling = NullValueHandling.Ignore)]
        public LocationSetLocationParameters Locations { get; set; }
    }

    public class LocationSetLocationParameters
    {
        public IEnumerable<string> Ids { get; set; }

        public IEnumerable<string> Qualifiers { get; set; }

        public IEnumerable<LocationReference> Refs { get; set; }
    }

    public class AggregatedDataRequestSelectParameter
    {
        [JsonProperty(PropertyName = "alias")]
        public string Alias { get; set; }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        public AggregatedDataRequestSelectParameter() { }

        public AggregatedDataRequestSelectParameter(string key, string alias = null)
        {
            Key = key;
            Alias = alias;
        }
    }
}
