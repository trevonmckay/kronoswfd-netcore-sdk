using System;

namespace Kronos.WFD
{
    public class EmployeeTimecard
    {
        public TimecardDailyTotalSummary DailyTotalSummary { get; set; }
    }

    public class TimecardDailyTotalSummary
    {
        public DateTime ApplyDate { get; set; }

        public double CumulativeTotal { get; set; }

        public Employee Employee { get; set; }
    }
}
