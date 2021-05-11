using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Models
{
    public class TableStatistic
    {
        public string TableName { get; set; }

        public long RowCount { get; set; }

        public List<TableColumnStatistic> Columns { get; set; }
    }
}
