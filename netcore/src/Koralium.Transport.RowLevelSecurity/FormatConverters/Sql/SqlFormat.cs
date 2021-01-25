using Koralium.SqlParser;
using Koralium.SqlParser.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters
{
    static class SqlFormat
    {
        public static string Format(BooleanExpression booleanExpression)
        {
            return booleanExpression.Print();
        }
    }
}
