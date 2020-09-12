using Koralium.SqlToExpression.Models;
using System;
using System.Collections.Immutable;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Stages.CompileStages
{
    internal class SelectStage : IQueryStage
    {
        public SqlTypeInfo TypeInfo { get; }

        public ParameterExpression ParameterExpression { get; }

        public Type CurrentType { get; }

        public FromAliases FromAliases { get; }

        public MemberInitExpression SelectExpression { get; }

        public Type OldType { get; }

        public ParameterExpression InParameterExpression { get; }

        public IImmutableList<ColumnMetadata> Columns { get; }

        public SelectStage(
            SqlTypeInfo sqlTypeInfo,
            ParameterExpression parameterExpression,
            MemberInitExpression selectExpression,
            Type newType,
            Type oldType,
            ParameterExpression inParameterExpression,
            FromAliases fromAliases,
            IImmutableList<ColumnMetadata> columns)
        {
            TypeInfo = sqlTypeInfo;
            ParameterExpression = parameterExpression;
            SelectExpression = selectExpression;
            CurrentType = newType;
            OldType = oldType;
            InParameterExpression = inParameterExpression;
            FromAliases = fromAliases;
            Columns = columns;
        }

        public void Accept(IQueryStageVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
