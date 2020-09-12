using Koralium.SqlToExpression.Stages.ExecuteStages;
using System;

namespace Koralium.SqlToExpression.Executors
{
    public class DefaultGroupByExecutorFactory : IGroupByExecutorFactory
    {
        public IGroupByExecutor GetGroupByExecutor(ExecuteGroupByStage groupByStage)
        {
            var t = typeof(DefaultGroupByExecutor<,>).MakeGenericType(groupByStage.ValueType, groupByStage.KeyType);
            var executor = (IGroupByExecutor)Activator.CreateInstance(t);
            return executor;
        }
    }
}
