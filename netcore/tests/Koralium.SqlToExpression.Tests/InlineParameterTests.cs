using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Tests
{
    public class InlineParameterTests : TpchTestsBase
    {
        [Test]
        public async Task TestInlineParametersString()
        {
            var actual = await SqlExecutor.Execute(@"
                SET @Parameter = '5-LOW';
                SELECT Orderkey, Orderpriority FROM ""order"" WHERE Orderpriority = @Parameter
            ");

            var expected = TpchData.Orders
                .Where(x => x.Orderpriority == "5-LOW")
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, actual.Result);
        }

        [Test]
        public async Task TestInlineParametersInt()
        {
            var actual = await SqlExecutor.Execute(@"
                SET @Parameter = 5;
                SELECT Orderkey, Orderpriority FROM ""order"" WHERE Orderkey = @Parameter
            ");

            var expected = TpchData.Orders
                .Where(x => x.Orderkey == 5)
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, actual.Result);
        }

        [Test]
        public async Task TestInlineParametersDouble()
        {
            var actual = await SqlExecutor.Execute(@"
                SET @Parameter = 5.0;
                SELECT Orderkey, Orderpriority FROM ""order"" WHERE Totalprice > @Parameter
            ");

            var expected = TpchData.Orders
                .Where(x => x.Totalprice > 5.0)
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, actual.Result);
        }

        [Test]
        public async Task TestInlineParametersDateTime()
        {
            var actual = await SqlExecutor.Execute(@"
                SET @Parameter = '1995-10-23';
                SELECT Orderkey, Orderdate FROM ""order"" WHERE Orderdate > @Parameter
            ");

            var expected = TpchData.Orders
                .Where(x => x.Orderdate > DateTime.Parse("1995-10-23"))
                .Select(x => new { x.Orderkey, x.Orderdate })
                .AsQueryable();

            AssertAreEqual(expected, actual.Result);
        }

        [Test]
        public async Task TestInlineParametersBase64()
        {
            var actual = await SqlExecutor.Execute(@"
                SET @Parameter = b64'MTk5NS0xMC0yMw==';
                SELECT Orderkey, Orderdate FROM ""order"" WHERE Orderdate > @Parameter
            ");

            var expected = TpchData.Orders
                .Where(x => x.Orderdate > DateTime.Parse("1995-10-23"))
                .Select(x => new { x.Orderkey, x.Orderdate })
                .AsQueryable();

            AssertAreEqual(expected, actual.Result);
        }
    }
}
