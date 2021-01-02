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
    }
}
