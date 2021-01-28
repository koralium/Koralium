using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs.Models
{
    class QueryFilter : BaseQueryFilter
    {
        public string Member { get; set; }

        public ComparisonOperator Operator { get; set; }

        public List<string> Values { get; set; }
    }
}
