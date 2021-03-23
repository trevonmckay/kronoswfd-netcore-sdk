using Newtonsoft.Json;
using System;

namespace Kronos.WFD
{
    public class TimecardPunch
    {
        public string Id { get; set; }

        public EntityReference DataSource { get; set; }
        [JsonProperty(PropertyName = "dataSource")]
        public PunchDataSource DataSource { get; set; }

        /// <summary>
        /// Provides the type override object which indicates whether
        /// this punch object is an in punch, out punch, or a break rule.
        /// Break Rule overloads the property.
        /// </summary>
        [JsonProperty(PropertyName = "typeOverride")]
        public PunchTypeOverride TypeOverride { get; set; }

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
    public class PunchDataSource : EntityReference
    {
        public string DisplayName { get; set; }

        public string FunctionalAreaName { get; set; }
    }

    public class PunchTypeOverride : EntityReference
    {
        public string TypeOverrideId { get; set; }

        public string Description { get; set; }
    }
}
