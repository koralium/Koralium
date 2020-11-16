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
        public void TestOffsetOnly()
        {
            var actual = Parser.Parse("SELECT * FROM test OFFSET 10").Statements;

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
                    OffsetLimitClause = new Clauses.OffsetLimitClause()
                    {
                        Offset = new IntegerLiteral()
                        {
                            Value = 10
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestLimitOnly()
        {
            var actual = Parser.Parse("SELECT * FROM test LIMIT 10").Statements;

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
                    OffsetLimitClause = new Clauses.OffsetLimitClause()
                    {
                        Limit = new IntegerLiteral()
                        {
                            Value = 10
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }
    }
}
