using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.Expressions
{
    public class BinaryExpression : ScalarExpression
    {
        public ScalarExpression Left { get; set; }

        public ScalarExpression Right { get; set; }

        public BinaryType Type { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitBinaryExpression(this);
        }

        public override SqlNode Clone()
        {
            return new BinaryExpression()
            {
                Left = Left.Clone() as ScalarExpression,
                Right = Right.Clone() as ScalarExpression,
                Type = Type
            };
        }
    }
}
