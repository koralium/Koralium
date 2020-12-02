using Koralium.SqlToExpression.Stages.ExecuteStages;

namespace Koralium.SqlToExpression.Executors.AggregateFunction
{
    public interface IAggregateFunctionExecutorFactory
    {
        IAggregateFunctionExecutor GetAggregateFunctionExecutor(ExecuteAggregateFunctionStage executeAggregateFunctionStage);
    }
}
