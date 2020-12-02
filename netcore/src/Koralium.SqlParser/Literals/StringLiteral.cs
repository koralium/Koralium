using Koralium.SqlParser.Visitor;
using System.Text;

namespace Koralium.SqlParser.Literals
{
    public class StringLiteral : Literal
    {
        public string Value { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitStringLiteral(this);
        }

        public override object GetValue()
        {
            return Value;
        }
    }
}
