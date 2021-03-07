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
