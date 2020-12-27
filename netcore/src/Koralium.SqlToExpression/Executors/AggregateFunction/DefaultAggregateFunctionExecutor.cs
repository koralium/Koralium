using Koralium.Shared;
using Koralium.SqlToExpression.Stages.ExecuteStages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Executors.AggregateFunction
{
    public class DefaultAggregateFunctionExecutor<Entity, OutType> : AggregateFunctionExecutor<Entity, OutType>
    {
        private OutType HandleSumFunction(IQueryable<Entity> queryable, ExecuteAggregateFunctionStage executeAggregateFunctionStage)
        {
            Debug.Assert(executeAggregateFunctionStage.Parameters.Count == 1);
            var parameter = executeAggregateFunctionStage.Parameters[0];
            
            if (typeof(OutType) == typeof(decimal?))
            {
                return queryable.Sum(GetParameterLambda<decimal?>(executeAggregateFunctionStage.ParameterExpression, parameter)).Cast<OutType>();
            }
            if (typeof(OutType) == typeof(decimal))
            {
                return queryable.Sum(GetParameterLambda<decimal>(executeAggregateFunctionStage.ParameterExpression, parameter)).Cast<OutType>();
            }
            if(typeof(OutType) == typeof(double?))
            {
                return queryable.Sum(GetParameterLambda<double?>(executeAggregateFunctionStage.ParameterExpression, parameter)).Cast<OutType>();
            }
            if (typeof(OutType) == typeof(double))
            {
                return queryable.Sum(GetParameterLambda<double>(executeAggregateFunctionStage.ParameterExpression, parameter)).Cast<OutType>();
            }
            if (typeof(OutType) == typeof(float?))
            {
                return queryable.Sum(GetParameterLambda<float?>(executeAggregateFunctionStage.ParameterExpression, parameter)).Cast<OutType>();
            }
            if (typeof(OutType) == typeof(float))
            {
                return queryable.Sum(GetParameterLambda<float>(executeAggregateFunctionStage.ParameterExpression, parameter)).Cast<OutType>();
            }
            if (typeof(OutType) == typeof(int?))
            {
                return queryable.Sum(GetParameterLambda<int?>(executeAggregateFunctionStage.ParameterExpression, parameter)).Cast<OutType>();
            }
            if (typeof(OutType) == typeof(int))
            {
                return queryable.Sum(GetParameterLambda<int>(executeAggregateFunctionStage.ParameterExpression, parameter)).Cast<OutType>();
            }
            if (typeof(OutType) == typeof(long?))
            {
                return queryable.Sum(GetParameterLambda<long?>(executeAggregateFunctionStage.ParameterExpression, parameter)).Cast<OutType>();
            }
            if (typeof(OutType) == typeof(long))
            {
                return queryable.Sum(GetParameterLambda<long>(executeAggregateFunctionStage.ParameterExpression, parameter)).Cast<OutType>();
            }
            throw new SqlErrorException($"Type ${typeof(OutType).Name} is not supported for sum operations");
        }

        public override ValueTask<OutType> ExecuteAggregateFunction(
            IQueryable<Entity> queryable, 
            ExecuteAggregateFunctionStage executeAggregateFunctionStage)
        {
            switch (executeAggregateFunctionStage.FunctionName)
            {
                case "count":
                    return new ValueTask<OutType>(queryable.LongCount().Cast<OutType>());
                case "sum":
                    return new ValueTask<OutType>(HandleSumFunction(queryable, executeAggregateFunctionStage));
                default:
                    throw new NotImplementedException($"The function {executeAggregateFunctionStage.FunctionName} is not yet implemented.");
            }
        }
    }
}
