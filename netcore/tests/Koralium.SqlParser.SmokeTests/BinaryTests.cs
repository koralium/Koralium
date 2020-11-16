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
