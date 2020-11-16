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
using Koralium.SqlToExpression.Extensions;
using Koralium.SqlToExpression.Stages.CompileStages;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors.From
{
    internal static class FromHelper_old
    {
        public static IReadOnlyList<IQueryStage> GetFromTableStage(FromClause fromClause, VisitorMetadata visitorMetadata)
        {
            FromVisitor_old fromVisitor = new FromVisitor_old(visitorMetadata);
            fromClause.Accept(fromVisitor);

            List<IQueryStage> stages = new List<IQueryStage>();

            if(fromVisitor.Stages != null)
            {
                var lastStage = fromVisitor.Stages.Last();
                lastStage.FromAliases.Clear();
                foreach(var alias in fromVisitor.FromAliases.Aliases)
                {
                    lastStage.FromAliases.AddAlias(alias);
                }
                
                stages.AddRange(fromVisitor.Stages);
            }
            else
            {
                var type = fromVisitor.Table.Type;

                if(fromVisitor.Table.StringOperationsProvider != null)
                {
                    visitorMetadata.StringOperationsProvider = fromVisitor.Table.StringOperationsProvider;
                }

                stages.Add(new FromTableStage(
                    fromVisitor.Table.Name,
                    type.ToSqlTypeInfo(), 
                    Expression.Parameter(type), 
                    type, 
                    fromVisitor.FromAliases,
                    visitorMetadata.Parameters));
            }

            return stages;
        }
    }
}
