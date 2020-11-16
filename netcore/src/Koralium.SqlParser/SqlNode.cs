using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser
{
    public abstract class SqlNode
    {
        public abstract void Accept(KoraliumSqlVisitor visitor);
    }
}
