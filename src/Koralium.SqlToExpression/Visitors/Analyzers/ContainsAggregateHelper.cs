using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;

namespace Koralium.SqlToExpression.Visitors.Analyzers
{
    public static class ContainsAggregateHelper
    {
        public static bool ContainsAggregate(IList<SelectElement> selectElements)
        {
            ContainsAggregateAnalyzer containsAggregateAnalyzer = new ContainsAggregateAnalyzer();
            foreach(var element in selectElements)
            {
                element.Accept(containsAggregateAnalyzer);
            }
            return containsAggregateAnalyzer.IsAggregate;
        }
    }
}
