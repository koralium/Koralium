using Koralium.SqlParser.OrderBy;
using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Clauses
{
    public class OrderByClause : SqlNode
    {
        public List<OrderElement> OrderExpressions { get; set; }

        public OrderByClause()
        {
            OrderExpressions = new List<OrderElement>();
        }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitOrderByClause(this);
        }
    }
}
