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
using System.Diagnostics;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors.Select
{
    internal class SelectExpression
    {
        public Expression Expression { get; }

        public string Alias { get; }

        public SelectExpression(Expression expression, string alias)
        {
            Debug.Assert(expression != null, $"{nameof(expression)} was null");

            Expression = expression;
            Alias = alias;
        }

        public SelectExpression(Expression expression, string newAlias, string oldAlias)
        {
            Debug.Assert(expression != null, $"{nameof(expression)} was null");

            Expression = expression;
            Alias = newAlias ?? oldAlias;
        }
    }
}
