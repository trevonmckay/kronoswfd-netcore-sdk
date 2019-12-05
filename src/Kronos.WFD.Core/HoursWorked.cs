using System;

namespace Kronos.WFD
{
    public class HoursWorked
    {
        public string Id { get; set; }

        public string ItemId { get; set; }

        public bool CommentsAvailable { get; set; }

        public bool SystemGenerated { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public EntityReference OrgJob { get; set; }

        public EntityReference Job { get; set; }

        public EntityReference Employee { get; set; }

        public double DurationInHours { get; set; }

        public EntityReference DataSource { get; set; }

        public EntityReference CostCenter { get; set; }

        public EntityReference WorkRule { get; set; }
    }
}
