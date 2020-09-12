using Koralium.SqlToExpression.Stages.ExecuteStages;
using System;
using System.Collections.Generic;

namespace Koralium.SqlToExpression.Executors
{
    public class DefaultWhereExecutorFactory : IWhereExecutorFactory
    {
        private static Dictionary<Type, IWhereExecutor> executors = new Dictionary<Type, IWhereExecutor>();

        public IWhereExecutor GetWhereExecutor(ExecuteWhereStage executeWhereStage)
        {
            if (!executors.TryGetValue(executeWhereStage.EntityType, out var executor))
            {
                var t = typeof(DefaultWhereExecutor<>).MakeGenericType(executeWhereStage.EntityType);
                executor = (IWhereExecutor)Activator.CreateInstance(t);
                executors.Add(executeWhereStage.EntityType, executor);
            }
            return executor;
        }
    }
}
