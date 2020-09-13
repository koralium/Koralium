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
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Stages.ExecuteStages
{
    public class ExecuteSelectStage : IExecuteStage
    {
        public MemberInitExpression Expression { get; }

        public ParameterExpression ParameterExpression { get; }

        public Type InType { get; }

        public Type OutType { get; }

        public IImmutableList<ColumnMetadata> Columns { get; }

        public ExecuteSelectStage(
            MemberInitExpression expression,
            ParameterExpression parameterExpression,
            Type inType,
            Type outType,
            IImmutableList<ColumnMetadata> columns)
        {
            Expression = expression;
            ParameterExpression = parameterExpression;
            InType = inType;
            OutType = outType;
            Columns = columns;
        }

        public ValueTask<IQueryable> Accept(IQueryExecutor queryExecutor)
        {
            return queryExecutor.Visit(this);
        }
    }
}
