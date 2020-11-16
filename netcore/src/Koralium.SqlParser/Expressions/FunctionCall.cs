using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public class FunctionCall : ScalarExpression
    {
        public string FunctionName { get; set; }

        /// <summary>
        /// Is a wildcard used as parameter?
        /// </summary>
        public bool Wildcard { get; set; }

        public List<ScalarExpression> Parameters { get; set; }

        public FunctionCall()
        {
            Parameters = new List<ScalarExpression>();
        }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitFunctionCall(this);
        }
    }
}
