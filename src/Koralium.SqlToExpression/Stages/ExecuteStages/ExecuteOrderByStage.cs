using Koralium.SqlToExpression.Executors;
using Koralium.SqlToExpression.Models;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Stages.ExecuteStages
{
    public class ExecuteOrderByStage : IExecuteStage
    {
        public IImmutableList<SortItem> SortItems { get; }

        public ParameterExpression ParameterExpression { get; }

        public Type EntityType { get; }

        public ExecuteOrderByStage(
            IImmutableList<SortItem> sortItems,
            ParameterExpression parameterExpression,
            Type entityType)
        {
            SortItems = sortItems;
            ParameterExpression = parameterExpression;
            EntityType = entityType;
        }

        public ValueTask<IQueryable> Accept(IQueryExecutor queryExecutor)
        {
            return queryExecutor.Visit(this);
        }
    }
}
