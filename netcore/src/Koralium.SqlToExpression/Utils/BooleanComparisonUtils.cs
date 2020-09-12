using Koralium.SqlToExpression.Models;
using System;

namespace Koralium.SqlToExpression.Utils
{
    public static class BooleanComparisonUtils
    {
        public static BooleanComparisonType GetBooleanComparisonType(string text)
        {
            switch (text)
            {
                case "=":
                    return BooleanComparisonType.Equals;
                case ">":
                    return BooleanComparisonType.GreaterThan;
                case ">=":
                    return BooleanComparisonType.GreaterThanOrEqualTo;
                case "<":
                    return BooleanComparisonType.LessThan;
                case "<=":
                    return BooleanComparisonType.LessThanOrEqualTo;
                case "<>":
                    return BooleanComparisonType.NotEqualToBrackets;
                case "!=":
                    return BooleanComparisonType.NotEqualToExclamation;
                case "!>":
                    return BooleanComparisonType.NotGreaterThan;
                case "!<":
                    return BooleanComparisonType.NotLessThan;
                default:
                    throw new NotSupportedException($"The comparison operator {text} is not supported");
            }
        }
    }
}
