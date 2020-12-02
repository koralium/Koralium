using Koralium.SqlParser.Visitor;
using System.Text;

namespace Koralium.SqlParser.Literals
{
    public class IntegerLiteral : Literal
    {
        public long Value { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitIntegerLiteral(this);
        }

        public override object GetValue()
        {
            return Value;
        }
    }
}
