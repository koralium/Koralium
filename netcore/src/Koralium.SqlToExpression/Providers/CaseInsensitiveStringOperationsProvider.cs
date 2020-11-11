using Koralium.SqlToExpression.Interfaces;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Koralium.SqlToExpression.Providers
{
    public class CaseInsensitiveStringOperationsProvider : IStringOperationsProvider
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "Only used in this class")]
        private static readonly MethodInfo StringContains = typeof(CaseInsensitiveStringOperationsProvider).GetMethod("InternalStringContains", BindingFlags.NonPublic | BindingFlags.Static);
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "Only used in this class")]
        private static readonly MethodInfo StringStartsWith = typeof(CaseInsensitiveStringOperationsProvider).GetMethod("InternalStringStartsWith", BindingFlags.NonPublic | BindingFlags.Static);
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "Only used in this class")]
        private static readonly MethodInfo StringEndsWith = typeof(CaseInsensitiveStringOperationsProvider).GetMethod("InternalStringEndsWith", BindingFlags.NonPublic | BindingFlags.Static);
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "Only used in this class")]
        private static readonly MethodInfo StringEquals = typeof(CaseInsensitiveStringOperationsProvider).GetMethod("InternalStringEquals", BindingFlags.NonPublic | BindingFlags.Static);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S1144:Unused private types or members should be removed", Justification = "Used in reflection")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used in reflection")]
        private static bool InternalStringContains(string left, string right)
        {
            if (left == null && right == null)
            {
                return true;
            }
            if (left == null)
            {
                return false;
            }
            return left.Contains(right, StringComparison.OrdinalIgnoreCase);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S1144:Unused private types or members should be removed", Justification = "Used in reflection")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used in reflection")]
        private static bool InternalStringStartsWith(string left, string right)
        {
            if (left == null && right == null)
            {
                return true;
            }
            if (left == null)
            {
                return false;
            }
            return left.StartsWith(right, StringComparison.OrdinalIgnoreCase);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S1144:Unused private types or members should be removed", Justification = "Used in reflection")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used in reflection")]
        private static bool InternalStringEndsWith(string left, string right)
        {
            if (left == null && right == null)
            {
                return true;
            }
            if (left == null)
            {
                return false;
            }
            return left.EndsWith(right, StringComparison.OrdinalIgnoreCase);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S1144:Unused private types or members should be removed", Justification = "Used in reflection")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used in reflection")]
        private static bool InternalStringEquals(string left, string right)
        {
            if(left == null && right == null)
            {
                return true;
            }
            if(left == null)
            {
                return false;
            }
            return left.Equals(right, StringComparison.OrdinalIgnoreCase);
        }

        public Expression GetContainsExpression(Expression left, Expression right)
        {
            return Expression.Call(instance: null, method: StringContains, arguments: new[] { left, right });
        }

        public Expression GetEndsWithExpression(Expression left, Expression right)
        {
            return Expression.Call(instance: null, method: StringEndsWith, arguments: new[] { left, right });
        }

        public Expression GetEqualsExpressions(Expression left, Expression right)
        {
            return Expression.Call(instance: null, method: StringEquals, arguments: new[] { left, right });
        }

        public Expression GetStartsWithExpression(Expression left, Expression right)
        {
            return Expression.Call(instance: null, method: StringStartsWith, arguments: new[] { left, right });
        }
    }
}
