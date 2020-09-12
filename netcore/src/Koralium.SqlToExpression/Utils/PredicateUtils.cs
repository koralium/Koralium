using Koralium.SqlToExpression.Models;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Koralium.SqlToExpression.Utils
{
    public static class PredicateUtils
    {
        private static readonly MethodInfo StringCompareTo = typeof(string).GetMethod("CompareTo", new Type[] { typeof(string) });

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

        public static Expression CreateComparisonExpression(Expression leftExpression, Expression rightExpression, Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType comparisonType)
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
                    expression = Expression.Equal(leftExpression, rightExpression);
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
