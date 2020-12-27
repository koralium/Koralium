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
using Koralium.SqlToExpression.Tests.Helpers;
using NUnit.Framework;
using System.Collections.Immutable;

namespace Koralium.SqlToExpression.Tests
{
    public class GetSchemaTests : TpchTestsBase
    {
        [Test]
        public void TestGetSchema()
        {
            var expected = ImmutableList.Create(
                new ColumnMetadata("custkey", typeof(long), null),
                new ColumnMetadata("name", typeof(string), null),
                new ColumnMetadata("address", typeof(string), null),
                new ColumnMetadata("nationkey", typeof(long), null),
                new ColumnMetadata("phone", typeof(string), null),
                new ColumnMetadata("acctbal", typeof(double), null),
                new ColumnMetadata("mktsegment", typeof(string), null),
                new ColumnMetadata("comment", typeof(string), null)
                );

            var schema = SqlExecutor.GetSchema("select * from customer");

            GetColumnsComparer.Compare(expected, schema.Columns);
        }
    }
}
