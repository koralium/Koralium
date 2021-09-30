using FluentAssertions;
using Koralium.SqlParser.Expressions;
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
        public void TestExecuteStoredProcedureSingleParameter()
        {
            var actual = Parser.Parse("GetCustomer 1").Statements;
            var expected = new List<Statement>()
            {
                new StoredProcedure()
                {
                    ProcedureName = "GetCustomer",
                    Variables = new List<SetVariableStatement>()
                    {
                        new SetVariableStatement()
                        {
                            ScalarExpression = new IntegerLiteral()
                            {
                                Value = 1
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestExecuteStoredProcedureMultipleParameters()
        {
            var actual = Parser.Parse("GetCustomers 1, 2").Statements;
            var expected = new List<Statement>()
            {
                new StoredProcedure()
                {
                    ProcedureName = "GetCustomers",
                    Variables = new List<SetVariableStatement>()
                    {
                        new SetVariableStatement()
                        {
                            ScalarExpression = new IntegerLiteral()
                            {
                                Value = 1
                            }
                        },
                        new SetVariableStatement()
                        {
                            ScalarExpression = new IntegerLiteral()
                            {
                                Value = 2
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestExecuteStoredProcedureSingleParameterWithVariableName()
        {
            var actual = Parser.Parse("GetCustomer @id = 1").Statements;
            var expected = new List<Statement>()
            {
                new StoredProcedure()
                {
                    ProcedureName = "GetCustomer",
                    Variables = new List<SetVariableStatement>()
                    {
                        new SetVariableStatement()
                        {
                            ScalarExpression = new IntegerLiteral()
                            {
                                Value = 1
                            },
                            VariableReference = new VariableReference()
                            {
                                Name = "@id"
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestExecuteStoredProcedureMultiParameterWithVariableName()
        {
            var actual = Parser.Parse("GetCustomer @id1 = 1, @id2 = 2").Statements;
            var expected = new List<Statement>()
            {
                new StoredProcedure()
                {
                    ProcedureName = "GetCustomer",
                    Variables = new List<SetVariableStatement>()
                    {
                        new SetVariableStatement()
                        {
                            ScalarExpression = new IntegerLiteral()
                            {
                                Value = 1
                            },
                            VariableReference = new VariableReference()
                            {
                                Name = "@id1"
                            }
                        },
                        new SetVariableStatement()
                        {
                            ScalarExpression = new IntegerLiteral()
                            {
                                Value = 2
                            },
                            VariableReference = new VariableReference()
                            {
                                Name = "@id2"
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }
    }
}
