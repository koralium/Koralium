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
using System.Linq.Expressions;
using System.Reflection;

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
