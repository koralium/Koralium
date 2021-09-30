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
using Koralium.SqlToExpression.Executors.AggregateFunction;
using Koralium.SqlToExpression.Executors.Offset;
using Koralium.SqlToExpression.Interfaces;
using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly ISqlTableResolver _tableResolver;
        private readonly IFromTableExecutorFactory _fromTableExecutorFactory;
        private readonly IWhereExecutorFactory _whereExecutorFactory;
        private readonly IGroupByExecutorFactory _groupByExecutorFactory;
        private readonly ISelectExecutorFactory _selectExecutorFactory;
        private readonly IOrderByExecutorFactory _orderByExecutorFactory;
        private readonly IOffsetExecutorFactory _offsetExecutorFactory;
        private readonly IDistinctExecutorFactory _distinctExecutorFactory;
        private readonly IAggregateFunctionExecutorFactory _aggregateFunctionExecutorFactory;
        private readonly IStoredProcedureResolver _storedProcedureResolver;

        IQueryable queryable = null;
        IImmutableList<ColumnMetadata> columns = null;
        object data = null;

        public QueryExecutor(
            ISqlTableResolver tableResolver,
            IFromTableExecutorFactory fromTableExecutorFactory,
            IWhereExecutorFactory whereExecutorFactory,
            IGroupByExecutorFactory groupByExecutorFactory,
            ISelectExecutorFactory selectExecutorFactory,
            IOrderByExecutorFactory orderByExecutorFactory,
            IOffsetExecutorFactory offsetExecutorFactory,
            IDistinctExecutorFactory distinctExecutorFactory,
            IAggregateFunctionExecutorFactory aggregateFunctionExecutorFactory,
            IStoredProcedureResolver storedProcedureResolver = null
            )
        {
            Debug.Assert(tableResolver != null);
            Debug.Assert(fromTableExecutorFactory != null);
            Debug.Assert(whereExecutorFactory != null);
            Debug.Assert(groupByExecutorFactory != null);
            Debug.Assert(selectExecutorFactory != null);
            Debug.Assert(orderByExecutorFactory != null);
            Debug.Assert(offsetExecutorFactory != null);
            Debug.Assert(distinctExecutorFactory != null);
            Debug.Assert(aggregateFunctionExecutorFactory != null);

            _tableResolver = tableResolver;
            _fromTableExecutorFactory = fromTableExecutorFactory;
            _whereExecutorFactory = whereExecutorFactory;
            _groupByExecutorFactory = groupByExecutorFactory;
            _selectExecutorFactory = selectExecutorFactory;
            _orderByExecutorFactory = orderByExecutorFactory;
            _offsetExecutorFactory = offsetExecutorFactory;
            _distinctExecutorFactory = distinctExecutorFactory;
            _aggregateFunctionExecutorFactory = aggregateFunctionExecutorFactory;
            _storedProcedureResolver = storedProcedureResolver;
        }

        public async ValueTask<QueryResult> Execute(IImmutableList<IExecuteStage> stages, object data)
        {
            this.data = data;
            foreach (var stage in stages)
            {
                queryable = await stage.Accept(this);
            }

            Debug.Assert(columns != null);
            Debug.Assert(queryable != null);

            return new QueryResult(queryable, columns);
        }

        public ValueTask<IQueryable> Visit(ExecuteFromTableStage executeFromTableStage)
        {
            var fromTableExecutor = _fromTableExecutorFactory.GetFromTableExecutor(executeFromTableStage);

            return fromTableExecutor.Execute(_tableResolver, executeFromTableStage, data);
        }

        public ValueTask<IQueryable> Visit(ExecuteGroupByStage executeGroupByStage)
        {
            Debug.Assert(queryable != null);
            var groupByExecutor = _groupByExecutorFactory.GetGroupByExecutor(executeGroupByStage);

            return groupByExecutor.Execute(queryable, executeGroupByStage);
        }

        public ValueTask<IQueryable> Visit(ExecuteOrderByStage executeOrderByStage)
        {
            Debug.Assert(queryable != null);
            var orderByExecutor = _orderByExecutorFactory.GetOrderByExecutor(executeOrderByStage);

            return orderByExecutor.Execute(queryable, executeOrderByStage);
        }

        public async ValueTask<IQueryable> Visit(ExecuteSelectStage executeSelectStage)
        {
            Debug.Assert(queryable != null);
            var selectExecutor = _selectExecutorFactory.GetSelectExecutor(executeSelectStage);

            var selectResult = await selectExecutor.Execute(queryable, executeSelectStage);
            columns = selectResult.Columns;

            return selectResult.Queryable;
        }

        public ValueTask<IQueryable> Visit(ExecuteWhereStage executeWhereStage)
        {
            Debug.Assert(queryable != null);
            var whereExecutor = _whereExecutorFactory.GetWhereExecutor(executeWhereStage);

            return whereExecutor.Execute(queryable, executeWhereStage);
        }

        public ValueTask<IQueryable> Visit(ExecuteOffsetStage executeOffsetStage)
        {
            Debug.Assert(queryable != null);
            var offsetExecutor = _offsetExecutorFactory.GetOffsetExecutor(executeOffsetStage);
            return offsetExecutor.Execute(queryable, executeOffsetStage);
        }

        public ValueTask<IQueryable> Visit(ExecuteDistinctStage executeDistinctStage)
        {
            Debug.Assert(queryable != null);
            var distinctExecutor = _distinctExecutorFactory.GetDistinctExecutor(executeDistinctStage);
            return distinctExecutor.Execute(queryable, executeDistinctStage);
        }

        public async ValueTask<IQueryable> Visit(ExecuteAggregateFunctionStage executeAggregateFunctionStage)
        {
            Debug.Assert(queryable != null);
            var aggregateFunctionExecutor = _aggregateFunctionExecutorFactory.GetAggregateFunctionExecutor(executeAggregateFunctionStage);
            var selectResult = await aggregateFunctionExecutor.Execute(queryable, executeAggregateFunctionStage);

            columns = selectResult.Columns;
            return selectResult.Queryable;
        }
    }
}
