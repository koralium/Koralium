/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
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
                                    Parameters = new List<SqlExpression>()
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
