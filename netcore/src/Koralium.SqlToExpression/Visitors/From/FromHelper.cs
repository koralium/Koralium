using Koralium.SqlToExpression.Extensions;
using Koralium.SqlToExpression.Metadata;
using Koralium.SqlToExpression.Stages.CompileStages;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Koralium.SqlToExpression.Visitors.From
{
    internal static class FromHelper
    {
        public static IEnumerable<IQueryStage> GetFromTableStage(FromClause fromClause, VisitorMetadata visitorMetadata)
        {
            FromVisitor fromVisitor = new FromVisitor(visitorMetadata);
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
                stages.Add(new FromTableStage(fromVisitor.Table.Name, type.ToSqlTypeInfo(), Expression.Parameter(type), type, fromVisitor.FromAliases));
            }

            return stages;
        }
    }
}
