using FluentAssertions;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.Literals;
using Koralium.SqlParser.Statements;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.SmokeTests
{
    public partial class SmokeTestsBase
    {
        [Test]
        public void TestNotComparison()
        {
            var actual = Parser.Parse("SELECT * FROM test WHERE NOT c1 = true").Statements;

            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectStarExpression()
                    },
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new FromTableReference()
                        {
                            TableName = "test"
                        }
                    },
                    WhereClause = new Clauses.WhereClause()
                    {
                        Expression = new NotExpression()
                        {
                            BooleanExpression = new BooleanComparisonExpression()
                            {
                                Left = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c1" }
                                },
                                Right = new BooleanLiteral()
                                {
                                    Value = true
                                },
                                Type = BooleanComparisonType.Equals
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestNotComparisonWithParenthises()
        {
            var actual = Parser.Parse("SELECT * FROM test WHERE NOT (c1 = true)").Statements;

            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectStarExpression()
                    },
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new FromTableReference()
                        {
                            TableName = "test"
                        }
                    },
                    WhereClause = new Clauses.WhereClause()
                    {
                        Expression = new NotExpression()
                        {
                            BooleanExpression = new BooleanComparisonExpression()
                            {
                                Left = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c1" }
                                },
                                Right = new BooleanLiteral()
                                {
                                    Value = true
                                },
                                Type = BooleanComparisonType.Equals
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestNotBooleanBinary()
        {
            var actual = Parser.Parse("SELECT * FROM test WHERE NOT (c1 = true AND NOT c2 = 'test')").Statements;

            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectStarExpression()
                    },
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new FromTableReference()
                        {
                            TableName = "test"
                        }
                    },
                    WhereClause = new Clauses.WhereClause()
                    {
                        Expression = new NotExpression()
                        {
                            BooleanExpression = new BooleanBinaryExpression()
                            {
                                Type = BooleanBinaryType.AND,
                                Left = new BooleanComparisonExpression()
                                    {
                                        Left = new ColumnReference()
                                        {
                                            Identifiers = new List<string>(){ "c1" }
                                        },
                                        Right = new BooleanLiteral()
                                        {
                                            Value = true
                                        },
                                        Type = BooleanComparisonType.Equals
                                    },
                                Right = new NotExpression()
                                {
                                    BooleanExpression = new BooleanComparisonExpression()
                                    {
                                        Left = new ColumnReference()
                                        {
                                            Identifiers = new List<string>(){ "c2" }
                                        },
                                        Right = new StringLiteral()
                                        {
                                            Value = "test"
                                        },
                                        Type = BooleanComparisonType.Equals
                                    }
                                }
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }
    }
}
