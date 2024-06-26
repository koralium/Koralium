﻿/*
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
