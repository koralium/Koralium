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
using Koralium.SqlParser.Literals;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Koralium.SqlParser
{
    internal static class FilterUtils
    {

        /// <summary>
        /// Converts the current boolean comparison type based on the comparison value.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        private static Expressions.BooleanComparisonType ConvertBooleanComparisonType(Expressions.BooleanComparisonType type, long val)
        {
            if(val == 0)
            {
                return type;
            }
            if(val == -1)
            {
                switch (type)
                {
                    //compareTo == -1 is v1 < v2
                    case Expressions.BooleanComparisonType.Equals:
                        return Expressions.BooleanComparisonType.LessThan;
                    //compareTo != -1 is v1 >= v2
                    case Expressions.BooleanComparisonType.NotEqualTo:
                        return Expressions.BooleanComparisonType.GreaterThanOrEqualTo;
                    //compareTo > -1 is v1 >= v2
                    case Expressions.BooleanComparisonType.GreaterThan:
                        return Expressions.BooleanComparisonType.GreaterThanOrEqualTo;
                    //compareTo >= -1 is always true since it hits -1 0 1
                    case Expressions.BooleanComparisonType.GreaterThanOrEqualTo:
                        //always true?
                        //TODO
                        throw new Exception("Found a string compareTo that is always true");
                    //compareTo < -1 is always false, it never hits -1 0 1
                    case Expressions.BooleanComparisonType.LessThan:
                        //always false, throw exception?
                        throw new Exception("Found a string compareTo that is always false");
                    //compareTo <= -1 hits -1, is v1 < v2
                    case Expressions.BooleanComparisonType.LessThanOrEqualTo:
                        return Expressions.BooleanComparisonType.LessThan;
                }
            }
            else if(val == 1)
            {
                switch (type)
                {
                    //compareTo == 1 is v1 > v2
                    case Expressions.BooleanComparisonType.Equals:
                        return Expressions.BooleanComparisonType.GreaterThan;
                    //compareTo != 1 is v1 <= v2
                    case Expressions.BooleanComparisonType.NotEqualTo:
                        return Expressions.BooleanComparisonType.LessThanOrEqualTo;
                    //compareTo > 1 is is always false
                    case Expressions.BooleanComparisonType.GreaterThan:
                        throw new Exception("Found a string compareTo that is always false");
                        break;
                    //compareTo >= 1 is v1 > v2
                    case Expressions.BooleanComparisonType.GreaterThanOrEqualTo:
                        return Expressions.BooleanComparisonType.GreaterThan;
                    //compareTo < 1 is v1 <= v2
                    case Expressions.BooleanComparisonType.LessThan:
                        return Expressions.BooleanComparisonType.LessThanOrEqualTo;
                    //compareTo <= 1 is always true
                    case Expressions.BooleanComparisonType.LessThanOrEqualTo:
                        //always true
                        //TODO
                        throw new Exception("Found a string compareTo that is always true");
                }
            }

            //TODO: fix exception
            throw new Exception("Only use values 0, 1, -1 when comparing strings in compareTo.");
        }

        public static Expressions.BooleanComparisonType ConvertNot(Expressions.BooleanComparisonType booleanComparisonType, bool isNot)
        {
            if (!isNot)
            {
                return booleanComparisonType;
            }
            else
            {
                //Convert rules according to DeMorgans law
                switch (booleanComparisonType)
                {
                    case Expressions.BooleanComparisonType.Equals:
                        return Expressions.BooleanComparisonType.NotEqualTo;
                    case Expressions.BooleanComparisonType.NotEqualTo:
                        return Expressions.BooleanComparisonType.Equals;
                    case Expressions.BooleanComparisonType.GreaterThan:
                        return Expressions.BooleanComparisonType.LessThanOrEqualTo;
                    case Expressions.BooleanComparisonType.GreaterThanOrEqualTo:
                        return Expressions.BooleanComparisonType.LessThan;
                    case Expressions.BooleanComparisonType.LessThan:
                        return Expressions.BooleanComparisonType.GreaterThanOrEqualTo;
                    case Expressions.BooleanComparisonType.LessThanOrEqualTo:
                        return Expressions.BooleanComparisonType.GreaterThan;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static Expressions.BooleanComparisonType ParseBooleanComparisonType(ExpressionType expressionType)
        {
            Expressions.BooleanComparisonType booleanComparisonType;
            switch (expressionType)
            {
                case ExpressionType.Equal:
                    booleanComparisonType = Expressions.BooleanComparisonType.Equals;
                    break;
                case ExpressionType.NotEqual:
                    booleanComparisonType = Expressions.BooleanComparisonType.NotEqualTo;
                    break;
                case ExpressionType.GreaterThan:
                    booleanComparisonType = Expressions.BooleanComparisonType.GreaterThan;
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    booleanComparisonType = Expressions.BooleanComparisonType.GreaterThanOrEqualTo;
                    break;
                case ExpressionType.LessThan:
                    booleanComparisonType = Expressions.BooleanComparisonType.LessThan;
                    break;
                case ExpressionType.LessThanOrEqual:
                    booleanComparisonType = Expressions.BooleanComparisonType.LessThanOrEqualTo;
                    break;
                default:
                    throw new NotImplementedException();
            }
            return booleanComparisonType;
        }

        public static bool CheckIfStringCompareTo(BinaryExpression binaryExpression, bool isNot, out Expressions.BooleanComparisonExpression stringComparison)
        {
            stringComparison = null;
            //check that it follows: o.prop.CompareTo("text") > < >= <= != == 0 1 -1
            if (binaryExpression.Left.NodeType == ExpressionType.Call &&
                binaryExpression.Left is MethodCallExpression methodCallExpression &&
                methodCallExpression.Method.Name == "CompareTo" &&
                methodCallExpression.Object is MemberExpression memberExpression &&
                methodCallExpression.Object.Type.Equals(typeof(string)) &&
                binaryExpression.Right.NodeType == ExpressionType.Constant &&
                binaryExpression.Right is ConstantExpression constantExpression &&
                methodCallExpression.Arguments.Count == 1 &&
                methodCallExpression.Arguments[0] is ConstantExpression argumentExpression)
            {
                Expressions.BooleanComparisonType booleanComparisonType = FilterUtils.ParseBooleanComparisonType(binaryExpression.NodeType);

                var compareValue = (long)Convert.ChangeType(constantExpression.Value, typeof(long));
                
                var convertedComparison = ConvertNot(ConvertBooleanComparisonType(booleanComparisonType, compareValue), isNot);

                var columnReference = new Expressions.ColumnReference() { Identifiers = new List<string>() { memberExpression.Member.Name } };
                stringComparison = new Expressions.BooleanComparisonExpression()
                {
                    Left = columnReference,
                    Right = new StringLiteral()
                    {
                        Value = (string)argumentExpression.Value
                    },
                    Type = convertedComparison
                };
                return true;
            }
            return false;
        }
    }
}
