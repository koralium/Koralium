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
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.ExecuteStages;
using System;
using System.Linq;
using System.Linq.Expressions;
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

            if (queryOptions.TryGetWhereExpression<Entity>(out var where))
            {
                queryable = queryable.Where(where);
            }

            if (executeFromTableStage.SortItems != null)
            {
                if (executeFromTableStage.SortItems.Count > 0)
                {
                    var sortItems = executeFromTableStage.SortItems;
                    int i = 0;

                    var sortItem = sortItems[i];
                    var lambda = GetSortLambda(sortItem, executeFromTableStage.ParameterExpression);

                    IOrderedQueryable<Entity> orderedQueryable;
                    if (sortItem.Descending)
                    {
                        orderedQueryable = queryable.OrderByDescending(lambda);
                    }
                    else
                    {
                        orderedQueryable = queryable.OrderBy(lambda);
                    }
                    i++;

                    for (; i < sortItems.Count; i++)
                    {
                        sortItem = sortItems[i];
                        lambda = GetSortLambda(sortItem, executeFromTableStage.ParameterExpression);

                        if (sortItem.Descending)
                        {
                            orderedQueryable = orderedQueryable.ThenByDescending(lambda);
                        }
                        else
                        {
                            orderedQueryable = orderedQueryable.ThenBy(lambda);
                        }
                    }
                    queryable = orderedQueryable;
                }
            }

            if (queryOptions.TryGetOffset(out var offset))
            {
                queryable = queryable.Skip(offset);
            }

            if (queryOptions.TryGetLimit(out var limit))
            {
                queryable = queryable.Take(limit);
            }

            //Check that we are not using any in memory queryable, since this select will only cost extra operations
            //without any gain
            if (!((queryable is EnumerableQuery) || (queryable is Array)) && queryOptions.TryGetSelectExpression<Entity>(out var select))
            {
                queryable = queryable.Select(select);
            }
            
            
            
            return queryable;
        }

        protected Expression<Func<Entity, object>> GetSortLambda(SortItem sortItem, ParameterExpression parameterExpression)
        {
            var lambda = Expression.Lambda<Func<Entity, object>>(sortItem.Expression, parameterExpression);
            return lambda;
        }
    }
}
