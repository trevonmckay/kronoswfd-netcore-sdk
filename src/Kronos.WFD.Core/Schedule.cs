using Kronos.WFD;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kronos.WFD
{
    public class Schedule                                                       
    {                              
        public IEnumerable<ScheduleShifts> Shifts;                             
    }

    public class ScheduleShift
    {
        public bool Posted { get; set; }
        public DateTime StartDateTime { get; set; }
        public bool SelfServiced { get; set; }
        public IEnumerable<ScheduleSegments> Segments { get; set; }
        public bool PostedNotified { get; set; }
        public bool PostedNotificationPending { get; set; }
        public bool Deleted { get; set; }
        public bool Open { get; set; }
        public bool Locked { get; set; }
        public string Label { get; set; }
        public string Id { get; set; }
        public bool Generated { get; set; }
        public string EndDateTime { get; set; }
        public Employee Employee { get; set; }
    }

    public class ScheduleSegments
    {
        public bool UserEnteredWorkrule { get; set; }
        public bool UserEnteredOrgJob { get; set; }
        public bool UserEnteredCostCenter { get; set; }
        public bool TransferWorkrule { get; set; }
        public string TransferString { get; set; }
        public bool TransferOrgJob;
        public bool TransferLaborCategories { get; set; }
        public bool TransferCostCategories { get; set; }
        public string StartDateTime { get; set; }
        public EntityReference OrgJobRef { get; set; }
        public string Id { get; set; }
        public string EndDateTime { get; set; }
    }
}
