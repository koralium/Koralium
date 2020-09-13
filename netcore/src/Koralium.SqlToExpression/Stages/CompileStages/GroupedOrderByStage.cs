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
