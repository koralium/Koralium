using Koralium.SqlParser.Clauses;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.GroupBy;
using Koralium.SqlParser.Literals;
using Koralium.SqlParser.OrderBy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class ClausesCloneTests
    {
        [Test]
        public void TestCloneFromClause()
        {
            FromClause fromClause = new FromClause()
            {
                TableReference = new FromTableReference()
                {
                    Alias = "test",
                    TableName = "t"
                }
            };

            var clone = fromClause.Clone() as FromClause;

            Assert.AreEqual(fromClause, clone);
            Assert.IsFalse(ReferenceEquals(fromClause, clone));
            Assert.IsFalse(ReferenceEquals(fromClause.TableReference, clone.TableReference));
        }

        [Test]
        public void TestCloneGroupByClause()
        {
            GroupByClause groupByClause = new GroupByClause()
            {
                Groups = new List<GroupBy.Group>()
                {
                    new ExpressionGroup()
                    {
                        Expression = new ColumnReference(){ Identifiers = new List<string>() { "c1" } }
                    }
                }
            };

            var clone = groupByClause.Clone() as GroupByClause;

            Assert.AreEqual(groupByClause, clone);
            Assert.IsFalse(ReferenceEquals(groupByClause, clone));
            Assert.IsFalse(ReferenceEquals(groupByClause.Groups, clone.Groups));

            for (int i = 0; i < groupByClause.Groups.Count; i++)
            {
                Assert.IsFalse(ReferenceEquals(groupByClause.Groups[i], clone.Groups[i]));
            }
        }

        [Test]
        public void TestCloneHavingClause()
        {
            HavingClause havingClause = new HavingClause()
            {
                Expression = new BooleanScalarExpression()
                {
                    ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
                }
            };

            var clone = havingClause.Clone() as HavingClause;

            Assert.AreEqual(havingClause, clone);
            Assert.IsFalse(ReferenceEquals(havingClause, clone));
            Assert.IsFalse(ReferenceEquals(havingClause.Expression, clone.Expression));
        }

        [Test]
        public void TestCloneOffsetLimitClause()
        {
            OffsetLimitClause offsetLimitClause = new OffsetLimitClause()
            {
                Limit = new IntegerLiteral() { Value = 3 },
                Offset = new IntegerLiteral() { Value = 17 }
            };

            var clone = offsetLimitClause.Clone() as OffsetLimitClause;

            Assert.AreEqual(offsetLimitClause, clone);
            Assert.IsFalse(ReferenceEquals(offsetLimitClause, clone));
            Assert.IsFalse(ReferenceEquals(offsetLimitClause.Limit, clone.Limit));
            Assert.IsFalse(ReferenceEquals(offsetLimitClause.Offset, clone.Offset));
        }

        [Test]
        public void TestCloneOrderByClause()
        {
            OrderByClause orderByClause = new OrderByClause()
            {
                OrderExpressions = new List<OrderBy.OrderElement>()
                {
                    new OrderExpression()
                    {
                        Ascending = true,
                        Expression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
                    }
                }
            };

            var clone = orderByClause.Clone() as OrderByClause;

            Assert.AreEqual(orderByClause, clone);
            Assert.IsFalse(ReferenceEquals(orderByClause, clone));
            Assert.IsFalse(ReferenceEquals(orderByClause.OrderExpressions, clone.OrderExpressions));

            for (int i = 0; i < orderByClause.OrderExpressions.Count; i++)
            {
                Assert.IsFalse(ReferenceEquals(orderByClause.OrderExpressions[i], clone.OrderExpressions[i]));
            }
        }

        [Test]
        public void TestCloneWhereClause()
        {
            WhereClause whereClause = new WhereClause()
            {
                Expression = new BooleanScalarExpression()
                {
                    ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
                }
            };

            var clone = whereClause.Clone() as WhereClause;

            Assert.AreEqual(whereClause, clone);
            Assert.IsFalse(ReferenceEquals(whereClause, clone));
            Assert.IsFalse(ReferenceEquals(whereClause.Expression, clone.Expression));
        }
    }
}
