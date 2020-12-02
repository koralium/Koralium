using Koralium.SqlToExpression.Stages.ExecuteStages;
using System;
using System.Collections.Generic;

namespace Koralium.SqlToExpression.Executors.AggregateFunction
{
    public class DefaultAggregateFunctionFactory : IAggregateFunctionExecutorFactory
    {
        public IAggregateFunctionExecutor GetAggregateFunctionExecutor(ExecuteAggregateFunctionStage executeAggregateFunctionStage)
        {
            var t = typeof(DefaultAggregateFunctionExecutor<,>).MakeGenericType(executeAggregateFunctionStage.InType, executeAggregateFunctionStage.OutType);
            var executor = (IAggregateFunctionExecutor)Activator.CreateInstance(t);
            return executor;
        }
    }
}
