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
        public virtual void TestLike()
        {
            var actual = Parser.Parse("SELECT * FROM test WHERE c1 LIKE 'test'").Statements;

            var expected = new List<Statement>()
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
                    },
                    WhereClause = new Clauses.WhereClause()
                    {
                        Expression = new LikeExpression()
                        {
                            Left = new ColumnReference()
                            {
                                Identifiers = new List<string>(){ "c1" }
                            },
                            Right = new StringLiteral()
                            {
                                Value = "test"
                            }
                        }
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }
    }
}
