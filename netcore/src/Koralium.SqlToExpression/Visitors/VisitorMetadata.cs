using Koralium.SqlToExpression.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Koralium.SqlToExpression.Visitors
{
    internal class VisitorMetadata
    {
        public SqlParameters Parameters { get; }

        public TablesMetadata TablesMetadata { get; }

        public VisitorMetadata(SqlParameters sqlParameters, TablesMetadata tablesMetadata)
        {
            Debug.Assert(tablesMetadata != null);

            if(sqlParameters != null)
            {
                Parameters = sqlParameters;
            }
            else
            {
                Parameters = new SqlParameters();
            }
            TablesMetadata = tablesMetadata;
        }
    }
}
