using Koralium.SqlParser.Visitor;
using System.Collections.Generic;

namespace Koralium.SqlParser.Expressions
{
    public class InExpression : BooleanExpression
    {
        public ScalarExpression Expression{ get; set; }

        public List<ScalarExpression> Values { get; set; }

        /// <summary>
        /// Is it a NOT IN?
        /// </summary>
        public bool Not { get; set; }

        public InExpression()
        {
            Values = new List<ScalarExpression>();
        }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitInExpression(this);
        }
    }
}
