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
using Koralium.Shared;
using Koralium.SqlToExpression.Executors;
using Koralium.SqlToExpression.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Stages.ExecuteStages
{
    public class ExecuteFromTableStage : IExecuteStage
    {
        public string TableName { get; }

        public Type EntityType { get; }

        public MemberInitExpression SelectExpression { get; }

        public ParameterExpression ParameterExpression { get; }

        public Expression WhereExpression { get; }

        public int? Limit { get; }

        public int? Offset { get; }

        public bool ContainsFullTextSearch { get; }

        public IReadSqlParameters Parameters { get; }

        public ExecuteFromTableStage(
            string tableName,
            Type entityType,
            MemberInitExpression selectExpression,
            ParameterExpression parameterExpression,
            Expression whereExpression,
            int? limit,
            int? offset,
            bool containsFullTextSearch,
            IReadSqlParameters parameters)
        {
            TableName = tableName;
            EntityType = entityType;
            SelectExpression = selectExpression;
            ParameterExpression = parameterExpression;
            WhereExpression = whereExpression;
            Limit = limit;
            Offset = offset;
            ContainsFullTextSearch = containsFullTextSearch;
            Parameters = parameters;
        }

        public ValueTask<IQueryable> Accept(IQueryExecutor queryExecutor)
        {
            return queryExecutor.Visit(this);
        }
    }
}
