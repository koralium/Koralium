using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public class ScalarExpressionWithAlias : SqlNode
    {
        public ScalarExpression ScalarExpression { get; set; }

        public string Alias { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitScalarExpressionWithAlias(this);
        }

        public override SqlNode Clone()
        {
            return new ScalarExpressionWithAlias()
            {
                Alias = Alias,
                ScalarExpression = ScalarExpression.Clone() as ScalarExpression
            };
        }
    }
}
