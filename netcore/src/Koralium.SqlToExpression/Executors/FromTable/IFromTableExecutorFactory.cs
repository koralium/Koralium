using Koralium.SqlToExpression.Stages.ExecuteStages;

namespace Koralium.SqlToExpression.Executors
{
    public interface IFromTableExecutorFactory
    {
        /// <summary>
        /// Get a from table executor with the specified type
        /// </summary>
        /// <param name="genericType"></param>
        /// <returns></returns>
        IFromTableExecutor GetFromTableExecutor(ExecuteFromTableStage executeFromTableStage);
    }
}
