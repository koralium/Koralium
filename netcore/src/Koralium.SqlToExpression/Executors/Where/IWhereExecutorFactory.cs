using Koralium.SqlToExpression.Stages.ExecuteStages;

namespace Koralium.SqlToExpression.Executors
{
    public interface IWhereExecutorFactory
    {
        IWhereExecutor GetWhereExecutor(ExecuteWhereStage executeWhereStage);
    }
}
