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
using Koralium.SqlToExpression.Stages.ExecuteStages;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors
{
    public class DefaultFromTableExecutor<Entity> : FromTableExecutor<Entity>
    {
        public override async ValueTask<IQueryable<Entity>> GetTable(ISqlTableResolver tableResolver, ExecuteFromTableStage executeFromTableStage, object additionalData)
        {
            QueryOptions queryOptions = new QueryOptions(
                executeFromTableStage.ParameterExpression,
                executeFromTableStage.SelectExpression,
                executeFromTableStage.WhereExpression,
                executeFromTableStage.Limit,
                executeFromTableStage.Offset,
                executeFromTableStage.ContainsFullTextSearch,
                executeFromTableStage.Parameters);

            var queryable = (IQueryable<Entity>)await tableResolver.ResolveTableName(executeFromTableStage.TableName, additionalData, queryOptions);

            //Check that we are not using any in memory queryable, since this select will only cost extra operations
            //without any gain
            if(!((queryable is EnumerableQuery) || (queryable is Array)) && queryOptions.TryGetSelectExpression<Entity>(out var select))
            {
                queryable = queryable.Select(select);
            }
            
            if(queryOptions.TryGetWhereExpression<Entity>(out var where))
            {
                queryable = queryable.Where(where);
            }

            if(queryOptions.TryGetOffset(out var offset))
            {
                queryable = queryable.Skip(offset);
            }

            if(queryOptions.TryGetLimit(out var limit))
            {
                queryable = queryable.Take(limit);
            }
            
            return queryable;
        }
    }
}
