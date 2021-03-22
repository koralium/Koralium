using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public class NewObjectExpression : ScalarExpression
    {
        public List<ScalarExpressionWithAlias> Fields { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitNewObjectExpression(this);
        }

        public override SqlNode Clone()
        {
            return new NewObjectExpression()
            {
                Fields = Fields.Select(x => x.Clone() as ScalarExpressionWithAlias).ToList()
            };
        }
    }
}
