using Koralium.SqlParser;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Koralium.SqlToExpression.Visitors.Select
{
    internal interface ISelectVisitor
    {
        IReadOnlyList<SelectExpression> SelectExpressions { get; }

        IEnumerable<PropertyInfo> UsedProperties { get; }

        void VisitSelect(SqlNode sqlNode);
    }
}
