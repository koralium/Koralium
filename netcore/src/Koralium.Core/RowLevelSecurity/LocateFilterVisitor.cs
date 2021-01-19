using Koralium.SqlParser;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.RowLevelSecurity
{
    class LocateFilterVisitor : KoraliumSqlVisitor
    {
        private readonly BooleanExpression _toFind;
        public bool Exists { get; private set; } = false;

        public LocateFilterVisitor(BooleanExpression toFind)
        {
            _toFind = toFind;
        }

        public override void Visit(SqlNode sqlNode)
        {
            if (Equals(_toFind, sqlNode))
            {
                Exists = true;
                return;
            }
            base.Visit(sqlNode);
        }

        public override void VisitBooleanBinaryExpression(BooleanBinaryExpression booleanBinaryExpression)
        {
            if( booleanBinaryExpression.Type == BooleanBinaryType.AND)
            {
                //Only go deeper if we are in an AND
                base.VisitBooleanBinaryExpression(booleanBinaryExpression);
            }
        }
    }
}
