using Koralium.SqlToExpression.Stages.ExecuteStages;
using System;
using System.Collections.Generic;


namespace Koralium.SqlToExpression.Executors
{
    public class DefaultOrderByExecutorFactory : IOrderByExecutorFactory
    {
        private static Dictionary<Type, IOrderByExecutor> executors = new Dictionary<Type, IOrderByExecutor>();
        public IOrderByExecutor GetOrderByExecutor(ExecuteOrderByStage executeOrderByStage)
        {
            if (!executors.TryGetValue(executeOrderByStage.EntityType, out var executor))
            {
                var t = typeof(DefaultOrderByExecutor<>).MakeGenericType(executeOrderByStage.EntityType);
                executor = (IOrderByExecutor)Activator.CreateInstance(t);
                executors.Add(executeOrderByStage.EntityType, executor);
            }
            return executor;
        }
    }
}
