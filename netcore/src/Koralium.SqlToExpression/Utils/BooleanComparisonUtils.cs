/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
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
