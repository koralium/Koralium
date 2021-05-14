﻿using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Literals;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Tests
{
    public class CloneTests
    {
        [Test]
        public void TestCloneBooleanScalarExpression()
        {
            BooleanScalarExpression booleanScalarExpression = new BooleanScalarExpression()
            {
                ScalarExpression = new ColumnReference() { Identifiers = new List<string>() { "test" } }
            };

            var clone = booleanScalarExpression.Clone() as BooleanScalarExpression;

            Assert.IsFalse(ReferenceEquals(booleanScalarExpression, clone));
            Assert.IsFalse(ReferenceEquals(booleanScalarExpression.ScalarExpression, clone.ScalarExpression));
            Assert.AreEqual(booleanScalarExpression, clone);
        }

        [Test]
        public void TestCloneLambdaExpression()
        {
            LambdaExpression lambdaExpression = new LambdaExpression()
            {
                Expression = new BooleanLiteral() { Value = true },
                Parameters = new List<string>() { "p1" }
            };

            var clone = lambdaExpression.Clone() as LambdaExpression;

            Assert.IsFalse(ReferenceEquals(lambdaExpression, clone));
            Assert.IsFalse(ReferenceEquals(lambdaExpression.Expression, clone.Expression));
            Assert.IsFalse(ReferenceEquals(lambdaExpression.Parameters, clone.Parameters));
            Assert.AreEqual(lambdaExpression, clone);
        }

        [Test]
        public void TestCloneFunctionCall()
        {
            FunctionCall functionCall = new FunctionCall()
            {
                FunctionName = "test",
                Parameters = new List<SqlExpression>()
                {
                    new ColumnReference(){ Identifiers = new List<string>() {"c1" }}
                },
                Wildcard = false
            };

            var clone = functionCall.Clone() as FunctionCall;

            Assert.AreEqual(functionCall, clone);
            Assert.IsFalse(ReferenceEquals(functionCall, clone));
            Assert.IsFalse(ReferenceEquals(functionCall.Parameters, clone.Parameters));
            for(int i = 0; i < functionCall.Parameters.Count; i++)
            {
                Assert.IsFalse(ReferenceEquals(functionCall.Parameters[i], clone.Parameters[i]));
            }
        }
    }
}