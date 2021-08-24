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
using System.Linq.Expressions;
using System.Reflection;

namespace Koralium.SqlToExpression.Interfaces
{
    public interface IOperationsProvider
    {
        Expression GetStringEqualsExpressions(in Expression left, in Expression right);

        Expression GetStringStartsWithExpression(in Expression left, in Expression right);

        Expression GetStringEndsWithExpression(in Expression left, in Expression right);

        Expression GetStringContainsExpression(in Expression left, in Expression right);

        Expression MakeSubfieldMemberAccessExpression(in Expression expression, PropertyInfo propertyInfo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column">The column that the any call is applied on.</param>
        /// <param name="anyCall">The any call</param>
        /// <returns></returns>
        Expression MakeAnyCall(in Expression column, in Expression anyCall);
    }
}
