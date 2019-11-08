using Kronos.WFD.Client.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    public class TimecardsMultiReadParameters
    {
        [JsonProperty(PropertyName = "multiReadOptions", NullValueHandling = NullValueHandling.Ignore)]
        public MultiReadOptions MultiReadOptions { get; set; }

        [JsonProperty(PropertyName = "orderBy", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> OrderBy { get; set; }

        [JsonProperty(PropertyName = "select", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Select { get; set; }

        [JsonProperty(PropertyName = "where", NullValueHandling = NullValueHandling.Ignore)]
        public WhereClause Where { get; set; }
    }

    public class MultiReadOptions
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ExceptionOptions ExceptionOptions { get; set; }
    }

    public class ExceptionOptions
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool IncludeJustifications { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool IncludeJustifiedTimes { get; set; }
    }

    public class WhereClause
    {
        [JsonProperty(PropertyName = "dateRange", NullValueHandling = NullValueHandling.Ignore)]
        public QueryableDateRange DateRange { get; set; }

        [JsonProperty(PropertyName = "employees", NullValueHandling = NullValueHandling.Ignore)]
        public EmployeesQueryParameters Employees { get; set; }

        [JsonProperty(PropertyName = "hyperFind", NullValueHandling = NullValueHandling.Ignore)]
        public HyperfindLookupParameters HyperFind { get; set; }
    }

    public class QueryableDateRange
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime? EndDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime? StartDate { get; set; }
    }

    public class HyperfindLookupParameters
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "qualifier", NullValueHandling = NullValueHandling.Ignore)]
        public string Qualifier { get; set; }
    }

    public class EmployeesQueryParameters
    {
        [JsonProperty(PropertyName = "ids", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Ids { get; set; }

        [JsonProperty(PropertyName = "qualifiers", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Qualifiers { get; set; }
    }
}
