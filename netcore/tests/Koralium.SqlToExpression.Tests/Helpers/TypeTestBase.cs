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
using Koralium.SqlParser.ANTLR;
using Koralium.SqlToExpression.Executors;
using Koralium.SqlToExpression.Executors.AggregateFunction;
using Koralium.SqlToExpression.Executors.Offset;
using Koralium.SqlToExpression.Metadata;
using Koralium.SqlToExpression.Providers;
using Koralium.WebTests.Entities;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Tests.Helpers
{
    class TypeTestBase
    {
        private SqlExecutor sqlExecutor;
        private TpchData tpchData;

        protected SqlExecutor SqlExecutor => sqlExecutor;

        protected TpchData TpchData => tpchData;

        private class TypeTestTableResolver : ISqlTableResolver
        {
            public ValueTask<IQueryable> ResolveTableName(string name, object additionalData, IQueryOptions queryOptions)
            {
                return new ValueTask<IQueryable>(WebTests.TestData.GetTypeTests());
            }
        }

        [OneTimeSetUp]
        public void Setup()
        {
            tpchData = new TpchData();
            TablesMetadata tablesMetadata = new TablesMetadata();
            tablesMetadata.AddTable(new TableMetadata("typetest", typeof(TypeTest), new InMemoryOperationsProvider()));

            var queryExecutor = new QueryExecutor(
                new TypeTestTableResolver(),
                new DefaultFromTableExecutorFactory(),
                new DefaultWhereExecutorFactory(),
                new DefaultGroupByExecutorFactory(),
                new DefaultSelectExecutorFactory(),
                new DefaultOrderByExecutorFactory(),
                new DefaultOffsetExecutorFactory(),
                new DefaultDistinctExecutorFactory(),
                new DefaultAggregateFunctionFactory());

            sqlExecutor = new SqlExecutor(
                new AntlrSqlParser(),
                tablesMetadata,
                queryExecutor,
                new DefaultSearchExpressionProvider(),
                new DefaultOperationsProvider());
        }

        protected void AssertAreEqual(IQueryable expected, IQueryable actual)
        {
            Assert.That(actual, Is.EqualTo(expected).Using(new QueryComparer()));
        }
    }
}
