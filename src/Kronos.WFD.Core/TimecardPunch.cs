using Newtonsoft.Json;
using System;

namespace Kronos.WFD
{
    public class TimecardPunch
    {
        public string Id { get; set; }

        public EntityReference DataSource { get; set; }

        public Employee Employee { get; set; }

        [JsonProperty(PropertyName = "punchDtm")]
        public DateTime Timestamp { get; set; }

        [JsonProperty(PropertyName = "roundedPuchDtm")]
        public DateTime RoundedTimestamp { get; set; }

        [JsonProperty(PropertyName = "enteredOnDtm")]
        public DateTime EnteredOn { get; set; }

        [JsonProperty(PropertyName = "updatedOnDtm")]
        public DateTime UpdatedOn { get; set; }

        public EntityReference TimeZone { get; set; }

        public EntityReference OrgJob { get; set; }

        public EntityReference Location { get; set; }

        public bool HasComments { get; set; }

        public bool IsPhantom { get; set; }

        public bool IsScheduled { get; set; }

        public bool ValidateAsTimestamp { get; set; }
    }
}
