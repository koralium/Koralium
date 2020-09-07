using Koralium.SqlToExpression.Stages.ExecuteStages;
using System;
using System.Collections.Generic;

namespace Koralium.SqlToExpression.Executors
{
    public class DefaultFromTableExecutorFactory : IFromTableExecutorFactory
    {
        private static Dictionary<Type, IFromTableExecutor> executors = new Dictionary<Type, IFromTableExecutor>();

        public IFromTableExecutor GetFromTableExecutor(ExecuteFromTableStage executeFromTableStage)
        {
            if (!executors.TryGetValue(executeFromTableStage.EntityType, out var executor))
            {
                var t = typeof(DefaultFromTableExecutor<>).MakeGenericType(executeFromTableStage.EntityType);
                executor = (IFromTableExecutor)Activator.CreateInstance(t);
                executors.Add(executeFromTableStage.EntityType, executor);
            }
            return executor;
        }
    }
}
