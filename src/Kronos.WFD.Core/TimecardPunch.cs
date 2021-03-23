using Newtonsoft.Json;
using System;

namespace Kronos.WFD
{
    public class TimecardPunch
    {
        public string Id { get; set; }

        /// <summary>
        /// A reference to the data source, if one exists.
        /// Normally, this indicates that the punch came from
        /// a different source, such as a clock, device, or an 
        /// external data source such as an import or interface.
        /// </summary>
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

        /// <summary>
        /// The date and time stamp for the punch in ISO_LOCAL_DATE_TIME.
        /// </summary>
        [JsonProperty(PropertyName = "punchDtm")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The rounded punch date and time.
        /// </summary>
        [JsonProperty(PropertyName = "roundedPunchDtm")]
        public DateTime RoundedTimestamp { get; set; }

        /// <summary>
        /// The date and time stamp for when this punch transaction was entered through the API.
        /// </summary>
        [JsonProperty(PropertyName = "enteredOnDtm")]
        public DateTime EnteredOn { get; set; }

        /// <summary>
        /// The date and time stamp for when this punch transaction was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updatedOnDtm")]
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        /// The date and time stamp for the original punch in ISO_LOCAL_DATE_TIME.
        /// </summary>
        [JsonProperty(PropertyName = "originalPunchDtm")]
        public DateTime OriginalPunchAt { get; set; }

        /// <summary>
        /// The timezone where the punch was entered.
        /// Normally, this is the default or home timezone
        /// for the employee, but the punch can include a
        /// different timezone as necessary.
        /// </summary>
        public EntityReference TimeZone { get; set; }

        public EntityReference OrgJob { get; set; }

        public EntityReference Location { get; set; }

        public bool HasComments { get; set; }

        /// <summary>
        /// A Boolean indicator of whether or not the punch is a phantom punch.
        /// </summary>
        public bool IsPhantom { get; set; }

        public bool Editable { get; set; }

        /// <summary>
        /// A Boolean indicator of whether or not the punch is entered as an Attestation punch edit.
        /// </summary>
        public bool AttestationPunchEdit { get; set; }

        public bool CancelDeduct { get; set; }

        public bool ExceptionResolved { get; set; }

        /// <summary>
        /// A Boolean indicator of whether or not the punch is generated from a scheduled worked span.
        /// </summary>
        public bool IsScheduled { get; set; }

        /// <summary>
        /// A Boolean indicator of whether or not the punch is entered as a timestamp.
        /// </summary>
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
