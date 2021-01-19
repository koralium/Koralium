using Koralium.SqlParser;
using Koralium.SqlParser.From;
using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.RowLevelSecurity
{
    /// <summary>
    /// Visitor that only locates which table is involved.
    /// </summary>
    class TableLocatorVisitor : KoraliumSqlVisitor
    {
        public string TableName { get; private set; }

        public override void VisitFromTableReference(FromTableReference fromTableReference)
        {
            TableName = fromTableReference.TableName;
        }

        public override void VisitSelectStatement(SelectStatement selectStatement)
        {
            //Only visit the from clause to skip checking uneccessary nodes
            Visit(selectStatement.FromClause);
        }
    }
}
