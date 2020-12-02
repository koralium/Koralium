using Koralium.SqlToExpression.Stages.ExecuteStages;
using System.Text;

namespace Koralium.SqlToExpression.Executors.AggregateFunction
{
    public interface IAggregateFunctionExecutorFactory
    {
        IAggregateFunctionExecutor GetAggregateFunctionExecutor(ExecuteAggregateFunctionStage executeAggregateFunctionStage);
    }
}
