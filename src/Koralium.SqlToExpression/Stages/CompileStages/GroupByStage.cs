using Koralium.SqlToExpression.Models;
using System;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Stages.CompileStages
{
    internal class GroupByStage : GroupedStage
    {
        public override SqlTypeInfo TypeInfo { get; }

        public override ParameterExpression ParameterExpression { get; }

        public override Type CurrentType { get; }

        internal override SqlTypeInfo KeyTypeInfo { get; }

        internal override Expression KeyParameterExpression { get; }

        internal override ParameterExpression ValueParameterExpression { get; }

        internal override Type ValueType { get; }

        public Expression GroupByExpression { get; }

        public Type KeyType { get; }

        public override FromAliases FromAliases { get; }

        public GroupByStage(
            Type currentType,
            Type valueType,
            SqlTypeInfo mainTypeInfo,
            SqlTypeInfo keyTypeInfo,
            ParameterExpression groupParameterExpression,
            Expression keyParameterExpression,
            ParameterExpression valueParameterExpression,
            Expression groupByExpression,
            Type keyType,
            FromAliases fromAliases)
        {
            CurrentType = currentType;
            ValueType = valueType;
            TypeInfo = mainTypeInfo;
            KeyTypeInfo = keyTypeInfo;
            ParameterExpression = groupParameterExpression;
            KeyParameterExpression = keyParameterExpression;
            ValueParameterExpression = valueParameterExpression;
            GroupByExpression = groupByExpression;
            KeyType = keyType;
            FromAliases = fromAliases;
        }

        public override void Accept(IQueryStageVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
