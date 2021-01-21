using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.RowLevelSecurity
{
    class AddAliasVisitor : KoraliumSqlVisitor
    {
        private readonly string _tableAlias;

        public AddAliasVisitor(string tableAlias)
        {
            _tableAlias = tableAlias;
        }

        public override void VisitColumnReference(ColumnReference columnReference)
        {
            //Add the alias to the front
            columnReference.Identifiers.Insert(0, _tableAlias);
        }
    }
}
