using Koralium.SqlParser.Expressions;
using System.Collections.Generic;

namespace Koralium.SqlToExpression.Visitors.Analyzers
{
    public static class ContainsAggregateHelper
    {
        public static bool ContainsAggregate(IList<SelectExpression> selectElements)
        {
            ContainsAggregateAnalyzer containsAggregateAnalyzer = new ContainsAggregateAnalyzer();
            foreach (var element in selectElements)
            {
                element.Accept(containsAggregateAnalyzer);
            }
            return containsAggregateAnalyzer.IsAggregate;
        }
    }
}
