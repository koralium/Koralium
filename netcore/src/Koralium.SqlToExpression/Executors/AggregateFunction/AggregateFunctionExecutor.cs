using Koralium.SqlToExpression.Executors.Select;
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.ExecuteStages;
using Koralium.SqlToExpression.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors.AggregateFunction
{
    public abstract class AggregateFunctionExecutor<Entity, OutType> : IAggregateFunctionExecutor
    {
        public async ValueTask<SelectResult> Execute(IQueryable queryable, ExecuteAggregateFunctionStage executeAggregateFunctionStage)
        {
            var result = await ExecuteAggregateFunction((IQueryable<Entity>)queryable, executeAggregateFunctionStage);

            var columnMetadata = new ColumnMetadata(executeAggregateFunctionStage.ColumnName, result.GetType(), AnonTypeUtils.GetDelegate(0));

            List<AnonType> output = new List<AnonType>()
            {
                new AnonType()
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
