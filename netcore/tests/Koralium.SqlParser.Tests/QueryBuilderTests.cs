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
using System.Linq;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class QueryBuilderTests
    {
        [Test]
        public void TestBooleanComparisionEquals()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.String == "test");
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.Equals,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "String" },
                },
                Right = new StringLiteral() { Value = "test" }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestBooleanComparisionGreaterThan()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.Long > 3);
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.GreaterThan,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "Long" },
                },
                Right = new IntegerLiteral() { Value = 3 }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestBooleanComparisionGreaterThanOrEqualTo()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.Long >= 3);
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.GreaterThanOrEqualTo,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "Long" },
                },
                Right = new IntegerLiteral() { Value = 3 }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestBooleanComparisionLessThan()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.Long < 3);
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.LessThan,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "Long" },
                },
                Right = new IntegerLiteral() { Value = 3 }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }


        [Test]
        public void TestBooleanComparisionLessThanOrEqualTo()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.Long <= 3);
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.LessThanOrEqualTo,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "Long" },
                },
                Right = new IntegerLiteral() { Value = 3 }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestBooleanComparisionNotEqualTo()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.Long != 3);
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.NotEqualTo,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "Long" },
                },
                Right = new IntegerLiteral() { Value = 3 }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        

        [Test]
        public void TestBooleanComparisionEqualsString()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.String.CompareTo("test") == 0);
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.Equals,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "String" },
                },
                Right = new StringLiteral() { Value = "test" }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestBooleanComparisionNotEqualsString()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.String.CompareTo("test") != 0);
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.NotEqualTo,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "String" },
                },
                Right = new StringLiteral() { Value = "test" }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestBooleanComparisionGreaterThanString()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.String.CompareTo("test") > 0);
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.GreaterThan,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "String" },
                },
                Right = new StringLiteral() { Value = "test" }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestBooleanComparisionGreaterThanOrEqualsString()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.String.CompareTo("test") >= 0);
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.GreaterThanOrEqualTo,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "String" },
                },
                Right = new StringLiteral() { Value = "test" }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestBooleanComparisionLessThanString()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.String.CompareTo("test") < 0);
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.LessThan,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "String" },
                },
                Right = new StringLiteral() { Value = "test" }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestBooleanComparisionLessThanOrEqualToString()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.String.CompareTo("test") <= 0);
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.LessThanOrEqualTo,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "String" },
                },
                Right = new StringLiteral() { Value = "test" }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestBooleanBinaryAnd()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.Long == 0 && x.String == "test");
            var expected = new BooleanBinaryExpression()
            {
                Left = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.Equals,
                    Left = new ColumnReference()
                    {
                        Identifiers = new List<string>() { "Long" },
                    },
                    Right = new IntegerLiteral() { Value = 0 }
                },
                Right = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.Equals,
                    Left = new ColumnReference()
                    {
                        Identifiers = new List<string>() { "String" },
                    },
                    Right = new StringLiteral() { Value = "test" }
                },
                Type = BooleanBinaryType.AND
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestBooleanBinaryOr()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.Long == 0 || x.String == "test");
            var expected = new BooleanBinaryExpression()
            {
                Left = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.Equals,
                    Left = new ColumnReference()
                    {
                        Identifiers = new List<string>() { "Long" },
                    },
                    Right = new IntegerLiteral() { Value = 0 }
                },
                Right = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.Equals,
                    Left = new ColumnReference()
                    {
                        Identifiers = new List<string>() { "String" },
                    },
                    Right = new StringLiteral() { Value = "test" }
                },
                Type = BooleanBinaryType.OR
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestStringEqualsNull()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.String == null);
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.Equals,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "String" },
                },
                Right = new NullLiteral()
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestBinaryExpressionAdd()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => (x.Long + 1) == 0);
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.Equals,
                Left = new Expressions.BinaryExpression()
                {
                    Left = new ColumnReference()
                    {
                        Identifiers = new List<string>() { "Long" },
                    },
                    Right = new IntegerLiteral()
                    {
                        Value = 1
                    },
                    Type = BinaryType.Add
                },
                Right = new IntegerLiteral()
                {
                    Value = 0
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestBinaryExpressionSubtract()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => (x.Long - 1) == 0);
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.Equals,
                Left = new Expressions.BinaryExpression()
                {
                    Left = new ColumnReference()
                    {
                        Identifiers = new List<string>() { "Long" },
                    },
                    Right = new IntegerLiteral()
                    {
                        Value = 1
                    },
                    Type = BinaryType.Subtract
                },
                Right = new IntegerLiteral()
                {
                    Value = 0
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestBinaryExpressionMultiply()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => (x.Long * 1) == 0);
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.Equals,
                Left = new Expressions.BinaryExpression()
                {
                    Left = new ColumnReference()
                    {
                        Identifiers = new List<string>() { "Long" },
                    },
                    Right = new IntegerLiteral()
                    {
                        Value = 1
                    },
                    Type = BinaryType.Multiply
                },
                Right = new IntegerLiteral()
                {
                    Value = 0
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestBinaryExpressionDivide()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => (x.Long / 1) == 0);
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.Equals,
                Left = new Expressions.BinaryExpression()
                {
                    Left = new ColumnReference()
                    {
                        Identifiers = new List<string>() { "Long" },
                    },
                    Right = new IntegerLiteral()
                    {
                        Value = 1
                    },
                    Type = BinaryType.Divide
                },
                Right = new IntegerLiteral()
                {
                    Value = 0
                }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestStringContains()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.String.Contains("test"));
            var expected = new LikeExpression()
            {
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "String" }
                },
                Right = new StringLiteral() { Value = "%test%" }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestStringContainsConcat()
        {
            var testclass = new TestClass()
            {
                String = "test"
            };
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.String.Contains(testclass.String + "2"));
            var expected = new LikeExpression()
            {
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "String" }
                },
                Right = new StringLiteral() { Value = "%test2%" }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestStringStartsWith()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.String.StartsWith("test"));
            var expected = new LikeExpression()
            {
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "String" }
                },
                Right = new StringLiteral() { Value = "test%" }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestStringEndsWith()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => x.String.EndsWith("test"));
            var expected = new LikeExpression()
            {
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "String" }
                },
                Right = new StringLiteral() { Value = "%test" }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestListContainsString()
        {
            List<string> values = new List<string>()
            {
                "test1",
                "test2"
            };

            var actual = QueryBuilder.BooleanExpression<TestClass>(x => values.Contains(x.String));
            var expected = new InExpression()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "String" } },
                Values = values.Select(x => new StringLiteral() { Value = x } as ScalarExpression).ToList()
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestListContainsInteger()
        {
            List<int> values = new List<int>()
            {
                3,
                17
            };

            var actual = QueryBuilder.BooleanExpression<TestClass>(x => values.Contains((int)x.Long));
            var expected = new InExpression()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "Long" } },
                Values = values.Select(x => new IntegerLiteral() { Value = x } as ScalarExpression).ToList()
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestListNotContainsString()
        {
            List<string> values = new List<string>()
            {
                "test1",
                "test2"
            };

            var actual = QueryBuilder.BooleanExpression<TestClass>(x => !values.Contains(x.String));
            var expected = new InExpression()
            {
                Expression = new ColumnReference() { Identifiers = new List<string>() { "String" } },
                Values = values.Select(x => new StringLiteral() { Value = x } as ScalarExpression).ToList(),
                Not = true
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1940:Boolean checks should not be inverted", Justification = "Required for test case")]
        public void TestBooleanComparisionInvertedLessThanOrEqualTo()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => !(x.Long <= 3));
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.GreaterThan,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "Long" },
                },
                Right = new IntegerLiteral() { Value = 3 }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1940:Boolean checks should not be inverted", Justification = "Required for test case")]
        public void TestBooleanComparisionInvertedEquals()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => !(x.String == "test"));
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.NotEqualTo,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "String" },
                },
                Right = new StringLiteral() { Value = "test" }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1940:Boolean checks should not be inverted", Justification = "Required for test case")]
        public void TestBooleanComparisionInvertedNotEqualTo()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => !(x.Long != 3));
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.Equals,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "Long" },
                },
                Right = new IntegerLiteral() { Value = 3 }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1940:Boolean checks should not be inverted", Justification = "Required for test case")]
        public void TestBooleanComparisionInvertedGreaterThan()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => !(x.Long > 3));
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.LessThanOrEqualTo,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "Long" },
                },
                Right = new IntegerLiteral() { Value = 3 }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1940:Boolean checks should not be inverted", Justification = "Required for test case")]
        public void TestBooleanComparisionInvertedGreaterThanOrEqualTo()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => !(x.Long >= 3));
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.LessThan,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "Long" },
                },
                Right = new IntegerLiteral() { Value = 3 }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1940:Boolean checks should not be inverted", Justification = "Required for test case")]
        public void TestBooleanComparisionInvertedLessThan()
        {
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => !(x.Long < 3));
            var expected = new BooleanComparisonExpression()
            {
                Type = BooleanComparisonType.GreaterThanOrEqualTo,
                Left = new ColumnReference()
                {
                    Identifiers = new List<string>() { "Long" },
                },
                Right = new IntegerLiteral() { Value = 3 }
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestInvertedBooleanBinaryAnd()
        {
            //Test DeMorgan law for negation
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => !(x.Long == 0 && x.String == "test"));
            var expected = new BooleanBinaryExpression()
            {
                Left = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.NotEqualTo,
                    Left = new ColumnReference()
                    {
                        Identifiers = new List<string>() { "Long" },
                    },
                    Right = new IntegerLiteral() { Value = 0 }
                },
                Right = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.NotEqualTo,
                    Left = new ColumnReference()
                    {
                        Identifiers = new List<string>() { "String" },
                    },
                    Right = new StringLiteral() { Value = "test" }
                },
                Type = BooleanBinaryType.OR
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }

        [Test]
        public void TestInvertedBooleanBinaryOr()
        {
            //Test DeMorgan law for negation
            var actual = QueryBuilder.BooleanExpression<TestClass>(x => !(x.Long == 0 || x.String == "test"));
            var expected = new BooleanBinaryExpression()
            {
                Left = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.NotEqualTo,
                    Left = new ColumnReference()
                    {
                        Identifiers = new List<string>() { "Long" },
                    },
                    Right = new IntegerLiteral() { Value = 0 }
                },
                Right = new BooleanComparisonExpression()
                {
                    Type = BooleanComparisonType.NotEqualTo,
                    Left = new ColumnReference()
                    {
                        Identifiers = new List<string>() { "String" },
                    },
                    Right = new StringLiteral() { Value = "test" }
                },
                Type = BooleanBinaryType.AND
            };

            actual.Should().BeEquivalentTo(expected, x => x.RespectingRuntimeTypes());
        }
    }
}
