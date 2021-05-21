using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.GroupBy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class GroupByEqualsTests
    {
        [Test]
        public void TestExpressionGroupEquals()
        {
            ExpressionGroup first = new ExpressionGroup()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "t" } }
            };

            ExpressionGroup firstClone = new ExpressionGroup()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "t" } }
            };

            ExpressionGroup second = new ExpressionGroup()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "t2" } }
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));
            Assert.IsFalse(Equals(first, "other type"));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        }

        [Test]
        public void TestSelectStatementGroupEquals()
        {
            SelectStatementGroup first = new SelectStatementGroup()
            {
                SelectStatement = new SelectStatement()
                {
                    FromClause = new Clauses.FromClause() { TableReference = new FromTableReference() { TableName = "t" } }
                }
            };

            SelectStatementGroup firstClone = new SelectStatementGroup()
            {
                SelectStatement = new SelectStatement()
                {
                    FromClause = new Clauses.FromClause() { TableReference = new FromTableReference() { TableName = "t" } }
                }
            };

            SelectStatementGroup second = new SelectStatementGroup()
            {
                SelectStatement = new SelectStatement()
                {
                    FromClause = new Clauses.FromClause() { TableReference = new FromTableReference() { TableName = "t2" } }
                }
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));
            Assert.IsFalse(Equals(first, "other type"));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        }
    }
}
