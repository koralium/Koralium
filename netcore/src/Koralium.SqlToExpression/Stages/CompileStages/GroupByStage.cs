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
