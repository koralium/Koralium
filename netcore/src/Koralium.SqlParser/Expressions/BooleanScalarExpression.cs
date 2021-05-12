using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public class BooleanScalarExpression : BooleanExpression
    {
        public ScalarExpression ScalarExpression { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitBooleanScalarExpression(this);
        }

        public override SqlNode Clone()
        {
            return new BooleanScalarExpression()
            {
                ScalarExpression = ScalarExpression.Clone() as ScalarExpression
            };
        }

        public override bool Equals(object obj)
        {
            return obj is BooleanScalarExpression expression &&
                   Equals(ScalarExpression, expression.ScalarExpression);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ScalarExpression);
        }
    }
}
