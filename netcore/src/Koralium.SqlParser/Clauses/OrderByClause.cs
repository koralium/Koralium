using Koralium.SqlParser.OrderBy;
using Koralium.SqlParser.Visitor;
using System.Collections.Generic;
using System.Linq;

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

        public override SqlNode Clone()
        {
            return new OrderByClause()
            {
                OrderExpressions = OrderExpressions.Select(x => x.Clone() as OrderElement).ToList()
            };
        }
    }
}
