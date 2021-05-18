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
    public class ClausesEqualsTests
    {
        [Test]
        public void TestFromClauseEquals()
        {
            FromClause first = new FromClause()
            {
                TableReference = new FromTableReference()
                {
                    Alias = "test",
                    TableName = "t"
                }
            };

            FromClause firstClone = new FromClause()
            {
                TableReference = new FromTableReference()
                {
                    Alias = "test",
                    TableName = "t"
                }
            };

            FromClause second = new FromClause()
            {
                TableReference = new FromTableReference()
                {
                    Alias = "test2",
                    TableName = "t"
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

        [Test]
        public void TestGroupByClauseEquals()
        {
            GroupByClause first = new GroupByClause()
            {
                Groups = new List<GroupBy.Group>()
                {
                    new ExpressionGroup()
                    {
                        Expression = new ColumnReference(){ Identifiers = new List<string>() { "c1" } }
                    }
                }
            };

            GroupByClause firstClone = new GroupByClause()
            {
                Groups = new List<GroupBy.Group>()
                {
                    new ExpressionGroup()
                    {
                        Expression = new ColumnReference(){ Identifiers = new List<string>() { "c1" } }
                    }
                }
            };

            GroupByClause second = new GroupByClause()
            {
                Groups = new List<GroupBy.Group>()
                {
                    new ExpressionGroup()
                    {
                        Expression = new ColumnReference(){ Identifiers = new List<string>() { "c2" } }
                    }
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

        [Test]
        public void TestHavingClauseEquals()
        {
            HavingClause first = new HavingClause()
            {
                Expression = new BooleanScalarExpression()
                {
                    ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
                }
            };

            HavingClause firstClone = new HavingClause()
            {
                Expression = new BooleanScalarExpression()
                {
                    ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
                }
            };

            HavingClause second = new HavingClause()
            {
                Expression = new BooleanScalarExpression()
                {
                    ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c2" } }
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

        [Test]
        public void TestOffsetLimitClauseEquals()
        {
            OffsetLimitClause first = new OffsetLimitClause()
            {
                Limit = new IntegerLiteral() { Value = 3 },
                Offset = new IntegerLiteral() { Value = 17 }
            };

            OffsetLimitClause firstClone = new OffsetLimitClause()
            {
                Limit = new IntegerLiteral() { Value = 3 },
                Offset = new IntegerLiteral() { Value = 17 }
            };

            OffsetLimitClause second = new OffsetLimitClause()
            {
                Limit = new IntegerLiteral() { Value = 4 },
                Offset = new IntegerLiteral() { Value = 17 }
            };

            OffsetLimitClause third = new OffsetLimitClause()
            {
                Limit = new IntegerLiteral() { Value = 3 },
                Offset = new IntegerLiteral() { Value = 18 }
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
        public void TestOrderByClauseEquals()
        {
            OrderByClause first = new OrderByClause()
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

            OrderByClause firstClone = new OrderByClause()
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

            OrderByClause second = new OrderByClause()
            {
                OrderExpressions = new List<OrderBy.OrderElement>()
                {
                    new OrderExpression()
                    {
                        Ascending = true,
                        Expression = new ColumnReference() { Identifiers = new List<string>() { "c2" } }
                    }
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

        [Test]
        public void TestWhereClauseEquals()
        {
            WhereClause first = new WhereClause()
            {
                Expression = new BooleanScalarExpression()
                {
                    ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
                }
            };

            WhereClause firstClone = new WhereClause()
            {
                Expression = new BooleanScalarExpression()
                {
                    ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
                }
            };

            WhereClause second = new WhereClause()
            {
                Expression = new BooleanScalarExpression()
                {
                    ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c2" } }
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
