using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.From
{
    public class FromTableReference : TableReference
    {
        public string TableName { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitFromTableReference(this);
        }
    }
}
