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
using Koralium.SqlParser.Literals;
using Koralium.SqlParser.Statements;
using NUnit.Framework;
using System.Collections.Generic;

namespace Koralium.SqlParser.SmokeTests
{
    public partial class SmokeTestsBase
    {
        [Test]
        public virtual void TestAddition()
        {
            var actual = Parser.Parse("SELECT c1 + 1 FROM test").Statements;

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
                            Expression = new BinaryExpression()
                            {
                                Left = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c1" }
                                },
                                Right = new IntegerLiteral()
                                {
                                    Value = 1
                                },
                                Type = BinaryType.Add
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public virtual void TestSubtraction()
        {
            var actual = Parser.Parse("SELECT c1 - 1 FROM test").Statements;

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
                            Expression = new BinaryExpression()
                            {
                                Left = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){"c1" }
                                },
                                Right = new IntegerLiteral()
                                {
                                    Value = 1
                                },
                                Type = BinaryType.Subtract
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public virtual void TestMultiply()
        {
            var actual = Parser.Parse("SELECT c1 * 1 FROM test").Statements;

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
                            Expression = new BinaryExpression()
                            {
                                Left = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c1" }
                                },
                                Right = new IntegerLiteral()
                                {
                                    Value = 1
                                },
                                Type = BinaryType.Multiply
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public virtual void TestDivision()
        {
            var actual = Parser.Parse("SELECT c1 / 1 FROM test").Statements;

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
                            Expression = new BinaryExpression()
                            {
                                Left = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c1" }
                                },
                                Right = new IntegerLiteral()
                                {
                                    Value = 1
                                },
                                Type = BinaryType.Divide
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public virtual void TestModulo()
        {
            var actual = Parser.Parse("SELECT c1 % 1 FROM test").Statements;

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
                            Expression = new BinaryExpression()
                            {
                                Left = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c1" }
                                },
                                Right = new IntegerLiteral()
                                {
                                    Value = 1
                                },
                                Type = BinaryType.Modulo
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public virtual void TestBitwiseAnd()
        {
            var actual = Parser.Parse("SELECT c1 & 1 FROM test").Statements;

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
                            Expression = new BinaryExpression()
                            {
                                Left = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c1" }
                                },
                                Right = new IntegerLiteral()
                                {
                                    Value = 1
                                },
                                Type = BinaryType.BitwiseAnd
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public virtual void TestBitwiseOr()
        {
            var actual = Parser.Parse("SELECT c1 | 1 FROM test").Statements;

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
                            Expression = new BinaryExpression()
                            {
                                Left = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c1" }
                                },
                                Right = new IntegerLiteral()
                                {
                                    Value = 1
                                },
                                Type = BinaryType.BitwiseOr
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public virtual void TestBitwiseXor()
        {
            var actual = Parser.Parse("SELECT c1 ^ 1 FROM test").Statements;

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
                            Expression = new BinaryExpression()
                            {
                                Left = new ColumnReference()
                                {
                                    Identifiers = new List<string>(){ "c1" }
                                },
                                Right = new IntegerLiteral()
                                {
                                    Value = 1
                                },
                                Type = BinaryType.BitwiseXor
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }
    }
}
