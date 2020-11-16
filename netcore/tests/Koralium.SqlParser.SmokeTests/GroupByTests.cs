using FluentAssertions;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.GroupBy;
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
        public void TestGroupBySingleColumn()
        {
            var actual = Parser.Parse("SELECT c1 FROM test GROUP BY c1").Statements;
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
                        new SelectScalarExpression()
                        {
                            Expression = new ColumnReference()
                            {
                                Identifiers = new List<string>(){ "c1" }
                            }
                        }
                    },
                    GroupByClause = new Clauses.GroupByClause()
                    {
                        Groups = new List<GroupBy.Group>()
                        {
                            new ExpressionGroup()
                            {
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
        public void TestGroupBySelectNull()
        {
            var actual = Parser.Parse("SELECT c1 FROM test GROUP BY (SELECT NULL)").Statements;
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
                        new SelectScalarExpression()
                        {
                            Expression = new ColumnReference()
                            {
                                Identifiers = new List<string>(){ "c1" }
                            }
                        }
                    },
                    GroupByClause = new Clauses.GroupByClause()
                    {
                        Groups = new List<GroupBy.Group>()
                        {
                            new SelectStatementGroup()
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

        [Test]
        public void TestGroupBySingleColumnWithWhere()
        {
            var actual = Parser.Parse("SELECT c1 FROM test WHERE c1 = 'a' GROUP BY c1").Statements;

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
                        new SelectScalarExpression()
                        {
                            Expression = new ColumnReference()
                            {
                                Identifiers = new List<string>(){ "c1" }
                            }
                        }
                    },
                    WhereClause = new Clauses.WhereClause()
                    {
                        Expression = new BooleanComparisonExpression()
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
                        }
                    },
                    GroupByClause = new Clauses.GroupByClause()
                    {
                        Groups = new List<GroupBy.Group>()
                        {
                            new ExpressionGroup()
                            {
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
        public void TestGroupByTwoColumnsWithWhere()
        {
            var actual = Parser.Parse("SELECT c1, c2 FROM test WHERE c1 = 'a' GROUP BY c1, c2").Statements;

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
                        new SelectScalarExpression()
                        {
                            Expression = new ColumnReference()
                            {
                                Identifiers = new List<string>(){ "c1" }
                            }
                        },
                        new SelectScalarExpression()
                        {
                            Expression = new ColumnReference()
                            {
                                Identifiers = new List<string>(){ "c2" }
                            }
                        }
                    },
                    WhereClause = new Clauses.WhereClause()
                    {
                        Expression = new BooleanComparisonExpression()
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
                        }
                    },
                    GroupByClause = new Clauses.GroupByClause()
                    {
                        Groups = new List<GroupBy.Group>()
                        {
                            new ExpressionGroup()
                            {
                                Expression = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c1" }
                                }
                            },
                            new ExpressionGroup()
                            {
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
    }
}
