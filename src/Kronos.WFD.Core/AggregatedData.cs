using Kronos.WFD.Serializers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kronos.WFD
{
    public enum DataAttributeOperation
    {
        [EnumMember(Value = "SUM")]
        Sum,

        [EnumMember(Value = "AVG")]
        Average,

        [EnumMember(Value = "MIN")]
        Minimum,

        [EnumMember(Value = "MAX")]
        Maximum,

        [EnumMember(Value = "COUNT")]
        Count
    }

    public class AggregatedData
    {
        public IEnumerable<DataAttribute> Attributes { get; set; }

        public IEnumerable<AggregatedData> Children { get; set; }

        public IDictionary<string, object> CoreEntityKey { get; set; }

        public IDictionary<string, object> CustomProperties { get; set; }

        public IDictionary<string, object> Key { get; set; }

        public DataRootEntity RootEntity { get; set; }

        public IEnumerable<DataSummaryListDisplay> SummaryListDisplay { get; set; }
    }

    public class DataAttribute
    {
        public string Alias { get; set; }

        public string Key { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DataAttributeOperation Operation { get; set; }

        public object RawValue { get; set; }

        public object Value { get; set; }
    }

    [JsonConverter(typeof(DataRootEntityConverter))]
    public class DataRootEntity
    {
        public bool Composed { get; set; }

        public string Name { get; set; }
    }

    public class DataSummaryListDisplay
    {
        public string Average { get; set; }

        public int Count { get; set; }

        public string Key { get; set; }

        public string Max { get; set; }

        public string Min { get; set; }

        public string Sum { get; set; }
    }
}
