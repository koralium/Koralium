using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public class WhenExpression : SqlNode
    {
        public BooleanExpression BooleanExpression { get; set; }

        public ScalarExpression ScalarExpression { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitWhenExpression(this);
        }

        public override SqlNode Clone()
        {
            return new WhenExpression()
            {
                BooleanExpression = BooleanExpression.Clone() as BooleanExpression,
                ScalarExpression = ScalarExpression.Clone() as ScalarExpression
            };
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BooleanExpression, ScalarExpression);
        }

        public override bool Equals(object obj)
        {
            if (obj is WhenExpression other)
            {
                return Equals(BooleanExpression, other.BooleanExpression) &&
                    Equals(ScalarExpression, other.ScalarExpression);
            }
            return false;
        }
    }
}
