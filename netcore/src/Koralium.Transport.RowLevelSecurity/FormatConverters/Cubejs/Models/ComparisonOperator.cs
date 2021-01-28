using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs.Models
{
    enum ComparisonOperator
    {
        Equals = 0,
        NotEquals = 1,
        Contains = 2,
        NotContains = 3,
        GreaterThan = 4,
        GreaterThanOrEqual = 5,
        LessThan = 6,
        LessThanOrEqual = 7,
        Set = 8,
        NotSet = 9,
        InDateRange = 10,
        NotInDateRange = 11,
        BeforeDate = 12,
        AfterDate = 13
    }
}
