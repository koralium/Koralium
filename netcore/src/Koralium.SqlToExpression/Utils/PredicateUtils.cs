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
using Koralium.SqlToExpression.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Koralium.SqlToExpression.Utils
{
    public static class PredicateUtils
    {
        private static readonly MethodInfo StringCompareTo = typeof(string).GetMethod("CompareTo", new Type[] { typeof(string) });
        private static readonly MethodInfo StringStartsWith = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
        private static readonly MethodInfo StringContains = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
        private static readonly MethodInfo StringEndsWith = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });
        private static readonly MethodInfo ListContainsMethod = FindListContainsMethodInfo();

        private static MethodInfo FindListContainsMethodInfo()
        {
            var methods = typeof(Enumerable).GetMethods().Where(x => x.Name == "Contains" && x.ContainsGenericParameters && x.GetParameters().Length == 2);

            return methods.First();
        }

        public static Expression ListContains(Expression parameter, Type type, IList values)
        {
            var method = ListContainsMethod.MakeGenericMethod(type);

            return Expression.Call(null, method, arguments: new[] { Expression.Constant(values), parameter });
        }


        internal static void ConvertExpressionTypes(ref Expression leftExpression, ref Expression rightExpression)
        {
            {
                if (leftExpression is ConstantExpression constantExpressionLeft && !constantExpressionLeft.Type.Equals(rightExpression.Type))
                {
                    if(constantExpressionLeft.Value != null)
                    {
                        var changedTypeValue = Convert.ChangeType(constantExpressionLeft.Value, rightExpression.Type);
                        leftExpression = Expression.Constant(changedTypeValue);
                    }
                }
                else if (rightExpression is ConstantExpression constantExpressionRight && !constantExpressionRight.Type.Equals(leftExpression.Type))
                {
                    if(constantExpressionRight.Value != null)
                    {
                        var changedTypeValue = Convert.ChangeType(constantExpressionRight.Value, leftExpression.Type);
                        rightExpression = Expression.Constant(changedTypeValue);
                    }
                }
                //Check if variable references
                else if (leftExpression is MemberExpression memberExpressionLeft &&
                    memberExpressionLeft.Expression is ConstantExpression constantExpressionLeftVariable &&
                    constantExpressionLeftVariable.Value is SqlParameter sqlParameterLeft &&
                    !sqlParameterLeft.GetValueType().Equals(rightExpression.Type)
                    )
                {
                    var value = sqlParameterLeft.GetValue();
                    var changedTypeValue = Convert.ChangeType(value, rightExpression.Type);

                    leftExpression = Expression.Constant(changedTypeValue);
                }
                else if (rightExpression is MemberExpression memberExpressionRight &&
                    memberExpressionRight.Expression is ConstantExpression constantExpressionRightVariable &&
                    constantExpressionRightVariable.Value is SqlParameter sqlParameter &&
                    !sqlParameter.GetValueType().Equals(leftExpression.Type))
                {
                    var value = sqlParameter.GetValue();
                    var changedTypeValue = Convert.ChangeType(value, leftExpression.Type);

                    rightExpression = Expression.Constant(changedTypeValue);
                }
                //If the types still does not match, we convert on the right
                else if (!leftExpression.Type.Equals(rightExpression.Type))
                {
                    rightExpression = Expression.Convert(rightExpression, leftExpression.Type);
                }
            }
        }

        private static bool IsConstantNull(Expression expression)
        {
            return expression is ConstantExpression constantExpression && constantExpression.Value == null;
        }

        private static void StringComparision(ref Expression left, ref Expression right)
        {
            left = Expression.Call(
                instance: left,
                method: StringCompareTo,
                arguments: new[] { right });

            right = Expression.Constant(0);
        }

        public static Expression CallContains(
            Expression left, 
            Expression value,
            IStringOperationsProvider stringOperationsProvider)
        {
            ConvertExpressionTypes(ref left, ref value);
            return stringOperationsProvider.GetContainsExpression(left, value);
        }

        public static Expression CallStartsWith(
            Expression left, 
            Expression value,
            IStringOperationsProvider stringOperationsProvider)
        {
            ConvertExpressionTypes(ref left, ref value);
            return stringOperationsProvider.GetStartsWithExpression(left, value);
        }
        
        public static Expression CallEndsWith(
            Expression left, 
            Expression value,
            IStringOperationsProvider stringOperationsProvider)
        {
            ConvertExpressionTypes(ref left, ref value);
            return stringOperationsProvider.GetEndsWithExpression(left, value);
        }

        public static Expression CreateComparisonExpression(
            Expression leftExpression, 
            Expression rightExpression, 
            Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType comparisonType,
            IStringOperationsProvider stringOperationsProvider)
        {
            ConvertExpressionTypes(ref leftExpression, ref rightExpression);

            Expression expression = null;
            switch (comparisonType)
            {
                case Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType.Equals:
                    //Null equal primitive cant be done, automatic false
                    if ((IsConstantNull(leftExpression) && rightExpression.Type.IsPrimitive) || (IsConstantNull(rightExpression) && leftExpression.Type.IsPrimitive))
                    {
                        return Expression.Constant(false);
                    }
                    //String is a special case since one might want to do case insensitive comparisions
                    if (leftExpression.Type.Equals(typeof(string)))
                    {
                        expression = stringOperationsProvider.GetEqualsExpressions(leftExpression, rightExpression);
                    }
                    else
                    {
                        expression = Expression.Equal(leftExpression, rightExpression);
                    }
                    
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType.GreaterThan:
                    if (leftExpression.Type.Equals(typeof(string)))
                    {
                        StringComparision(ref leftExpression, ref rightExpression);
                    }
                    expression = Expression.GreaterThan(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType.GreaterThanOrEqualTo:
                    if (leftExpression.Type.Equals(typeof(string)))
                    {
                        StringComparision(ref leftExpression, ref rightExpression);
                    }
                    expression = Expression.GreaterThanOrEqual(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType.LessThan:
                    if (leftExpression.Type.Equals(typeof(string)))
                    {
                        StringComparision(ref leftExpression, ref rightExpression);
                    }
                    expression = Expression.LessThan(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType.LessThanOrEqualTo:
                    if (leftExpression.Type.Equals(typeof(string)))
                    {
                        StringComparision(ref leftExpression, ref rightExpression);
                    }
                    expression = Expression.LessThanOrEqual(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType.NotEqualToBrackets:
                case Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType.NotEqualToExclamation:
                    if ((IsConstantNull(leftExpression) && rightExpression.Type.IsPrimitive) || (IsConstantNull(rightExpression) && leftExpression.Type.IsPrimitive))
                    {
                        return Expression.Constant(true);
                    }
                    expression = Expression.NotEqual(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType.NotGreaterThan:
                    expression = Expression.Not(Expression.GreaterThan(leftExpression, rightExpression));
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType.NotLessThan:
                    expression = Expression.Not(Expression.LessThan(leftExpression, rightExpression));
                    break;
            }
            return expression;
        }
    }
}
