using Koralium.SqlToExpression.Models;
using System;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Stages.CompileStages
{
    /// <summary>
    /// THis stage handles statements like:
    /// OFFSET 100 ROWS FETCH NEXt 100 ROWS ONLY
    /// </summary>
    internal class OffsetStage : IQueryStage
    {
        public SqlTypeInfo TypeInfo { get; }

        public ParameterExpression ParameterExpression { get; }

        public Expression WhereExpression { get; }

        public Type CurrentType { get; }

        public FromAliases FromAliases { get; }

        public int? Skip { get; }

        public int? Take { get; }

        public OffsetStage(
            SqlTypeInfo sqlTypeInfo,
            ParameterExpression parameterExpression,
            Type type,
            FromAliases fromAliases,
            int? skip,
            int? take
            )
        {
            TypeInfo = sqlTypeInfo;
            ParameterExpression = parameterExpression;
            CurrentType = type;
            FromAliases = fromAliases;
            Skip = skip;
            Take = take;
        }

        public void Accept(IQueryStageVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
