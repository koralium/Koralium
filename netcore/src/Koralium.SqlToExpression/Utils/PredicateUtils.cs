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
using Koralium.Shared;
using Koralium.SqlParser.Expressions;
using Koralium.SqlToExpression.Interfaces;
using System;
using System.Collections;
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

        private static Expression ChangeTypeWithNullable(object value, Type toType)
        {
            Type nullableType = Nullable.GetUnderlyingType(toType);

            if(nullableType != null)
            {
                object safeValue = (value == null) ? null : Convert.ChangeType(value, nullableType);
                return Expression.Convert(Expression.Constant(safeValue), toType);
            }
            else
            {
                //Enum conversion
                if (toType.IsEnum && value is string s)
                {
                    if(!Enum.TryParse(toType, s, true, out var enumValue))
                    {
                        throw new SqlErrorException($"'{s}' is not a valid value of the enum '{toType.Name}'");
                    }
                    return Expression.Constant(enumValue);
                }
                return Expression.Constant(Convert.ChangeType(value, toType));
            }
        }

        internal static void ConvertExpressionTypes(ref Expression leftExpression, ref Expression rightExpression)
        {
            {
                if (leftExpression is ConstantExpression constantExpressionLeft && !constantExpressionLeft.Type.Equals(rightExpression.Type))
                {
                    if(constantExpressionLeft.Value != null)
                    {
                        var changedTypeValue = ChangeTypeWithNullable(constantExpressionLeft.Value, rightExpression.Type);
                        leftExpression = changedTypeValue;
                    }
                }
                else if (rightExpression is ConstantExpression constantExpressionRight && !constantExpressionRight.Type.Equals(leftExpression.Type))
                {
                    if(constantExpressionRight.Value != null)
                    {
                        var changedTypeValue = ChangeTypeWithNullable(constantExpressionRight.Value, leftExpression.Type);
                        rightExpression = changedTypeValue;
                    }
                }
                //Check if variable references
                else if (leftExpression is MemberExpression memberExpressionLeft &&
                    memberExpressionLeft.Expression is ConstantExpression constantExpressionLeftVariable &&
                    constantExpressionLeftVariable.Value is SqlParameter sqlParameterLeft &&
                    !sqlParameterLeft.GetValueType().Equals(rightExpression.Type)
                    )
                {
                    if(sqlParameterLeft.TryGetValue(rightExpression.Type, out var value))
                    {
                        leftExpression = Expression.Constant(value);
                    }
                    else
                    {
                        throw new SqlErrorException($"Could not cast {sqlParameterLeft.GetValueType().Name} to {rightExpression.Type}");
                    }
                }
                else if (rightExpression is MemberExpression memberExpressionRight &&
                    memberExpressionRight.Expression is ConstantExpression constantExpressionRightVariable &&
                    constantExpressionRightVariable.Value is SqlParameter sqlParameter &&
                    !sqlParameter.GetValueType().Equals(leftExpression.Type))
                {
                    if (sqlParameter.TryGetValue(leftExpression.Type, out var value))
                    {
                        rightExpression = Expression.Constant(value);
                    }
                    else
                    {
                        throw new SqlErrorException($"Could not cast {sqlParameter.GetValueType().Name} to {leftExpression.Type}");
                    }
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
            IOperationsProvider operationsProvider)
        {
            ConvertExpressionTypes(ref left, ref value);
            return operationsProvider.GetStringContainsExpression(left, value);
        }

        public static Expression CallStartsWith(
            Expression left, 
            Expression value,
            IOperationsProvider operationsProvider)
        {
            ConvertExpressionTypes(ref left, ref value);
            return operationsProvider.GetStringStartsWithExpression(left, value);
        }
        
        public static Expression CallEndsWith(
            Expression left, 
            Expression value,
            IOperationsProvider operationsProviders)
        {
            ConvertExpressionTypes(ref left, ref value);
            return operationsProviders.GetStringEndsWithExpression(left, value);
        }

        private static Expression HandleEquals(Expression leftExpression, Expression rightExpression, IOperationsProvider operationsProviders)
        {
            //Null equal primitive cant be done, automatic false
            if ((IsConstantNull(leftExpression) && rightExpression.Type.IsPrimitive) || (IsConstantNull(rightExpression) && leftExpression.Type.IsPrimitive))
            {
                return Expression.Constant(false);
            }
            //String is a special case since one might want to do case insensitive comparisions
            if (leftExpression.Type.Equals(typeof(string)))
            {
                return operationsProviders.GetStringEqualsExpressions(leftExpression, rightExpression);
            }
            else
            {
                return Expression.Equal(leftExpression, rightExpression);
            }
        }

        private static Expression HandleGreaterThan(Expression leftExpression, Expression rightExpression)
        {
            if (leftExpression.Type.Equals(typeof(string)))
            {
                StringComparision(ref leftExpression, ref rightExpression);
            }
            return Expression.GreaterThan(leftExpression, rightExpression);
        }

        private static Expression HandleGreaterThanOrEqualTo(Expression leftExpression, Expression rightExpression)
        {
            if (leftExpression.Type.Equals(typeof(string)))
            {
                StringComparision(ref leftExpression, ref rightExpression);
            }
            return Expression.GreaterThanOrEqual(leftExpression, rightExpression);
        }

        private static Expression HandleLessThan(Expression leftExpression, Expression rightExpression)
        {
            if (leftExpression.Type.Equals(typeof(string)))
            {
                StringComparision(ref leftExpression, ref rightExpression);
            }
            return Expression.LessThan(leftExpression, rightExpression);
        }

        private static Expression HandleLessThanOrEqualTo(Expression leftExpression, Expression rightExpression)
        {
            if (leftExpression.Type.Equals(typeof(string)))
            {
                StringComparision(ref leftExpression, ref rightExpression);
            }
            return Expression.LessThanOrEqual(leftExpression, rightExpression);
        }

        private static Expression HandleNotEqualTo(Expression leftExpression, Expression rightExpression)
        {
            if ((IsConstantNull(leftExpression) && rightExpression.Type.IsPrimitive) || (IsConstantNull(rightExpression) && leftExpression.Type.IsPrimitive))
            {
                return Expression.Constant(true);
            }
            return Expression.NotEqual(leftExpression, rightExpression);
        }

        public static Expression CreateComparisonExpression(
            Expression leftExpression,
            Expression rightExpression,
            BooleanComparisonType comparisonType,
            IOperationsProvider operationsProvider)
        {
            ConvertExpressionTypes(ref leftExpression, ref rightExpression);

            switch (comparisonType)
            {
                case BooleanComparisonType.Equals:
                    return HandleEquals(leftExpression, rightExpression, operationsProvider);
                case BooleanComparisonType.GreaterThan:
                    return HandleGreaterThan(leftExpression, rightExpression);
                case BooleanComparisonType.GreaterThanOrEqualTo:
                    return HandleGreaterThanOrEqualTo(leftExpression, rightExpression);
                case BooleanComparisonType.LessThan:
                    return HandleLessThan(leftExpression, rightExpression);
                case BooleanComparisonType.LessThanOrEqualTo:
                    return HandleLessThanOrEqualTo(leftExpression, rightExpression);
                case BooleanComparisonType.NotEqualTo:
                    return HandleNotEqualTo(leftExpression, rightExpression);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
