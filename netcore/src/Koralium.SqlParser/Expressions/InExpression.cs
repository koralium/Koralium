using Koralium.SqlParser.Visitor;
using System.Collections.Generic;
using System.Linq;

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

        public override SqlNode Clone()
        {
            return new InExpression()
            {
                Expression = Expression.Clone() as ScalarExpression,
                Not = Not,
                Values = Values.Select(x => x.Clone() as ScalarExpression).ToList()
            };
        }
    }
}
