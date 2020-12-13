using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.Literals
{
    public class StringLiteral : Literal
    {
        public string Value { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitStringLiteral(this);
        }

        public override SqlNode Clone()
        {
            return new StringLiteral()
            {
                Value = Value
            };
        }

        public override object GetValue()
        {
            return Value;
        }
    }
}
