using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs.Models
{
    class BinaryQueryFilter : BaseQueryFilter
    {
        public List<BaseQueryFilter> Or { get; set; }

        public List<BaseQueryFilter> And { get; set; }
    }
}
