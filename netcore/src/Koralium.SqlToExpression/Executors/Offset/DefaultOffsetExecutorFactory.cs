using Koralium.SqlToExpression.Stages.ExecuteStages;
using System;
using System.Collections.Generic;

namespace Koralium.SqlToExpression.Executors.Offset
{
    public class DefaultOffsetExecutorFactory : IOffsetExecutorFactory
    {
        private static Dictionary<Type, IOffsetExecutor> executors = new Dictionary<Type, IOffsetExecutor>();
        public IOffsetExecutor GetOffsetExecutor(ExecuteOffsetStage executeOffsetStage)
        {
            if (!executors.TryGetValue(executeOffsetStage.Type, out var executor))
            {
                var t = typeof(DefaultOffsetExecutor<>).MakeGenericType(executeOffsetStage.Type);
                executor = (IOffsetExecutor)Activator.CreateInstance(t);
                executors.Add(executeOffsetStage.Type, executor);
            }
            return executor;
        }
    }
}
