using Koralium.SqlToExpression.Executors;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Stages.ExecuteStages
{
    public class ExecuteAggregateFunctionStage : IExecuteStage
    {
        public string FunctionName { get; }

        public IImmutableList<ColumnMetadata> Columns { get; }

        public Type InType { get; }

        public ExecuteAggregateFunctionStage(
            string functionName,
            IImmutableList<ColumnMetadata> columns,
            Type inType)
        {
            FunctionName = functionName;
            Columns = columns;
            InType = inType;
        }


        public ValueTask<IQueryable> Accept(IQueryExecutor queryExecutor)
        {
            throw new NotImplementedException();
        }
    }
}
