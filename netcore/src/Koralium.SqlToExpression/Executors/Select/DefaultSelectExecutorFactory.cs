using Koralium.SqlToExpression.Stages.ExecuteStages;
using System;

namespace Koralium.SqlToExpression.Executors
{
    public class DefaultSelectExecutorFactory : ISelectExecutorFactory
    {
        public ISelectExecutor GetSelectExecutor(ExecuteSelectStage selectStage)
        {
            var t = typeof(DefaultSelectExecutor<,>).MakeGenericType(selectStage.InType, selectStage.OutType);
            var executor = (ISelectExecutor)Activator.CreateInstance(t);
            return executor;
        }
    }
}
