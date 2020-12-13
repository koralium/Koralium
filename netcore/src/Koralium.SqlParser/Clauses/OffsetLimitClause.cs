using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;

namespace Koralium.SqlParser.Clauses
{
    public class OffsetLimitClause : SqlNode
    {
        public ScalarExpression Offset { get; set; }

        public ScalarExpression Limit { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitOffsetLimitClause(this);
        }

        public override SqlNode Clone()
        {
            return new OffsetLimitClause()
            {
                Limit = Limit.Clone() as ScalarExpression,
                Offset = Offset.Clone() as ScalarExpression
            };
        }
    }
}
