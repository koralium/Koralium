using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.From
{
    public abstract class TableReference : SqlNode
    {
        public string Alias { get; set; }
    }
}
