using Koralium.SqlToExpression.Models;
using System;
using System.Collections.Immutable;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Stages.CompileStages
{
    class OrderByStage : IQueryStage
    {
        public SqlTypeInfo TypeInfo { get; }

        public ParameterExpression ParameterExpression { get; }

        public Type CurrentType { get; }

        public FromAliases FromAliases { get; }

        internal IImmutableList<SortItem> SortItems { get; }

        public OrderByStage(
            Type currentType,
            SqlTypeInfo typeInfo,
            ParameterExpression parameterExpression,
            FromAliases fromAliases,
            IImmutableList<SortItem> sortItems)
        {
            CurrentType = currentType;
            TypeInfo = typeInfo;
            ParameterExpression = parameterExpression;
            FromAliases = fromAliases;
            SortItems = sortItems;
        }

        public void Accept(IQueryStageVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
