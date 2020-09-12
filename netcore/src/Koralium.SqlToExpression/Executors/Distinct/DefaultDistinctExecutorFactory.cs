using Koralium.SqlToExpression.Stages.ExecuteStages;
using System;
using System.Collections.Generic;

namespace Koralium.SqlToExpression.Executors
{
    public class DefaultDistinctExecutorFactory : IDistinctExecutorFactory
    {
        private static Dictionary<Type, IDistinctExecutor> executors = new Dictionary<Type, IDistinctExecutor>();
        public IDistinctExecutor GetDistinctExecutor(ExecuteDistinctStage executeDistinctStage)
        {
            if (!executors.TryGetValue(executeDistinctStage.Type, out var executor))
            {
                var t = typeof(DefaultDistinctExecutor<>).MakeGenericType(executeDistinctStage.Type);
                executor = (IDistinctExecutor)Activator.CreateInstance(t);
                executors.Add(executeDistinctStage.Type, executor);
            }
            return executor;
        }
    }
}
