using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;

namespace Koralium.SqlToExpression.Visitors.Select
{
    internal interface ISelectVisitor
    {
        IReadOnlyList<SelectExpression> SelectExpressions { get; }

        void VisitSelect(TSqlFragment sqlFragment);
    }
}
