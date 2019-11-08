using Newtonsoft.Json;
using System;

namespace Kronos.WFD
{
    public class TimecardPunch
    {
        public string Id { get; set; }

        public Employee Employee { get; set; }

        [JsonProperty(PropertyName = "punchDtm")]
        public DateTime Timestamp { get; set; }

        [JsonProperty(PropertyName = "roundedPuchDtm")]
        public DateTime RoundedTimestamp { get; set; }

        [JsonProperty(PropertyName = "enteredOnDtm")]
        public DateTime RecordedAt { get; set; }

        public TimeZone TimeZone { get; set; }

        public bool HasComments { get; set; }

        public bool IsPhantom { get; set; }

        public bool IsScheduled { get; set; }
    }
}
