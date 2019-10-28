using System;
using System.Collections.Generic;

namespace Kronos.WFD
{
    public class EmployeeTimecardBulkRequest
    {
        public MultiReadOptions MultiReadOptions { get; set; }

        public IEnumerable<string> OrderBy { get; set; }

        public IEnumerable<string> Select { get; set; }

        public WhereClause Where { get; set; }
    }

    public class MultiReadOptions
    {
        public ExceptionOptions ExceptionOptions { get; set; }
    }

    public class ExceptionOptions
    {
        public bool IncludeJustifications { get; set; }

        public bool IncludeJustifiedTimes { get; set; }
    }

    public class WhereClause
    {
        public QueryableDateRange DateRange { get; set; }
    }

    public class QueryableDateRange
    {
        public DateTime? EndDate { get; set; }

        public DateTime? StartDate { get; set; }
    }
}
