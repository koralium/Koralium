using FluentAssertions;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.From;
using Koralium.SqlParser.Statements;
using NUnit.Framework;
using System.Collections.Generic;

namespace Koralium.SqlParser.SmokeTests
{
    public partial class SmokeTestsBase
    {
        [Test]
        public void TestSelectFromTableNameLowercase()
        {
            var statements = Parser.Parse("SELECT * FROM test").Statements;

            List<Statement> expected = new List<Statement>()
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
                    }
                }
            };

            statements.Should().BeEquivalentTo(expected,x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestSelectFromTableNameUppercase()
        {
            var statements = Parser.Parse("SELECT * FROM TEST").Statements;

            List<Statement> expected = new List<Statement>()
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
                            TableName = "TEST"
                        }
                    }
                }
            };

            statements.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestSelectFromTableNameAliasLowercase()
        {
            var statements = Parser.Parse("SELECT * FROM TEST t").Statements;

            List<Statement> expected = new List<Statement>()
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
                            TableName = "TEST",
                            Alias = "t"
                        }
                    }
                }
            };

            statements.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestSelectFromTableNameAliasUppercase()
        {
            var statements = Parser.Parse("SELECT * FROM TEST T").Statements;

            List<Statement> expected = new List<Statement>()
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
                            TableName = "TEST",
                            Alias = "T"
                        }
                    }
                }
            };

            statements.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestSelectFromTableNameWithQuotes()
        {
            var statements = Parser.Parse("SELECT * FROM \"test\"").Statements;

            List<Statement> expected = new List<Statement>()
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
                    }
                }
            };

            statements.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestSelectFromTableAliasWithQuotes()
        {
            var statements = Parser.Parse("SELECT * FROM test \"t\"").Statements;

            List<Statement> expected = new List<Statement>()
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
                            TableName = "test",
                            Alias = "t"
                        }
                    }
                }
            };

            statements.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }
    }
}
