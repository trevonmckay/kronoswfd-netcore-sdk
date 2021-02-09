using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Kronos.WFD
{
    public class Timezones
    {
        public string DisplayName { get; set; }
        
        public string Guide { get; set; }
        
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string OffsetMinutes { get; set; }

        public string TenantDefault { get; set; }
    }

    public class Timezone
    {
        public string EndDay { get; set; }
        
        public string EndDayOfWeek { get; set; }
        
        public string EndMonth { get; set; }
        
        public string EndTime { get; set; }
        
        public string Id { get; set; }
        
        public string RawOffset { get; set; }
        
        public string StartDay { get; set; }
        
        public string StartDayOfWeek { get; set; }
        
        public string StartMonth { get; set; }
        
        public string StartTime { get; set; }
    }
}
