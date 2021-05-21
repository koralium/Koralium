using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.OrderBy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class OrderByEqualsTests
    {
        [Test]
        public void TestOrderBySubqueryEquals()
        {
            OrderBySubquery first = new OrderBySubquery()
            {
                Ascending = false,
                SelectStatement = new SelectStatement()
                {
                    FromClause = new Clauses.FromClause() { TableReference = new FromTableReference() { TableName = "t" } }
                }
            };

            OrderBySubquery firstClone = new OrderBySubquery()
            {
                Ascending = false,
                SelectStatement = new SelectStatement()
                {
                    FromClause = new Clauses.FromClause() { TableReference = new FromTableReference() { TableName = "t" } }
                }
            };

            OrderBySubquery second = new OrderBySubquery()
            {
                Ascending = true,
                SelectStatement = new SelectStatement()
                {
                    FromClause = new Clauses.FromClause() { TableReference = new FromTableReference() { TableName = "t" } }
                }
            };

            OrderBySubquery third = new OrderBySubquery()
            {
                Ascending = false,
                SelectStatement = new SelectStatement()
                {
                    FromClause = new Clauses.FromClause() { TableReference = new FromTableReference() { TableName = "t2" } }
                }
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));
            Assert.IsFalse(Equals(first, third));
            Assert.IsFalse(Equals(first, "other type"));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), third.GetHashCode());
        }

        [Test]
        public void TestOrderExpressionEquals()
        {
            OrderExpression first = new OrderExpression()
            {
                Ascending = true,
                Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
            };

            OrderExpression firstClone = new OrderExpression()
            {
                Ascending = true,
                Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
            };

            OrderExpression second = new OrderExpression()
            {
                Ascending = false,
                Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
            };

            OrderExpression third = new OrderExpression()
            {
                Ascending = true,
                Expression = new ColumnReference() { Identifiers = new List<string>() { "c2" } }
            };

            //Equals
            Assert.IsTrue(Equals(first, firstClone));
            Assert.IsFalse(Equals(first, null));
            Assert.IsFalse(Equals(first, second));
            Assert.IsFalse(Equals(first, third));
            Assert.IsFalse(Equals(first, "other type"));

            //Hash code
            Assert.AreEqual(first.GetHashCode(), firstClone.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), third.GetHashCode());
        }
    }
}
