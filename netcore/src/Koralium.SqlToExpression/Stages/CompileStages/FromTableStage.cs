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
using System.Diagnostics;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Stages.CompileStages
{
    internal class FromTableStage : IQueryStage
    {
        public string TableName { get; }

        public SqlTypeInfo TypeInfo { get; }

        public ParameterExpression ParameterExpression { get; }

        public Type CurrentType { get; }

        public FromAliases FromAliases { get; }

        public FromTableStage(
            string tableName, 
            SqlTypeInfo sqlTypeInfo, 
            ParameterExpression parameterExpression, 
            Type currentType,
            FromAliases fromAliases)
        {
            Debug.Assert(tableName != null, $"{nameof(tableName)} was null");
            Debug.Assert(sqlTypeInfo != null, $"{nameof(sqlTypeInfo)} was null");
            Debug.Assert(parameterExpression != null, $"{nameof(parameterExpression)} was null");
            Debug.Assert(currentType != null, $"{nameof(currentType)} was null");
            Debug.Assert(fromAliases != null, $"{nameof(fromAliases)} was null");

            TableName = tableName;
            TypeInfo = sqlTypeInfo;
            ParameterExpression = parameterExpression;
            CurrentType = currentType;
            FromAliases = fromAliases;
        }

        public void Accept(IQueryStageVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
