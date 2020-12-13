using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.OrderBy
{
    public class OrderBySubquery : OrderElement
    {
        public SelectStatement SelectStatement { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitOrderBySubquery(this);
        }

        public override SqlNode Clone()
        {
            return new OrderBySubquery()
            {
                Ascending = Ascending,
                SelectStatement = SelectStatement.Clone() as SelectStatement
            };
        }
    }
}
