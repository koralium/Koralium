using Koralium.SqlToExpression.Models;
using System;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Stages.CompileStages
{
    /// <summary>
    /// This is a base stage for all operations under a group by
    /// </summary>
    internal abstract class GroupedStage : IQueryStage
    {
        public abstract SqlTypeInfo TypeInfo { get; }
        public abstract ParameterExpression ParameterExpression { get; }
        public abstract Type CurrentType { get; }
        public abstract FromAliases FromAliases { get; }

        /// <summary>
        /// Contains the type info for the keys from the group by
        /// </summary>
        internal abstract SqlTypeInfo KeyTypeInfo { get; }

        /// <summary>
        /// Contains the parameter expression to access values under the key
        /// 
        /// This should first handle the member access from the IGrouping.
        /// </summary>
        internal abstract Expression KeyParameterExpression { get; }

        /// <summary>
        /// Contains the parameter expression to access the other fields, for aggregations
        /// </summary>
        internal abstract ParameterExpression ValueParameterExpression { get; }

        internal abstract Type ValueType { get; }

        public abstract void Accept(IQueryStageVisitor visitor);
    }
}
