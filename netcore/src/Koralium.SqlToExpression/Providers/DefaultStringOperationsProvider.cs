using Koralium.SqlToExpression.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Koralium.SqlToExpression.Providers
{
    public class DefaultStringOperationsProvider : IStringOperationsProvider
    {
        private static readonly MethodInfo StringStartsWith = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
        private static readonly MethodInfo StringContains = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
        private static readonly MethodInfo StringEndsWith = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });

        public Expression GetContainsExpression(Expression left, Expression right)
        {
            return Expression.Call(instance: left, method: StringContains, arguments: new[] { right });
        }

        public Expression GetEndsWithExpression(Expression left, Expression right)
        {
            return Expression.Call(instance: left, method: StringEndsWith, arguments: new[] { right });
        }

        public Expression GetEqualsExpressions(Expression left, Expression right)
        {
            return Expression.Equal(left, right);
        }

        public Expression GetStartsWithExpression(Expression left, Expression right)
        {
            return Expression.Call(instance: left, method: StringStartsWith, arguments: new[] { right });
        }
    }
}
