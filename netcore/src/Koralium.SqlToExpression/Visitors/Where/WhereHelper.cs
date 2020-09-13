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
using Koralium.SqlToExpression.Stages.CompileStages;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Koralium.SqlToExpression.Visitors.Where
{
    internal static class WhereHelper
    {
        public static WhereStage GetWhereStage(IQueryStage previousStage, WhereClause whereClause, VisitorMetadata visitorMetadata)
        {
            WhereVisitor whereVisitor = new WhereVisitor(previousStage, visitorMetadata);
            whereClause.Accept(whereVisitor);

            return new WhereStage(
                previousStage.TypeInfo,
                previousStage.ParameterExpression,
                whereVisitor.Expression,
                previousStage.CurrentType,
                previousStage.FromAliases
                );
        }
    }
}
