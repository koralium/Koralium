using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public class ColumnReference : ScalarExpression
    {
        public List<string> Identifiers { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitColumnReference(this);
        }

        public ColumnReference()
        {
            Identifiers = new List<string>();
        }
    }
}
