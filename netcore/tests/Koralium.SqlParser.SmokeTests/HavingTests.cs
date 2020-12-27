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
        public void TestHavingEquals()
        {
            var actual = Parser.Parse("SELECT c1 FROM test GROUP BY c1 HAVING c1 = 'testing'").Statements;

            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
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
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new FromTableReference()
                        {
                            TableName = "test"
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
                    },
                    HavingClause = new Clauses.HavingClause()
                    {
                        Expression = new BooleanComparisonExpression()
                        {
                            Left = new ColumnReference()
                            {
                                Identifiers = new List<string>(){ "c1" }
                            },
                            Right = new StringLiteral()
                            {
                                Value = "testing"
                            },
                            Type = BooleanComparisonType.Equals
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestHavingSumGreaterThan()
        {
            var actual = Parser.Parse("SELECT sum(c2) FROM test GROUP BY c1 HAVING sum(c2) > 1").Statements;

            var expected = new List<Statement>()
            {
                new SelectStatement()
                {
                    SelectElements = new List<SelectExpression>()
                    {
                        new SelectScalarExpression()
                        {
                            Expression = new FunctionCall()
                            {
                                FunctionName = "sum",
                                Parameters = new List<ScalarExpression>()
                                {
                                    new ColumnReference()
                                    {
                                        Identifiers = new List<string>(){ "c2" }
                                    }
                                }
                            }
                        }
                    },
                    FromClause = new Clauses.FromClause()
                    {
                        TableReference = new FromTableReference()
                        {
                            TableName = "test"
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
                    },
                    HavingClause = new Clauses.HavingClause()
                    {
                        Expression = new BooleanComparisonExpression()
                        {
                            Left = new FunctionCall()
                            {
                                FunctionName = "sum",
                                Parameters = new List<ScalarExpression>()
                                {
                                    new ColumnReference()
                                    {
                                        Identifiers = new List<string>(){ "c2" }
                                    }
                                }
                            },
                            Right = new IntegerLiteral()
                            {
                                Value = 1
                            },
                            Type = BooleanComparisonType.GreaterThan
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }
    }
}
