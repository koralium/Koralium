using Koralium.Shared;
using Koralium.SqlToExpression.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;

namespace Koralium.SqlToExpression.Stages.CompileStages
{
    internal class StoredProcedureStage : IQueryStage
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

        public SqlTypeInfo TypeInfo { get; }

        public ParameterExpression ParameterExpression { get; }

        public Type CurrentType { get; }

        public FromAliases FromAliases { get; }

        public IReadSqlParameters GlobalParameters { get; }

        public StoredProcedureStage(
            string procedureName,
            SqlTypeInfo sqlTypeInfo,
            ParameterExpression parameterExpression,
            Type currentType,
            FromAliases fromAliases,
            IReadSqlParameters globalParameters)
        {
            Debug.Assert(procedureName != null, $"{nameof(procedureName)} was null");
            Debug.Assert(sqlTypeInfo != null, $"{nameof(sqlTypeInfo)} was null");
            Debug.Assert(parameterExpression != null, $"{nameof(parameterExpression)} was null");
            Debug.Assert(currentType != null, $"{nameof(currentType)} was null");
            Debug.Assert(fromAliases != null, $"{nameof(fromAliases)} was null");
            Debug.Assert(globalParameters != null, $"{nameof(globalParameters)} was null");

            ProcedureName = procedureName;
            TypeInfo = sqlTypeInfo;
            ParameterExpression = parameterExpression;
            CurrentType = currentType;
            FromAliases = fromAliases;
            GlobalParameters = globalParameters;
        }

        public void Accept(IQueryStageVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }
}
