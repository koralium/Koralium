using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.GroupBy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class GroupByCloneTests
    {
        [Test]
        public void TestCloneExpressionGroup()
        {
            ExpressionGroup expressionGroup = new ExpressionGroup()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "t" } }
            };

            var clone = expressionGroup.Clone() as ExpressionGroup;

            Assert.AreEqual(expressionGroup, clone);
            Assert.IsFalse(ReferenceEquals(expressionGroup, clone));
            Assert.IsFalse(ReferenceEquals(expressionGroup.Expression, clone.Expression));
        }

        [Test]
        public void TestCloneSelectStatementGroup()
        {
            SelectStatementGroup selectStatementGroup = new SelectStatementGroup()
            {
                SelectStatement = new SelectStatement()
                {
                    FromClause = new Clauses.FromClause() { TableReference = new FromTableReference() { TableName = "t" } }
                }
            };

            var clone = selectStatementGroup.Clone() as SelectStatementGroup;

            Assert.AreEqual(selectStatementGroup, clone);
            Assert.IsFalse(ReferenceEquals(selectStatementGroup, clone));
            Assert.IsFalse(ReferenceEquals(selectStatementGroup.SelectStatement, clone.SelectStatement));
        }
    }
}
