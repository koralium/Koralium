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
using Koralium.SqlToExpression.Executors;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Stages.ExecuteStages
{
    public class ExecuteGroupByStage : IExecuteStage
    {
        public Expression Expression { get; }

        public ParameterExpression ParameterExpression { get; }

        /// <summary>
        /// The type that represents the key, which is the fields in the group by
        /// </summary>
        public Type KeyType { get; }

        /// <summary>
        /// The type that represents the entity that was grouped
        /// </summary>
        public Type ValueType { get; }

        public ExecuteGroupByStage(
            Expression expression,
            ParameterExpression parameterExpression,
            Type keyType,
            Type valueType)
        {
            Expression = expression;
            ParameterExpression = parameterExpression;
            KeyType = keyType;
            ValueType = valueType;
        }

        public ValueTask<IQueryable> Accept(IQueryExecutor queryExecutor)
        {
            return queryExecutor.Visit(this);
        }
    }
}
