using Newtonsoft.Json;
using System;

namespace Kronos.WFD
{
    public class WorkedShift
    {
        public string Id { get; set; }

        public EntityReference DataSource { get; set; }

        public EntityReference UnscheduledWorkRule { get; set; }

        [JsonProperty(PropertyName = "unscheduledStartDateTime")]
        public DateTime UnscheduledStartDateTime { get; set; }

        [JsonProperty(PropertyName = "unscheduledEndDateTime")]
        public DateTime UnscheduledEndDateTime { get; set; }

        [JsonProperty(PropertyName = "transactionDateTime")]
        public DateTime TransactionDateTime { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public DateTime RoundedStartDateTime { get; set; }

        [JsonProperty(PropertyName = "roundedStartTimezone")]
        public EntityReference RoundedStartTimeZone { get; set; }

        public DateTime RoundedEndDateTime { get; set; }

        [JsonProperty(PropertyName = "roundedEndTimezone")]
        public EntityReference RoundedEndTimeZone { get; set; }

        [JsonProperty(PropertyName = "shiftTotalHours")]
        public double TotalHours { get; set; }

        public bool FromSchedule { get; set; }

        public bool Projected { get; set; }

        public bool InProgress { get; set; }
    }
}
