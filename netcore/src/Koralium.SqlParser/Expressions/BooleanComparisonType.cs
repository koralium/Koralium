using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public enum BooleanComparisonType
    {
        Equals = 0,
        GreaterThan = 1,
        LessThan = 2,
        GreaterThanOrEqualTo = 3,
        LessThanOrEqualTo = 4,
        NotEqualTo = 5
    }
}
