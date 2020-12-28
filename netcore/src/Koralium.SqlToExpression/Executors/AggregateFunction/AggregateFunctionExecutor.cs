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
using Koralium.SqlToExpression.Executors.Select;
using Koralium.SqlToExpression.Generated;
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.ExecuteStages;
using Koralium.SqlToExpression.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors.AggregateFunction
{
    public abstract class AggregateFunctionExecutor<Entity, OutType> : IAggregateFunctionExecutor
    {
        public async ValueTask<SelectResult> Execute(IQueryable queryable, ExecuteAggregateFunctionStage executeAggregateFunctionStage)
        {
            var result = await ExecuteAggregateFunction((IQueryable<Entity>)queryable, executeAggregateFunctionStage);

            var outType = typeof(OutType);
            var anonType = AnonType.GetAnonType(outType);
            var getDelegate = AnonTypeUtils.GetDelegates(anonType)[0];
            var columnMetadata = new ColumnMetadata(executeAggregateFunctionStage.ColumnName, result.GetType(), getDelegate);

            List<AnonType<OutType>> output = new List<AnonType<OutType>>()
            {
                new AnonType<OutType>()
                {
                    P0 = result
                }
            };

            return new SelectResult(output.AsQueryable(), ImmutableList.Create(columnMetadata));
        }

        protected Expression<Func<Entity, T>> GetParameterLambda<T>(ParameterExpression parameterExpression, Expression expression)
        {
            var lambda = Expression.Lambda<Func<Entity, T>>(Expression.Convert(expression, typeof(T)), parameterExpression);
            return lambda;
        }

        public abstract ValueTask<OutType> ExecuteAggregateFunction(IQueryable<Entity> queryable, ExecuteAggregateFunctionStage executeAggregateFunctionStage);
    }
}
