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
        public void TestInExpression()
        {
            var actual = Parser.Parse("SELECT * FROM test WHERE c1 IN (1, 2, 3)").Statements;

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
                        Expression = new InExpression()
                        {
                            Expression = new ColumnReference()
                            {
                                Identifiers = new List<string>(){ "c1" }
                            },
                            Values = new List<ScalarExpression>()
                            {
                                new IntegerLiteral()
                                {
                                    Value = 1
                                },
                                new IntegerLiteral()
                                {
                                    Value = 2
                                },
                                new IntegerLiteral()
                                {
                                    Value = 3
                                }
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestNotInExpression()
        {
            var actual = Parser.Parse("SELECT * FROM test WHERE c1 NOT IN (1, 2, 3)").Statements;

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
                        Expression = new InExpression()
                        {
                            Not = true,
                            Expression = new ColumnReference()
                            {
                                Identifiers = new List<string>(){ "c1" }
                            },
                            Values = new List<ScalarExpression>()
                            {
                                new IntegerLiteral()
                                {
                                    Value = 1
                                },
                                new IntegerLiteral()
                                {
                                    Value = 2
                                },
                                new IntegerLiteral()
                                {
                                    Value = 3
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
