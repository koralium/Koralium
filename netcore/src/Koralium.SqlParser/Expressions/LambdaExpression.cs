using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public class LambdaExpression : SqlExpression
    {
        public List<string> Parameters { get; set; }

        public SqlExpression Expression { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitLambdaExpression(this);
        }

        public override SqlNode Clone()
        {
            return new LambdaExpression()
            {
                Parameters = Parameters.ToList(),
                Expression = Expression.Clone() as SqlExpression
            };
        }

        public override bool Equals(object obj)
        {
            return obj is LambdaExpression expression &&
                Parameters.AreEqual(expression.Parameters) &&
                Equals(Expression, expression.Expression);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            foreach(var v in Parameters)
            {
                hashCode.Add(v);
            }
            hashCode.Add(Expression);
            return hashCode.ToHashCode();
        }
    }
}
