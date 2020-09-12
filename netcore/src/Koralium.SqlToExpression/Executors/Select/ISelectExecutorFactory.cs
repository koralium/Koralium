using Koralium.SqlToExpression.Stages.ExecuteStages;


namespace Koralium.SqlToExpression.Executors
{
    public interface ISelectExecutorFactory
    {
        ISelectExecutor GetSelectExecutor(ExecuteSelectStage selectStage);
    }
}
