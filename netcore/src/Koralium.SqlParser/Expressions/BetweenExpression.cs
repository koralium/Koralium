using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public class BetweenExpression : BooleanExpression
    {
        public ScalarExpression Expression { get; set; }

        public ScalarExpression From { get; set; }

        public ScalarExpression To { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitBetweenExpression(this);
        }

        public override SqlNode Clone()
        {
            return new BetweenExpression()
            {
                Expression = Expression.Clone() as ScalarExpression,
                From = From.Clone() as ScalarExpression,
                To = To.Clone() as ScalarExpression
            };
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Expression, From, To);
        }

        public override bool Equals(object obj)
        {
            if (obj is BetweenExpression other)
            {
                return Equals(Expression, other.Expression) &&
                    Equals(From, other.From) &&
                    Equals(To, other.To);
            }
            return false;
        }
    }
}
