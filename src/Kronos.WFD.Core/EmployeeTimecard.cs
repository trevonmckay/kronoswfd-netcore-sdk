using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Kronos.WFD
{
    public class EmployeeTimecard
    {
        public IDictionary<string, object> AdditionalData { get; set; }

        public Employee Employee { get; set; }

        public DateTime StartDate { get; set; }

        public IEnumerable<TimecardDailyTotalSummary> DailyTotalSummary { get; set; }

        public IEnumerable<TimecardPunch> Punches { get; set; }

        public IEnumerable<TimecardTotals> Totals { get; set; }
    }

    public class TimecardDailyTotalSummary
    {
        public DateTime ApplyDate { get; set; }

        public Employee Employee { get; set; }

        public double CumulativeTotal { get; set; }

        public IDictionary<string, double> DailyTotalAmount { get; set; }

        public IDictionary<string, IEnumerable<HoursCostSummary>> HoursAndCostSummaries { get; set; }
    }

    public class HoursCostSummary
    {
        public string Id { get; set; }

        public double DurationInHours { get; set; }

        public double Wages { get; set; }

        public double DurationInDays { get; set; }

        public Employee Employee { get; set; }

        public DateTime ApplyDate { get; set; }

        public string AmountType { get; set; }
    }

    public class TimecardTotals
    {
        public EmployeeContext EmployeeContext { get; set; }

        public IEnumerable<AggregatedTotal> AggregatedTotals { get; set; }
    }

    public class EmployeeContext
    {
        public Employee Employee { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public TimeZone TimeZone { get; set; }
    }

    public class AggregatedTotal
    {
        public string AmountType { get; set; }

        public Employee Employee { get; set; }

        public Location Location { get; set; }

        public Job Job { get; set; }

        public CostCenter CostCenter { get; set; }

        public PayCode PayCode { get; set; }

        public double Amount { get; set; }

        public double Wages { get; set; }

        public bool JobTransfer { get; set; }

        public bool LaborCategoryTransfer { get; set; }
    }
}
