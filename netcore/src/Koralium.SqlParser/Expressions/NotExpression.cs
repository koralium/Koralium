using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public class NotExpression : BooleanExpression
    {
        public BooleanExpression BooleanExpression { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitNotExpression(this);
        }

        public override SqlNode Clone()
        {
            return new NotExpression()
            {
                BooleanExpression = BooleanExpression.Clone() as BooleanExpression
            };
        }
    }
}
