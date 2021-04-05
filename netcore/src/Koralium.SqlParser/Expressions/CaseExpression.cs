using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public class CaseExpression : ScalarExpression
    {
        public List<WhenExpression> WhenExpressions { get; set; }

        public ScalarExpression ElseExpression { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitCaseExpression(this);
        }

        public override SqlNode Clone()
        {
            return new CaseExpression()
            {
                ElseExpression = ElseExpression.Clone() as ScalarExpression,
                WhenExpressions = WhenExpressions.Select(x => x.Clone() as WhenExpression).ToList()
            };
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(ElseExpression);

            foreach (var whenExpression in WhenExpressions)
            {
                hashCode.Add(whenExpression);
            }

            return hashCode.ToHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is CaseExpression other)
            {
                return Equals(ElseExpression, other.ElseExpression) &&
                    WhenExpressions.AreEqual(other.WhenExpressions);
            }
            return false;
        }
    }
}
