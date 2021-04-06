using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Literals;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class ExpressionEqualsTests
    {
        [Test]
        public void TestCaseExpressionEquals()
        {
            CaseExpression left = new CaseExpression()
            {
                ElseExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                WhenExpressions = new List<WhenExpression>()
                {
                    new WhenExpression()
                    {
                        BooleanExpression = new BooleanComparisonExpression()
                        {
                            Left = new ColumnReference(){ Identifiers = new List<string>(){"c1"}},
                            Right = new StringLiteral(){Value = "v"},
                            Type = BooleanComparisonType.Equals
                        },
                        ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
                    }
                }
            };

            CaseExpression leftClone = new CaseExpression()
            {
                ElseExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                WhenExpressions = new List<WhenExpression>()
                {
                    new WhenExpression()
                    {
                        BooleanExpression = new BooleanComparisonExpression()
                        {
                            Left = new ColumnReference(){ Identifiers = new List<string>(){"c1"}},
                            Right = new StringLiteral(){Value = "v"},
                            Type = BooleanComparisonType.Equals
                        },
                        ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
                    }
                }
            };

            CaseExpression right = new CaseExpression()
            {
                ElseExpression = null,
                WhenExpressions = new List<WhenExpression>()
                {
                    new WhenExpression()
                    {
                        BooleanExpression = new BooleanComparisonExpression()
                        {
                            Left = new ColumnReference(){ Identifiers = new List<string>(){"c1"}},
                            Right = new StringLiteral(){Value = "v"},
                            Type = BooleanComparisonType.Equals
                        },
                        ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
                    }
                }
            };

            Assert.IsTrue(Equals(left, leftClone));
            Assert.IsFalse(Equals(left, null));
            Assert.IsFalse(Equals(left, right));
            Assert.IsFalse(Equals(left, "other type"));
        }

        [Test]
        public void TestCaseExpressionGetHashCode()
        {
            CaseExpression left = new CaseExpression()
            {
                ElseExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                WhenExpressions = new List<WhenExpression>()
                {
                    new WhenExpression()
                    {
                        BooleanExpression = new BooleanComparisonExpression()
                        {
                            Left = new ColumnReference(){ Identifiers = new List<string>(){"c1"}},
                            Right = new StringLiteral(){Value = "v"},
                            Type = BooleanComparisonType.Equals
                        },
                        ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
                    }
                }
            };

            CaseExpression leftClone = new CaseExpression()
            {
                ElseExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                WhenExpressions = new List<WhenExpression>()
                {
                    new WhenExpression()
                    {
                        BooleanExpression = new BooleanComparisonExpression()
                        {
                            Left = new ColumnReference(){ Identifiers = new List<string>(){"c1"}},
                            Right = new StringLiteral(){Value = "v"},
                            Type = BooleanComparisonType.Equals
                        },
                        ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
                    }
                }
            };

            CaseExpression right = new CaseExpression()
            {
                ElseExpression = null,
                WhenExpressions = new List<WhenExpression>()
                {
                    new WhenExpression()
                    {
                        BooleanExpression = new BooleanComparisonExpression()
                        {
                            Left = new ColumnReference(){ Identifiers = new List<string>(){"c1"}},
                            Right = new StringLiteral(){Value = "v"},
                            Type = BooleanComparisonType.Equals
                        },
                        ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "c1" } }
                    }
                }
            };

            Assert.AreEqual(left.GetHashCode(), leftClone.GetHashCode());
            Assert.AreNotEqual(left.GetHashCode(), right.GetHashCode());
        }

        [Test]
        public void TestWhenExpressionEquals()
        {
            WhenExpression left = new WhenExpression()
            {
                BooleanExpression = new BooleanComparisonExpression()
                {
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                    Right = new StringLiteral() { Value = "test" },
                    Type = BooleanComparisonType.Equals
                },
                ScalarExpression = new StringLiteral() { Value = "test" }
            };

            WhenExpression leftClone = new WhenExpression()
            {
                BooleanExpression = new BooleanComparisonExpression()
                {
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                    Right = new StringLiteral() { Value = "test" },
                    Type = BooleanComparisonType.Equals
                },
                ScalarExpression = new StringLiteral() { Value = "test" }
            };

            WhenExpression right = new WhenExpression()
            {
                BooleanExpression = new BooleanComparisonExpression()
                {
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                    Right = new StringLiteral() { Value = "test" },
                    Type = BooleanComparisonType.Equals
                },
                ScalarExpression = null
            };

            Assert.IsTrue(Equals(left, leftClone));
            Assert.IsFalse(Equals(left, null));
            Assert.IsFalse(Equals(left, right));
            Assert.IsFalse(Equals(left, "other type"));
        }

        [Test]
        public void TestWhenExpressionGetHashCode()
        {
            WhenExpression left = new WhenExpression()
            {
                BooleanExpression = new BooleanComparisonExpression()
                {
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                    Right = new StringLiteral() { Value = "test" },
                    Type = BooleanComparisonType.Equals
                },
                ScalarExpression = new StringLiteral() { Value = "test" }
            };

            WhenExpression leftClone = new WhenExpression()
            {
                BooleanExpression = new BooleanComparisonExpression()
                {
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                    Right = new StringLiteral() { Value = "test" },
                    Type = BooleanComparisonType.Equals
                },
                ScalarExpression = new StringLiteral() { Value = "test" }
            };

            WhenExpression right = new WhenExpression()
            {
                BooleanExpression = new BooleanComparisonExpression()
                {
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                    Right = new StringLiteral() { Value = "test" },
                    Type = BooleanComparisonType.Equals
                },
                ScalarExpression = null
            };

            Assert.AreEqual(left.GetHashCode(), leftClone.GetHashCode());
            Assert.AreNotEqual(left.GetHashCode(), right.GetHashCode());
        }
    }
}
