using Koralium.SqlParser.Visitor;
using System.Text;

namespace Koralium.SqlParser.GroupBy
{
    public class SelectStatementGroup : Group
    {
        public SelectStatement SelectStatement { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitSelectStatementGroup(this);
        }
    }
}
