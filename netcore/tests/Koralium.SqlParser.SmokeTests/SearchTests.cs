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
        public void TestSearchSingleColumn()
        {
            var actual = Parser.Parse("SELECT * FROM test WHERE CONTAINS(c1, 'test')").Statements;

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
                        Expression = new SearchExpression()
                        {
                            Columns = new List<ColumnReference>()
                            {
                                new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c1" }
                                }
                            },
                            Value = new StringLiteral()
                            {
                                Value = "test"
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestSearchTwoColumns()
        {
            var actual = Parser.Parse("SELECT * FROM test WHERE CONTAINS((c1, c2), 'test')").Statements;

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
                        Expression = new SearchExpression()
                        {
                            Columns = new List<ColumnReference>()
                            {
                                new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c1" }
                                },
                                new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c2" }
                                }
                            },
                            Value = new StringLiteral()
                            {
                                Value = "test"
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestSearchWildcard()
        {
            var actual = Parser.Parse("SELECT * FROM test WHERE CONTAINS(*, 'test')").Statements;

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
                        Expression = new SearchExpression()
                        {
                            AllColumns = true,
                            Value = new StringLiteral()
                            {
                                Value = "test"
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }
    }
}
