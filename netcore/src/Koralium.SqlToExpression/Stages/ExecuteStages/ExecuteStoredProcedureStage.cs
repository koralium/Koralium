using Koralium.SqlToExpression.Executors;
using Koralium.SqlToExpression.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Stages.ExecuteStages
{
    public class ExecuteStoredProcedureStage : IExecuteStage
    {
        /// <summary>
        /// Name of the procedure
        /// </summary>
        public string ProcedureName { get; }

        /// <summary>
        /// Parameters for the procedure
        /// </summary>
        public IImmutableList<StoredProcedureParameter> Parameters { get; }

        /// <summary>
        /// The columns that are outputed
        /// </summary>
        public IImmutableList<ColumnMetadata> Columns { get; }

        public ExecuteStoredProcedureStage(
            string procedureName, 
            IImmutableList<StoredProcedureParameter> parameters, 
            IImmutableList<ColumnMetadata> columns)
        {
            ProcedureName = procedureName;
            Parameters = parameters;
            Columns = columns;
        }

        public ValueTask<IQueryable> Accept(IQueryExecutor queryExecutor)
        {
            throw new NotImplementedException();
        }
    }
}
