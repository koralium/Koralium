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
using Koralium.SqlParser.GroupBy;
using Koralium.SqlParser.Literals;
using Koralium.SqlParser.Statements;
using NUnit.Framework;
using System.Collections.Generic;

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
