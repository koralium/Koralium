using Koralium.SqlToExpression.Models;
using System;
using System.Collections.Immutable;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Stages.CompileStages
{
    internal class GroupedOrderByStage : GroupedStage
    {
        internal override SqlTypeInfo KeyTypeInfo { get; }

        internal override Expression KeyParameterExpression { get; }

        internal override ParameterExpression ValueParameterExpression { get; }

        internal override Type ValueType { get; }

        public override SqlTypeInfo TypeInfo { get; }

        public override ParameterExpression ParameterExpression { get; }

        public override Type CurrentType { get; }

        public override FromAliases FromAliases { get; }

        internal IImmutableList<SortItem> SortItems { get; }

        public GroupedOrderByStage(
            Type currentType,
            Type valueType,
            SqlTypeInfo mainTypeInfo,
            SqlTypeInfo keyTypeInfo,
            ParameterExpression groupParameterExpression,
            Expression keyParameterExpression,
            ParameterExpression valueParameterExpression,
            FromAliases fromAliases,
            IImmutableList<SortItem> sortItems)
        {
            CurrentType = currentType;
            ValueType = valueType;
            TypeInfo = mainTypeInfo;
            KeyTypeInfo = keyTypeInfo;
            ParameterExpression = groupParameterExpression;
            KeyParameterExpression = keyParameterExpression;
            ValueParameterExpression = valueParameterExpression;
            FromAliases = fromAliases;
            SortItems = sortItems;
        }

        public override void Accept(IQueryStageVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
