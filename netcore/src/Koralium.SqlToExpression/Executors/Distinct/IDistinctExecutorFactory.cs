using Koralium.SqlToExpression.Stages.ExecuteStages;

namespace Koralium.SqlToExpression.Executors
{
    public interface IDistinctExecutorFactory
    {
        IDistinctExecutor GetDistinctExecutor(ExecuteDistinctStage executeDistinctStage);
    }
}
