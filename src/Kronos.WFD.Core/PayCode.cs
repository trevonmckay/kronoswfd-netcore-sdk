using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Kronos.WFD
{
    public enum PayCodeUnit
    {
        [EnumMember(Value = "HOUR")]
        Hour,

        [EnumMember(Value = "MONEY")]
        Money,

        [EnumMember(Value = "DAY")]
        Day
    }

    public class PayCode
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public int CheckAvailability { get; set; }

        public bool Combined { get; set; }

        public int CodeNumber { get; set; }

        public bool ExcusedAbsence { get; set; }

        public bool AddToTimecardTotal { get; set; }

        public bool Money { get; set; }

        public bool Totals { get; set; }

        public string Type { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PayCodeUnit Unit { get; set; }

        public bool VisibleToUser { get; set; }

        public bool VisibleToTimecardSchedule { get; set; }

        public bool VisibleToReports { get; set; }

        public double WageAddition { get; set; }

        public double WageMultiplier { get; set; }
    }

    public class PayCodeReference
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Qualifier { get; set; }
    }
}
