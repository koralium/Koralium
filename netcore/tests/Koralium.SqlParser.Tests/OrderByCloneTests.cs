using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.OrderBy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class OrderByCloneTests
    {
        [Test]
        public void TestCloneOrderBySubquery()
        {
            OrderBySubquery orderBySubquery = new OrderBySubquery()
            {
                Ascending = false,
                SelectStatement = new SelectStatement()
                {
                    FromClause = new Clauses.FromClause() { TableReference = new FromTableReference() { TableName = "t" } }
                }
            };

            var clone = orderBySubquery.Clone() as OrderBySubquery;
            Assert.AreEqual(orderBySubquery, clone);
            Assert.IsFalse(ReferenceEquals(orderBySubquery, clone));
            Assert.IsFalse(ReferenceEquals(orderBySubquery.SelectStatement, clone.SelectStatement));
        }

        [Test]
        public void TestCloneOrderExpression()
        {
            OrderExpression orderExpression = new OrderExpression()
            {
                Ascending = true,
                Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
            };

            var clone = orderExpression.Clone() as OrderExpression;
            Assert.AreEqual(orderExpression, clone);
            Assert.IsFalse(ReferenceEquals(orderExpression, clone));
            Assert.IsFalse(ReferenceEquals(orderExpression.Expression, clone.Expression));
        }
    }
}
