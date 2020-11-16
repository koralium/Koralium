using Koralium.SqlParser.Clauses;
using Koralium.SqlToExpression.Stages.CompileStages;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Koralium.SqlToExpression.Visitors.Where
{
    internal static class WhereHelper
    {
        public static WhereStage GetWhereStage(
            IQueryStage previousStage,
            WhereClause whereClause,
            VisitorMetadata visitorMetadata,
            HashSet<PropertyInfo> usedProperties)
        {
            WhereVisitor whereVisitor = new WhereVisitor(previousStage, visitorMetadata);
            whereClause.Accept(whereVisitor);

            foreach (var property in whereVisitor.UsedProperties)
            {
                usedProperties.Add(property);
            }

            return new WhereStage(
                previousStage.TypeInfo,
                previousStage.ParameterExpression,
                whereVisitor.Expression,
                previousStage.CurrentType,
                previousStage.FromAliases,
                whereVisitor.ContainsFullTextSearch
                );
        }
    }
}
