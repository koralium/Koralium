using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public abstract class SelectExpression : SqlExpression
    {
        public string Alias { get; set; }
    }
}
