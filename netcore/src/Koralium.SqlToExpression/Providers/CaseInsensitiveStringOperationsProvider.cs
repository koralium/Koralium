using Koralium.SqlToExpression.Interfaces;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Koralium.SqlToExpression.Providers
{
    public class CaseInsensitiveStringOperationsProvider : IStringOperationsProvider
    {
        private static readonly MethodInfo StringContains = typeof(string).GetMethod("Contains", new Type[] { typeof(string), typeof(StringComparison) });
        private static readonly MethodInfo StringStartsWith = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string), typeof(StringComparison) });
        private static readonly MethodInfo StringEndsWith = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string), typeof(StringComparison) });
        private static readonly MethodInfo StringEquals = typeof(string).GetMethod("Equals", new Type[] { typeof(string), typeof(StringComparison) });

        public Expression GetContainsExpression(Expression left, Expression right)
        {
            return Expression.Call(instance: left, method: StringContains, arguments: new[] { right, Expression.Constant(StringComparison.OrdinalIgnoreCase) });
        }

        public Expression GetEndsWithExpression(Expression left, Expression right)
        {
            return Expression.Call(instance: left, method: StringEndsWith, arguments: new[] { right, Expression.Constant(StringComparison.OrdinalIgnoreCase) });
        }

        public Expression GetEqualsExpressions(Expression left, Expression right)
        {
            return Expression.Call(instance: left, method: StringEquals, arguments: new[] { right, Expression.Constant(StringComparison.OrdinalIgnoreCase) });
        }

        public Expression GetStartsWithExpression(Expression left, Expression right)
        {
            return Expression.Call(instance: left, method: StringStartsWith, arguments: new[] { right, Expression.Constant(StringComparison.OrdinalIgnoreCase) });
        }
    }
}
