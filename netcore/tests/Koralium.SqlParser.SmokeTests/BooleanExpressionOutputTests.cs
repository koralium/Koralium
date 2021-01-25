using FluentAssertions;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Literals;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.SmokeTests
{
    public partial class SmokeTestsBase
    {
        [Test]
        public void TestParseBooleanExpression()
        {
            var actual = Parser.ParseFilter("c1 = 'test' AND c2 > 10", out var errors);
            var expected = new BooleanBinaryExpression()
            {
                Left = new BooleanComparisonExpression()
                {
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c1" } },
                    Right = new StringLiteral() { Value = "test" },
                    Type = BooleanComparisonType.Equals
                },
                Right = new BooleanComparisonExpression()
                {
                    Left = new ColumnReference() { Identifiers = new List<string>() { "c2" } },
                    Right = new IntegerLiteral() { Value = 10 },
                    Type = BooleanComparisonType.GreaterThan
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }
    }
}
