using System;
using System.Collections.Generic;
using System.Text;

namespace Kronos.WFD
{
    public class HyperfindQuery
    {
        public string Description { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string UsageType { get; set; }

        public HyperfindVisibility Visibility { get; set; }
    }

    public class HyperfindVisibility
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
