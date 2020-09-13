/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
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
