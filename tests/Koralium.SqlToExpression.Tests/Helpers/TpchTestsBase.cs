using Koralium.SqlToExpression.Executors;
using Koralium.SqlToExpression.Executors.Offset;
using Koralium.SqlToExpression.Metadata;
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

        [SetUp]
        public void Setup()
        {
            tpchData = new TpchData();
            TablesMetadata tablesMetadata = new TablesMetadata();
            tablesMetadata.AddTable(new TableMetadata("customer", typeof(Customer)));
            tablesMetadata.AddTable(new TableMetadata("lineitem", typeof(LineItem)));
            tablesMetadata.AddTable(new TableMetadata("nation", typeof(Nation)));
            tablesMetadata.AddTable(new TableMetadata("order", typeof(Order)));
            tablesMetadata.AddTable(new TableMetadata("part", typeof(Part)));
            tablesMetadata.AddTable(new TableMetadata("partsupp", typeof(Partsupp)));
            tablesMetadata.AddTable(new TableMetadata("region", typeof(Region)));
            tablesMetadata.AddTable(new TableMetadata("supplier", typeof(Supplier)));

            var queryExecutor = new QueryExecutor(
                new TableResolver(tpchData),
                new DefaultFromTableExecutorFactory(),
                new DefaultWhereExecutorFactory(),
                new DefaultGroupByExecutorFactory(),
                new DefaultSelectExecutorFactory(),
                new DefaultOrderByExecutorFactory(),
                new DefaultOffsetExecutorFactory(),
                new DefaultDistinctExecutorFactory());

            sqlExecutor = new SqlExecutor(tablesMetadata, queryExecutor);
        }

        protected void AssertAreEqual(IQueryable expected, IQueryable actual)
        {
            Assert.That(actual, Is.EqualTo(expected).Using(new QueryComparer()));
        }
    }
}
