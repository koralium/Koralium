using Koralium.SqlParser.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Literals
{
    public abstract class Literal : ScalarExpression
    {
        public abstract object GetValue();
    }
}
