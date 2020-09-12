using Koralium.SqlToExpression.Stages.ExecuteStages;

namespace Koralium.SqlToExpression.Executors
{
    public interface IGroupByExecutorFactory
    {
        IGroupByExecutor GetGroupByExecutor(ExecuteGroupByStage groupByStage);
    }
}
