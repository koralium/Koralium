using Koralium.SqlToExpression.Stages.ExecuteStages;

namespace Koralium.SqlToExpression.Executors.Offset
{
    public interface IOffsetExecutorFactory
    {
        IOffsetExecutor GetOffsetExecutor(ExecuteOffsetStage executeOffsetStage);
    }
}
