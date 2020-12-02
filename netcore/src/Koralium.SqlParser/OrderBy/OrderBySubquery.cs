using Koralium.SqlParser.Visitor;
using System.Text;

namespace Koralium.SqlParser.OrderBy
{
    public class OrderBySubquery : OrderElement
    {
        public SelectStatement SelectStatement { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitOrderBySubquery(this);
        }
    }
}
