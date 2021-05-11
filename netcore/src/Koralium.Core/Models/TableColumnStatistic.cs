using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Models
{
    public class TableColumnStatistic
    {
        public string ColumnName { get; set; }

        public double NullsFraction { get; set; }

        public long DistinctCount { get; set; }

        public double? LowValue { get; set; }

        public double? HighValue { get; set; }
    }
}
