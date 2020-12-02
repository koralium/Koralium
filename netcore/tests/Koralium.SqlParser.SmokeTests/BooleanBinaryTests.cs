using FluentAssertions;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.Literals;
using Koralium.SqlParser.Statements;
using NUnit.Framework;
using System.Collections.Generic;

namespace Koralium.SqlParser.SmokeTests
{
    public partial class SmokeTestsBase
    {
        [Test]
        public void TestAnd()
        {
            var actual = Parser.Parse("SELECT * FROM test WHERE c1 = 'a' AND c2 = 'b'").Statements;

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
                        Expression = new BooleanBinaryExpression()
                        {
                            Type = BooleanBinaryType.AND,
                            Left = new BooleanComparisonExpression()
                                {
                                    Left = new ColumnReference()
                                    {
                                        Identifiers = new List<string>(){ "c1" }
                                    },
                                    Right = new StringLiteral()
                                    {
                                        Value = "a"
                                    },
                                    Type = BooleanComparisonType.Equals
                                },
                            Right = new BooleanComparisonExpression()
                                {
                                    Left = new ColumnReference()
                                    {
                                        Identifiers = new List<string>(){ "c2" }
                                    },
                                    Right = new StringLiteral()
                                    {
                                        Value = "b"
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
        public void TestOr()
        {
            var actual = Parser.Parse("SELECT * FROM test WHERE c1 = 'a' OR c2 = 'b'").Statements;

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
                        Expression = new BooleanBinaryExpression()
                        {
                            Type = BooleanBinaryType.OR,
                            Left = new BooleanComparisonExpression()
                                {
                                    Left = new ColumnReference()
                                    {
                                        Identifiers = new List<string>(){ "c1" }
                                    },
                                    Right = new StringLiteral()
                                    {
                                        Value = "a"
                                    },
                                    Type = BooleanComparisonType.Equals
                                },
                            Right = new BooleanComparisonExpression()
                                {
                                    Left = new ColumnReference()
                                    {
                                        Identifiers = new List<string>(){ "c2" }
                                    },
                                    Right = new StringLiteral()
                                    {
                                        Value = "b"
                                    },
                                    Type = BooleanComparisonType.Equals
                                }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }
    }
}
