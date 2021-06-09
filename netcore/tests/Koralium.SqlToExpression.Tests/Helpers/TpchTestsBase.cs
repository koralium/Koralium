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
using Koralium.SqlToExpression.Tests.Models;
using Koralium.SqlToExpression.Tests.tpch;
using NUnit.Framework;
using System.Linq;

namespace Koralium.SqlToExpression.Tests
{
    public class TpchTestsBase
    {
        private SqlExecutor sqlExecutor;
        private TpchData tpchData;

        protected SqlExecutor SqlExecutor => sqlExecutor;

        protected TpchData TpchData => tpchData;

        [OneTimeSetUp]
        public void Setup()
        {
            tpchData = new TpchData();
            TablesMetadata tablesMetadata = new TablesMetadata();
            tablesMetadata.AddTable(new TableMetadata("customer", typeof(Customer)));
            tablesMetadata.AddTable(new TableMetadata("lineitem", typeof(LineItem)));
            tablesMetadata.AddTable(new TableMetadata("nation", typeof(Nation)));
            tablesMetadata.AddTable(new TableMetadata("order", typeof(Order), new InMemoryOperationsProvider()));
            tablesMetadata.AddTable(new TableMetadata("part", typeof(Part)));
            tablesMetadata.AddTable(new TableMetadata("partsupp", typeof(Partsupp)));
            tablesMetadata.AddTable(new TableMetadata("region", typeof(Region)));
            tablesMetadata.AddTable(new TableMetadata("supplier", typeof(Supplier)));
            tablesMetadata.AddTable(new TableMetadata("columntest", typeof(ColumnTest)));
            tablesMetadata.AddTable(new TableMetadata("nulltest", typeof(NullTest), new InMemoryOperationsProvider()));
            tablesMetadata.AddTable(new TableMetadata("enumtable", typeof(EnumTest)));
            tablesMetadata.AddTable(new TableMetadata("objecttable", typeof(ObjectTest)));

            var queryExecutor = new QueryExecutor(
                new TableResolver(tpchData),
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
