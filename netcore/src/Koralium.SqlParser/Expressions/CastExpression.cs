using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public class CastExpression : ScalarExpression
    {
        public ScalarExpression ScalarExpression { get; set; }

        public string ToType { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitCastExpression(this);
        }

        public override SqlNode Clone()
        {
            return new CastExpression()
            {
                ScalarExpression = ScalarExpression.Clone() as ScalarExpression,
                ToType = ToType
            };
        }
    }
}
