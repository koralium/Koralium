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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq;

namespace Koralium.SqlToExpression.Providers
{
    public class InMemoryOperationsProvider : DefaultOperationsProvider
    {
        #region String handling
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "Only used in this class")]
        private static readonly MethodInfo StringContains = typeof(InMemoryOperationsProvider).GetMethod("InternalStringContains", BindingFlags.NonPublic | BindingFlags.Static);
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "Only used in this class")]
        private static readonly MethodInfo StringStartsWith = typeof(InMemoryOperationsProvider).GetMethod("InternalStringStartsWith", BindingFlags.NonPublic | BindingFlags.Static);
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "Only used in this class")]
        private static readonly MethodInfo StringEndsWith = typeof(InMemoryOperationsProvider).GetMethod("InternalStringEndsWith", BindingFlags.NonPublic | BindingFlags.Static);
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "Only used in this class")]
        private static readonly MethodInfo StringEquals = typeof(InMemoryOperationsProvider).GetMethod("InternalStringEquals", BindingFlags.NonPublic | BindingFlags.Static);

        private static readonly MethodInfo ListContainsMethod = FindStringListContainsMethodInfo();

        private static MethodInfo FindStringListContainsMethodInfo()
        {
            var methods = typeof(Enumerable).GetMethods().Where(x => x.Name == "Contains" && x.ContainsGenericParameters && x.GetParameters().Length == 3);

            return methods.First();
        }

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
            if (left == null && right == null)
            {
                return true;
            }
            if (left == null)
            {
                return false;
            }
            return left.Equals(right, StringComparison.OrdinalIgnoreCase);
        }

        public override Expression GetStringContainsExpression(in Expression left, in Expression right)
        {
            return Expression.Call(instance: null, method: StringContains, arguments: new[] { left, right });
        }

        public override Expression GetStringEndsWithExpression(in Expression left, in Expression right)
        {
            return Expression.Call(instance: null, method: StringEndsWith, arguments: new[] { left, right });
        }

        public override Expression GetStringEqualsExpressions(in Expression left, in Expression right)
        {
            return Expression.Call(instance: null, method: StringEquals, arguments: new[] { left, right });
        }

        public override Expression GetStringStartsWithExpression(in Expression left, in Expression right)
        {
            return Expression.Call(instance: null, method: StringStartsWith, arguments: new[] { left, right });
        }

        public override Expression MakeAnyCall(in Expression column, in Expression anyCall)
        {
            return Expression.Condition(Expression.Equal(column, Expression.Constant(null, column.Type)), Expression.Constant(false), anyCall);
        }

        public override Expression GetListContains(in Expression memberExpression, IList list)
        {
            if (list is List<string> stringList)
            {
                var method = ListContainsMethod.MakeGenericMethod(memberExpression.Type);
                return Expression.Call(null, method, arguments: new[] { Expression.Constant(stringList), memberExpression, Expression.Constant(StringComparer.OrdinalIgnoreCase) });
            }
            return base.GetListContains(memberExpression, list);
        }

        #endregion

        #region Object subfield select
        public override Expression MakeSubfieldMemberAccessExpression(in Expression expression, PropertyInfo propertyInfo)
        {
            BinaryExpression nullCheck = Expression.NotEqual(expression, Expression.Constant(null, typeof(object)));

            Expression nullValue;

            var memberAccess = base.MakeSubfieldMemberAccessExpression(expression, propertyInfo);

            if (propertyInfo.PropertyType.IsPrimitive)
            {
                var nullableType = typeof(Nullable<>).MakeGenericType(propertyInfo.PropertyType);
                nullValue = Expression.Constant(null, nullableType);
                memberAccess = Expression.Convert(memberAccess, nullableType);
            }
            else
            {
                nullValue = Expression.Constant(null, propertyInfo.PropertyType);
            }

            return Expression.Condition(nullCheck, memberAccess, nullValue);
        }

        #endregion
    }
}
