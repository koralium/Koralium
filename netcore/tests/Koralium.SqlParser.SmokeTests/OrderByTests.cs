using FluentAssertions;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.OrderBy;
using Koralium.SqlParser.Statements;
using NUnit.Framework;
using System.Collections.Generic;

namespace Koralium.SqlParser.SmokeTests
{
    public partial class SmokeTestsBase
    {
        [Test]
        public void TestOrderBySingleColumnNoOrderSet()
        {
            var actual = Parser.Parse("SELECT * FROM test ORDER BY c1").Statements;

            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new FromTableReference()
                        {
                            TableName = "test"
                        }
                    },
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectStarExpression()
                    },
                    OrderByClause = new Clauses.OrderByClause()
                    {
                        OrderExpressions = new List<OrderElement>()
                        {
                            new OrderBy.OrderExpression()
                            {
                                Ascending = true,
                                Expression = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c1" }
                                }
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestOrderBySingleColumnAscending()
        {
            var actual = Parser.Parse("SELECT * FROM test ORDER BY c1 asc").Statements;

            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new FromTableReference()
                        {
                            TableName = "test"
                        }
                    },
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectStarExpression()
                    },
                    OrderByClause = new Clauses.OrderByClause()
                    {
                        OrderExpressions = new List<OrderElement>()
                        {
                            new OrderBy.OrderExpression()
                            {
                                Ascending = true,
                                Expression = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c1" }
                                }
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestOrderBySingleColumnDescending()
        {
            var actual = Parser.Parse("SELECT * FROM test ORDER BY c1 desc").Statements;

            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new FromTableReference()
                        {
                            TableName = "test"
                        }
                    },
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectStarExpression()
                    },
                    OrderByClause = new Clauses.OrderByClause()
                    {
                        OrderExpressions = new List<OrderElement>()
                        {
                            new OrderBy.OrderExpression()
                            {
                                Ascending = false,
                                Expression = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c1" }
                                }
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestOrderByTwoColumns()
        {
            var actual = Parser.Parse("SELECT * FROM test ORDER BY c1, c2").Statements;

            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new FromTableReference()
                        {
                            TableName = "test"
                        }
                    },
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectStarExpression()
                    },
                    OrderByClause = new Clauses.OrderByClause()
                    {
                        OrderExpressions = new List<OrderElement>()
                        {
                            new OrderBy.OrderExpression()
                            {
                                Ascending = true,
                                Expression = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c1" }
                                }
                            },
                            new OrderBy.OrderExpression()
                            {
                                Ascending = true,
                                Expression = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c2" }
                                }
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestOrderByTwoColumnsFirstAscendingLastDescending()
        {
            var actual = Parser.Parse("SELECT * FROM test ORDER BY c1 asc, c2 desc").Statements;

            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new FromTableReference()
                        {
                            TableName = "test"
                        }
                    },
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectStarExpression()
                    },
                    OrderByClause = new Clauses.OrderByClause()
                    {
                        OrderExpressions = new List<OrderElement>()
                        {
                            new OrderBy.OrderExpression()
                            {
                                Ascending = true,
                                Expression = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c1" }
                                }
                            },
                            new OrderBy.OrderExpression()
                            {
                                Ascending = false,
                                Expression = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c2" }
                                }
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestOrderByFunction()
        {
            var actual = Parser.Parse("SELECT * FROM test ORDER BY sum(c1)").Statements;

            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new FromTableReference()
                        {
                            TableName = "test"
                        }
                    },
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectStarExpression()
                    },
                    OrderByClause = new Clauses.OrderByClause()
                    {
                        OrderExpressions = new List<OrderElement>()
                        {
                            new OrderBy.OrderExpression()
                            {
                                Ascending = true,
                                Expression = new FunctionCall()
                                {
                                    FunctionName = "sum",
                                    Parameters = new List<ScalarExpression>()
                                    {
                                        new ColumnReference()
                                        {
                                            Identifiers = new List<string>(){ "c1" }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestOrderBySelectNull()
        {
            var actual = Parser.Parse("SELECT * FROM test ORDER BY (SELECT NULL)").Statements;

            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new FromTableReference()
                        {
                            TableName = "test"
                        }
                    },
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectStarExpression()
                    },
                    OrderByClause = new Clauses.OrderByClause()
                    {
                        OrderExpressions = new List<OrderElement>()
                        {
                            new OrderBySubquery()
                            {
                                SelectStatement = new SelectStatement()
                                {
                                    SelectElements = new List<SelectExpression>()
                                    {
                                        new SelectNullExpression()
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
