using Kronos.WFD.Client.Requests;
using Kronos.WFD.Client.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Kronos.WFD.Client.Requests
{
    public class SchedulesMultiReadParameters
    {
        [JsonProperty(PropertyName = "multiReadOptions", NullValueHandling = NullValueHandling.Ignore)]
        public MultiReadOptions MultiReadOptions { get; set; }

        [JsonProperty(PropertyName = "orderBy", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> OrderBy { get; set; }

        [JsonProperty(PropertyName = "select", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Select { get; set; }

        [JsonProperty(PropertyName = "where", NullValueHandling = NullValueHandling.Ignore)]
        public SchedulesWhereClause Where { get; set; }
    }
    public class SchedulesWhereClause
    {
        [JsonProperty(PropertyName = "employees", NullValueHandling = NullValueHandling.Ignore)]
        public QueryableEmployee Employees { get; set; }

        [JsonProperty(PropertyName = "hyperFind", NullValueHandling = NullValueHandling.Ignore)]
        public HyperfindQueryParameters HyperFind { get; set; }

        [JsonProperty(PropertyName = "locations", NullValueHandling = NullValueHandling.Ignore)]
        public LocationQueryParameters Location { get; set; }
    }
    public class HyperfindQueryParameters
    {
        [JsonProperty(PropertyName ="dateRange", NullValueHandling = NullValueHandling.Ignore)]
        public QueryableDateRange DateRange { get; set; }

        [JsonProperty(PropertyName = "hyperFind", NullValueHandling = NullValueHandling.Ignore)]
        public HyperfindLookupParameters HyperFind { get; set; }
    }
    public class LocationQueryParameters
    {
        [JsonProperty(PropertyName = "dateRange", NullValueHandling = NullValueHandling.Ignore)]
        public QueryableDateRange DateRange { get; set; }

        [JsonProperty(PropertyName = "locations", NullValueHandling = NullValueHandling.Ignore)]
        public QueryableLocation Locations {get; set;}
    }

    public class QueryableLocation
{
        [JsonProperty(PropertyName ="ids", NullValueHandling=NullValueHandling.Ignore)]
        public IEnumerable<string> Ids { get; set; }

        [JsonProperty(PropertyName ="qualifiers", NullValueHandling=NullValueHandling.Ignore)]
        public IEnumerable<string> qualifiers { get; set; }
    }
    public class QueryableEmployee
    {
        [JsonProperty(PropertyName = "dateRange", NullValueHandling = NullValueHandling.Ignore)]
        public QueryableDateRange DateRange { get; set; }

        [JsonProperty(PropertyName = "employees", NullValueHandling = NullValueHandling.Ignore)]
        public EmployeesQueryParameters Employees { get; set; }
    }
}
