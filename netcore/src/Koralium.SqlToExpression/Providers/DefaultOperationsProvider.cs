using Koralium.SqlToExpression.Interfaces;
using Koralium.SqlToExpression.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
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
using System.Text;

namespace Koralium.SqlToExpression.Providers
{
    public class DefaultOperationsProvider : IOperationsProvider
    {
        private static readonly MethodInfo StringStartsWith = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
        private static readonly MethodInfo StringContains = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
        private static readonly MethodInfo StringEndsWith = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });

        public virtual Expression GetListContains(in Expression memberExpression, IList list)
        {
            return PredicateUtils.ListContains(memberExpression, memberExpression.Type, list);
        }

        public virtual Expression GetStringContainsExpression(in Expression left, in Expression right)
        {
            return Expression.Call(instance: left, method: StringContains, arguments: new[] { right });
        }

        public virtual Expression GetStringEndsWithExpression(in Expression left, in Expression right)
        {
            return Expression.Call(instance: left, method: StringEndsWith, arguments: new[] { right });
        }

        public virtual Expression GetStringEqualsExpressions(in Expression left, in Expression right)
        {
            return Expression.Equal(left, right);
        }

        public virtual Expression GetStringStartsWithExpression(in Expression left, in Expression right)
        {
            return Expression.Call(instance: left, method: StringStartsWith, arguments: new[] { right });
        }

        public virtual Expression MakeAnyCall(in Expression column, in Expression anyCall)
        {
            return anyCall;
        }

        public virtual Expression MakeSubfieldMemberAccessExpression(in Expression expression, PropertyInfo propertyInfo)
        {
            return Expression.MakeMemberAccess(expression, propertyInfo);
        }
    }
}
