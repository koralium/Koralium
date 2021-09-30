using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Tests
{
    class StoredProcedureTests : TpchTestsBase
    {
        [Test]
        public async Task TestExecuteStoredProcedure()
        {
            var result = await SqlExecutor.Execute("GetCustomer 1");
            var expected = TpchData.Customers
                .Select(x =>
                    new { x.Custkey, x.Name, x.Address, x.Nationkey, x.Phone, x.Acctbal, x.Mktsegment, x.Comment }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestExecuteStoredProcedureWithVariableName()
        {
            var result = await SqlExecutor.Execute("GetCustomer @id = 1");
            var expected = TpchData.Customers
                .Select(x =>
                    new { x.Custkey, x.Name, x.Address, x.Nationkey, x.Phone, x.Acctbal, x.Mktsegment, x.Comment }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }
    }
}
