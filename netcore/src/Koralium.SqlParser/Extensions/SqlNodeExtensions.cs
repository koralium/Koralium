using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser
{
    public static class SqlNodeExtensions
    {
        public static string Print(this SqlNode sqlNode)
        {
            PrintVisitor printVisitor = new PrintVisitor();
            return printVisitor.Print(sqlNode);
        }
    }
}
