﻿using Koralium.SqlToExpression.Tests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Koralium.SqlToExpression.Tests
{
    public class GetSchemaTests : TpchTestsBase
    {
        [Test]
        public void TestGetSchema()
        {
            var expected = ImmutableList.Create(
                new ColumnMetadata("acctbal", typeof(double), null),
                new ColumnMetadata("address", typeof(string), null),
                new ColumnMetadata("comment", typeof(string), null),
                new ColumnMetadata("custkey", typeof(long), null),
                new ColumnMetadata("mktsegment", typeof(string), null),
                new ColumnMetadata("name", typeof(string), null),
                new ColumnMetadata("nationkey", typeof(long), null),
                new ColumnMetadata("phone", typeof(string), null)
                );

            var columns = SqlExecutor.GetSchema("select * from customer");

            GetColumnsComparer.Compare(expected, columns);
        }
    }
}