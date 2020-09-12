using Koralium.SqlToExpression.Stages.ExecuteStages;

namespace Koralium.SqlToExpression.Executors
{
    public interface IOrderByExecutorFactory
    {
        IOrderByExecutor GetOrderByExecutor(ExecuteOrderByStage executeOrderByStage);
    }
}
