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
