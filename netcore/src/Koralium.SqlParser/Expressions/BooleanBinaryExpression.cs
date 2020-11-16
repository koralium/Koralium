using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public class BooleanBinaryExpression : BooleanExpression
    {
        public BooleanExpression Left { get; set; }

        public BooleanExpression Right { get; set; }

        public BooleanBinaryType Type { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitBooleanBinaryExpression(this);
        }
    }
}
