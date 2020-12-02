using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.From
{
    public class Subquery : TableReference
    {
        public SelectStatement SelectStatement { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitSubquery(this);
        }
    }
}
