using Koralium.SqlToExpression.Executors;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Stages.ExecuteStages
{
    public class ExecuteFromTableStage : IExecuteStage
    {
        public string TableName { get; }

        public Type EntityType { get; }

        public ExecuteFromTableStage(string tableName, Type entityType)
        {
            TableName = tableName;
            EntityType = entityType;
        }

        public ValueTask<IQueryable> Accept(IQueryExecutor queryExecutor)
        {
            return queryExecutor.Visit(this);
        }
    }
}
