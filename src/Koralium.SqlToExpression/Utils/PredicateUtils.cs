using Koralium.SqlToExpression.Models;
using System;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Utils
{
    public static class PredicateUtils
    {

        internal static void ConvertExpressionTypes(ref Expression leftExpression, ref Expression rightExpression)
        {
            {
                if (leftExpression is ConstantExpression constantExpressionLeft && !constantExpressionLeft.Type.Equals(rightExpression.Type))
                {
                    var changedTypeValue = Convert.ChangeType(constantExpressionLeft.Value, rightExpression.Type);
                    leftExpression = Expression.Constant(changedTypeValue);
                }
                else if (rightExpression is ConstantExpression constantExpressionRight && !constantExpressionRight.Type.Equals(leftExpression.Type))
                {
                    var changedTypeValue = Convert.ChangeType(constantExpressionRight.Value, leftExpression.Type);
                    rightExpression = Expression.Constant(changedTypeValue);
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

        public static Expression CreateComparisonExpression(Expression leftExpression, Expression rightExpression, BooleanComparisonType comparisonType)
        {
            ConvertExpressionTypes(ref leftExpression, ref rightExpression);

            Expression expression = null;
            switch (comparisonType)
            {
                case BooleanComparisonType.Equals:
                    expression = Expression.Equal(leftExpression, rightExpression);
                    break;
                case BooleanComparisonType.GreaterThan:
                    expression = Expression.GreaterThan(leftExpression, rightExpression);
                    break;
                case BooleanComparisonType.GreaterThanOrEqualTo:
                    expression = Expression.GreaterThanOrEqual(leftExpression, rightExpression);
                    break;
                case BooleanComparisonType.LessThan:
                    expression = Expression.LessThan(leftExpression, rightExpression);
                    break;
                case BooleanComparisonType.LessThanOrEqualTo:
                    expression = Expression.LessThanOrEqual(leftExpression, rightExpression);
                    break;
                case BooleanComparisonType.NotEqualToBrackets:
                    expression = Expression.NotEqual(leftExpression, rightExpression);
                    break;
                case BooleanComparisonType.NotEqualToExclamation:
                    expression = Expression.NotEqual(leftExpression, rightExpression);
                    break;
                case BooleanComparisonType.NotGreaterThan:
                    expression = Expression.Not(Expression.GreaterThan(leftExpression, rightExpression));
                    break;
                case BooleanComparisonType.NotLessThan:
                    expression = Expression.Not(Expression.LessThan(leftExpression, rightExpression));
                    break;
            }
            return expression;
        }



        public static Expression CreateComparisonExpression(Expression leftExpression, Expression rightExpression, Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType comparisonType)
        {
            ConvertExpressionTypes(ref leftExpression, ref rightExpression);

            Expression expression = null;
            switch (comparisonType)
            {
                case Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType.Equals:
                    expression = Expression.Equal(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType.GreaterThan:
                    expression = Expression.GreaterThan(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType.GreaterThanOrEqualTo:
                    expression = Expression.GreaterThanOrEqual(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType.LessThan:
                    expression = Expression.LessThan(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType.LessThanOrEqualTo:
                    expression = Expression.LessThanOrEqual(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType.NotEqualToBrackets:
                    expression = Expression.NotEqual(leftExpression, rightExpression);
                    break;
                case Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType.NotEqualToExclamation:
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
