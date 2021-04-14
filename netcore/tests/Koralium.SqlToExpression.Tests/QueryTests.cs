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
using Koralium.Shared;
using Koralium.SqlToExpression.Tests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Tests
{
    public class QueryTests : TpchTestsBase
    {
        [Test]
        public async Task TestSelectCustomerName()
        {
            var result = await SqlExecutor.Execute("select name from customer");
            var expected = TpchData.Customers.Select(x => new { x.Name }).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestSelectStarFromCustomer()
        {
            var result = await SqlExecutor.Execute("select * from customer");
            var expected = TpchData.Customers
                .Select(x =>
                    new { x.Custkey, x.Name, x.Address, x.Nationkey, x.Phone, x.Acctbal, x.Mktsegment, x.Comment }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestSumGroupBySingle()
        {
            var result = await SqlExecutor.Execute("select sum(Acctbal) from customer group by name");
            var expected = TpchData.Customers.GroupBy(x => x.Name).Select(x => new { sum = x.Sum(y => y.Acctbal) }).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestSumNoGroupBy()
        {
            var result = await SqlExecutor.Execute("select sum(Acctbal) from customer");
            var expected = TpchData.Customers.GroupBy(x => 1).Select(x => new { sum = x.Sum(y => y.Acctbal) }).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestSumNoGroupByWithOuterAddition()
        {
            var result = await SqlExecutor.Execute("select sum(Acctbal) + 1 from customer");
            var expected = TpchData.Customers.GroupBy(x => 1).Select(x => new { sum = x.Sum(y => y.Acctbal) + 1 }).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestSumGroupBySingleTableAlias()
        {
            var result = await SqlExecutor.Execute("select sum(c.Acctbal) from customer c group by c.name");
            var expected = TpchData.Customers.GroupBy(x => x.Name).Select(x => new { sum = x.Sum(y => y.Acctbal) }).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestSumWithOuterAddition()
        {
            var result = await SqlExecutor.Execute("select sum(c.Acctbal) + 1 from customer c group by c.name");
            var expected = TpchData.Customers.GroupBy(x => x.Name).Select(x => new { sum = x.Sum(y => y.Acctbal) + 1 }).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestSumDividedBySum()
        {
            var result = await SqlExecutor.Execute("select sum(c.Acctbal) / sum(c.Custkey) from customer c");
            var expected = TpchData.Customers.GroupBy(x => 1).Select(x => new { sum = x.Sum(y => y.Acctbal) / x.Sum(y => y.Custkey) }).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestSumWitInnerAddition()
        {
            var result = await SqlExecutor.Execute("select sum(c.Acctbal + 1) from customer c");
            var expected = TpchData.Customers.GroupBy(x => 1).Select(x => new { sum = x.Sum(y => y.Acctbal + 1) }).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestSumGroupBySingleTableAliasWithColumnAlias()
        {
            var result = await SqlExecutor.Execute("select sum(c.Acctbal) AS Sum from customer c group by c.name");
            var expected = TpchData.Customers.GroupBy(x => x.Name).Select(x => new { sum = x.Sum(y => y.Acctbal) }).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestWhereFilterEqual()
        {
            var firstName = TpchData.Customers.FirstOrDefault().Name;
            var result = await SqlExecutor.Execute($"select * from customer where name = '{firstName}'");
            var expected = TpchData.Customers
                .Where(x => x.Name == firstName)
                .Select(x =>
                    new { x.Custkey, x.Name, x.Address, x.Nationkey, x.Phone, x.Acctbal, x.Mktsegment, x.Comment }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestWhereFilterEqualAnd()
        {
            var firstName = TpchData.Customers.FirstOrDefault().Name;
            var result = await SqlExecutor.Execute($"select * from customer where name = '{firstName}' AND custkey > 10");
            var expected = TpchData.Customers
                .Where(x => x.Name == firstName && x.Custkey > 10)
                .Select(x =>
                    new { x.Custkey, x.Name, x.Address, x.Nationkey, x.Phone, x.Acctbal, x.Mktsegment, x.Comment }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestWhereFilterEqualTableAlias()
        {
            var firstName = TpchData.Customers.FirstOrDefault().Name;
            var result = await SqlExecutor.Execute($"select * from customer c where c.name = '{firstName}'");
            var expected = TpchData.Customers
                .Where(x => x.Name == firstName)
                .Select(x =>
                    new { x.Custkey, x.Name, x.Address, x.Nationkey, x.Phone, x.Acctbal, x.Mktsegment, x.Comment }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestWhereFilterGreaterThan()
        {
            var result = await SqlExecutor.Execute($"select * from customer where custkey > 10");
            var expected = TpchData.Customers
                .Where(x => x.Custkey > 10)
                .Select(x =>
                    new { x.Custkey, x.Name, x.Address, x.Nationkey, x.Phone, x.Acctbal, x.Mktsegment, x.Comment }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestSimpleSubQuery()
        {
            var result = await SqlExecutor.Execute($"select * from (select * from customer) c");
            var expected = TpchData.Customers
                .Select(x =>
                    new { x.Custkey, x.Name, x.Address, x.Nationkey, x.Phone, x.Acctbal, x.Mktsegment, x.Comment }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestSubQueryAdditionInOuter()
        {
            var result = await SqlExecutor.Execute($"select c.sum + 1 from (select sum(Acctbal) AS sum from customer) c");
            var expected = TpchData.Customers
                .GroupBy(x => 1).Select(x => new { sum = x.Sum(y => y.Acctbal) + 1 }).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestSubQueryColumnAlias()
        {
            var result = await SqlExecutor.Execute($"select c.TEST from (select name AS TEST from customer) c");
            var expected = TpchData.Customers
                .Select(x =>
                    new { x.Name }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestSubQueryWithWhere()
        {
            var result = await SqlExecutor.Execute($"select c.name from (select name from customer where custkey > 10) c");
            var expected = TpchData.Customers
                .Where(x => x.Custkey > 10)
                .Select(x =>
                    new { x.Name }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestSubQueryInnerTableAlias()
        {
            var result = await SqlExecutor.Execute($"select sub.name from (select c.name from customer c where c.custkey > 10) sub");
            var expected = TpchData.Customers
                .Where(x => x.Custkey > 10)
                .Select(x =>
                    new { x.Name }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestOrderBySum()
        {
            var result = await SqlExecutor.Execute($"select sum(Acctbal), name from customer group by name order by sum(Acctbal) desc");
            var expected = TpchData.Customers
                .GroupBy(x => x.Name)
                .OrderByDescending(x => x.Sum(y => y.Acctbal))
                .Select(x =>
                    new { sum = x.Sum(y => y.Acctbal), name = x.Key }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestOrderByNameInAggregate()
        {
            var result = await SqlExecutor.Execute($"select sum(Acctbal), name from customer group by name order by name desc");
            var expected = TpchData.Customers
                .GroupBy(x => x.Name)
                .OrderByDescending(x => x.Key)
                .Select(x =>
                    new { sum = x.Sum(y => y.Acctbal), name = x.Key }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestOrderBySingle()
        {
            var result = await SqlExecutor.Execute($"select name from customer order by name desc");
            var expected = TpchData.Customers
                .OrderByDescending(x => x.Name)
                .Select(x =>
                    new { x.Name }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestOrderByAscending()
        {
            var result = await SqlExecutor.Execute($"select name from customer order by Comment");
            var expected = TpchData.Customers
                .OrderBy(x => x.Comment)
                .Select(x =>
                    new { x.Name }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestOrderByMultipleAscending()
        {
            var result = await SqlExecutor.Execute($"select name from customer order by Nationkey, Comment");
            var expected = TpchData.Customers
                .OrderBy(x => x.Nationkey)
                .ThenBy(x => x.Comment)
                .Select(x =>
                    new { x.Name }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestOrderByMultipleAscendingDescending()
        {
            var result = await SqlExecutor.Execute($"select name from customer order by Nationkey ASC, Comment DESC");
            var expected = TpchData.Customers
                .OrderBy(x => x.Nationkey)
                .ThenByDescending(x => x.Comment)
                .Select(x =>
                    new { x.Name }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task SelectConstant()
        {
            var result = await SqlExecutor.Execute($"select 1 as Constant from customer");

            var expected = TpchData.Customers
                .Select(x =>
                    new { Constant = 1L }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task SelectIntWithAddition()
        {
            var result = await SqlExecutor.Execute($"select Acctbal + 1 as Acct from customer");

            var expected = TpchData.Customers
                .Select(x =>
                    new { Acct = x.Acctbal + 1 }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }
        
        [Test]
        public async Task TestFilterOnDate()
        {
            var result = await SqlExecutor.Execute($"select Orderdate as Acct from \"order\" where Orderdate >= '1990-01-01'");

            var expected = TpchData.Orders
                .Where(x => x.Orderdate >= DateTime.Parse("1990-01-01"))
                .Select(x =>
                    new { Acct = x.Orderdate }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestHavingSumGreaterThanNoGroupBy()
        {
            var result = await SqlExecutor.Execute($"SELECT sum(Acctbal) FROM customer HAVING sum(Acctbal) > 10");
            var expected = TpchData.Customers
                .GroupBy(x => 1)
                .Select(x =>
                    new { sum = x.Sum(y => y.Acctbal) }
                )
                .Where(x => x.sum > 10)
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        /// <summary>
        /// This test checks how a query would look like from TypeORM when no order by is used.
        /// </summary>
        [Test]
        public async Task OrderBySelectNull()
        {
            var result = await SqlExecutor.Execute($"SELECT name FROM customer ORDER BY (select NULL)");
            var expected = TpchData.Customers
                .Select(x =>
                    new { x.Name }
                )
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestOffsetOnly()
        {
            var result = await SqlExecutor.Execute($"SELECT name FROM customer ORDER BY (SELECT NULL) OFFSET 100 ROWS");
            var expected = TpchData.Customers
                .Select(x =>
                    new { x.Name }
                )
                .Skip(100)
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestOffsetAndFetch()
        {
            var result = await SqlExecutor.Execute($"SELECT name FROM customer ORDER BY (SELECT NULL) LIMIT 100 OFFSET 100");
            var expected = TpchData.Customers
                .Select(x =>
                    new { x.Name }
                )
                .Skip(100)
                .Take(100)
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestDistinct()
        {
            var result = await SqlExecutor.Execute($"SELECT DISTINCT orderpriority FROM \"order\"");
            var expected = TpchData.Orders
                .Select(x =>
                    new { x.Orderpriority }
                )
                .Distinct()
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        /// <summary>
        /// This is available to make the API's usable with more available ORM solutions.
        /// </summary>
        [Test]
        public async Task TestLimitOffset()
        {
            var result = await SqlExecutor.Execute($"SELECT name FROM customer LIMIT 10 OFFSET 10");
            var expected = TpchData.Customers
                .Select(x =>
                    new { x.Name }
                )
                .Skip(10)
                .Take(10)
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        /// <summary>
        /// This is available to make the API's usable with more available ORM solutions.
        /// </summary>
        [Test]
        public async Task TestLimitOffsetInner()
        {
            var result = await SqlExecutor.Execute($"SELECT c.name FROM (select name from customer LIMIT 10 OFFSET 10) c");
            var expected = TpchData.Customers
                .Select(x =>
                    new { x.Name }
                )
                .Skip(10)
                .Take(10)
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        /// <summary>
        /// This is available to make the API's usable with more available ORM solutions.
        /// </summary>
        [Test]
        public async Task TestLimitOffsetInnerAndOuter()
        {
            //This can be translated to: skip 20, take 10
            var result = await SqlExecutor.Execute($"SELECT c.name FROM (select name from customer LIMIT 100 OFFSET 10) c LIMIT 10 OFFSET 10");
            var expected = TpchData.Customers
                .Select(x =>
                    new { x.Name }
                )
                .Skip(20)
                .Take(10)
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        /// <summary>
        /// This is available to make the API's usable with more available ORM solutions.
        /// </summary>
        [Test]
        public async Task TestLimit()
        {
            //This can be translated to: skip 20, take 10
            var result = await SqlExecutor.Execute($"SELECT c.name FROM customer c limit 100");
            var expected = TpchData.Customers
                .Select(x =>
                    new { x.Name }
                )
                .Take(100)
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        /// <summary>
        /// This is available to make the API's usable with more available ORM solutions.
        /// </summary>
        [Test]
        public async Task TestOffset()
        {
            var result = await SqlExecutor.Execute($"SELECT c.name FROM customer c offset 100");
            var expected = TpchData.Customers
                .Select(x =>
                    new { x.Name }
                )
                .Skip(100)
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestParameter()
        {
            var parameters = new SqlParameters()
                .Add(SqlParameter.Create("@custkey", 10));
            var result = await SqlExecutor.Execute($"SELECT c.name FROM customer c where c.custkey > @custkey", parameters);

            var expected = TpchData.Customers
                .Where(x => x.Custkey > 10)
                .Select(x =>
                    new { x.Name }
                ).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestLimitOffsetWithParameter()
        {
            var parameters = new SqlParameters()
                .Add(SqlParameter.Create("@limit", 10))
                .Add(SqlParameter.Create("@offset", 10));

            var result = await SqlExecutor.Execute($"SELECT name FROM customer LIMIT @limit OFFSET @offset", parameters);

            var expected = TpchData.Customers
                .Select(x =>
                    new { x.Name }
                )
                .Skip(10)
                .Take(10)
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestCount()
        {
            var result = await SqlExecutor.Execute($"SELECT count(*) FROM customer");

            var expected = TpchData.Customers
                .GroupBy(x => 1)
                .Select(x => new { count = x.LongCount() })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestCountWithGroup()
        {
            var result = await SqlExecutor.Execute($"SELECT count(*), name FROM customer group by name");

            var expected = TpchData.Customers
                .GroupBy(x => x.Name)
                .Select(x => new { count = x.Count(), name = x.Key })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestExecuteScalar()
        {
            var result = await SqlExecutor.ExecuteScalar($"SELECT count(*) FROM customer");

            var expected = TpchData.Customers.Count;

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public async Task TestIsNull()
        {
            var result = await SqlExecutor.Execute("SELECT name FROM customer where name IS NULL");

            var expected = TpchData.Customers
                .Where(x => x.Name == null)
                .Select(x => new { x.Name })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestIsNotNull()
        {
            var result = await SqlExecutor.Execute("SELECT name FROM customer where name IS NOT NULL");

            var expected = TpchData.Customers
                .Where(x => x.Name != null)
                .Select(x => new { x.Name })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestMultiStatement()
        {
            var result = await SqlExecutor.Execute("SELECT name FROM customer where name IS NOT NULL; SELECT name from customer limit 10");

            var expected = TpchData.Customers
                .Where(x => x.Name != null)
                .Select(x => new { x.Name })
                .Take(10)
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public void TestEmptyQuery()
        {
            Assert.That(async () =>
            {
                await SqlExecutor.Execute("");
            }, Throws.TypeOf<SqlErrorException>());
        }

        /// <summary>
        /// This test checks that it is still possible to null check primitives even though it is equal to no returns
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task TestPrimitiveEqualsNull()
        {
            var result = await SqlExecutor.Execute("SELECT Orderkey FROM \"order\" WHERE Orderkey = null");

            var expected = TpchData.Orders
                .Where(x => false)
                .Select(x => new { x.Orderkey })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestPrimitiveNotEqualsNull()
        {
            var result = await SqlExecutor.Execute("SELECT Orderkey FROM \"order\" WHERE Orderkey != null");

            var expected = TpchData.Orders
                .Select(x => new { x.Orderkey })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestPrimitiveIsNull()
        {
            var result = await SqlExecutor.Execute("SELECT Orderkey FROM \"order\" WHERE Orderkey is null");

            var expected = TpchData.Orders
                .Where(x => false)
                .Select(x => new { x.Orderkey })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestPrimitiveIsNotNullNull()
        {
            var result = await SqlExecutor.Execute("SELECT Orderkey FROM \"order\" WHERE Orderkey is not null");

            var expected = TpchData.Orders
                .Select(x => new { x.Orderkey })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringComparisonGreaterAndLessThan()
        {
            var result = await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE Orderpriority >= '5-L' AND Orderpriority < '5-M'");

            var expected = TpchData.Orders
                .Where(x => x.Orderpriority.StartsWith("5-L"))
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringStartsWith()
        {
            var result = await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE Orderpriority like '5-L%'");

            var expected = TpchData.Orders
                .Where(x => x.Orderpriority.StartsWith("5-L"))
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringNotStartsWith()
        {
            var result = await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE Orderpriority NOT LIKE '5-L%'");

            var expected = TpchData.Orders
                .Where(x => !x.Orderpriority.StartsWith("5-L"))
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringContains()
        {
            var result = await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE Orderpriority like '%5-L%'");

            var expected = TpchData.Orders
                .Where(x => x.Orderpriority.Contains("5-L"))
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringContainsIgnoreCase()
        {
            var result = await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE Orderpriority like '%5-l%'");

            var expected = TpchData.Orders
                .Where(x => x.Orderpriority.Contains("5-L"))
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringContainsIgnoreCaseIsNull()
        {
            var result = await SqlExecutor.Execute("SELECT * FROM nulltest WHERE isnull like '%test%'");

            var expected = TestData.GetNullTestData().Where(x => x.IsNull == "test").Select(x => new { x.IsNull }).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringStartsWithIgnoreCase()
        {
            var result = await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE Orderpriority like '5-l%'");

            var expected = TpchData.Orders
                .Where(x => x.Orderpriority.StartsWith("5-L"))
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringStartsWithIgnoreCaseIsNull()
        {
            var result = await SqlExecutor.Execute("SELECT * FROM nulltest WHERE isnull like 'test%'");

            var expected = TestData.GetNullTestData().Where(x => x.IsNull == "test").Select(x => new { x.IsNull }).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringEndsWithIgnoreCase()
        {
            var result = await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE Orderpriority like '%low'");

            var expected = TpchData.Orders
                .Where(x => x.Orderpriority.EndsWith("LOW"))
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringEndsWithIgnoreCaseIsNull()
        {
            var result = await SqlExecutor.Execute("SELECT * FROM nulltest WHERE isnull like '%test'");

            var expected = TestData.GetNullTestData().Where(x => x.IsNull == "test").Select(x => new { x.IsNull }).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringEqualsIgnoreCase()
        {
            var result = await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE Orderpriority like '5-low'");

            var expected = TpchData.Orders
                .Where(x => x.Orderpriority.Equals("5-LOW"))
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringEqualsIgnoreCaseIsNull()
        {
            var result = await SqlExecutor.Execute("SELECT * FROM nulltest WHERE isnull = 'test'");

            var expected = TestData.GetNullTestData().Where(x => x.IsNull == "test").Select(x => new { x.IsNull }).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringEqualsIgnoreCaseIsNullEqualsNull()
        {
            var result = await SqlExecutor.Execute("SELECT * FROM nulltest WHERE isnull is null");

            var expected = TestData.GetNullTestData().Where(x => x.IsNull == null).Select(x => new { x.IsNull }).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringEndsWith()
        {
            var result = await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE Orderpriority like '%5-L'");

            var expected = TpchData.Orders
                .Where(x => x.Orderpriority.EndsWith("5-L"))
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        

        [Test]
        public async Task TestStringLikeEquals()
        {
            var result = await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE Orderpriority like '5-L'");

            var expected = TpchData.Orders
                .Where(x => x.Orderpriority.Equals("5-L"))
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringLikeEqualsParameter()
        {
            var parameters = new SqlParameters()
                .Add(SqlParameter.Create("Parameter", "5-L"));

            var result = await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE Orderpriority like @Parameter", parameters);

            var expected = TpchData.Orders
                .Where(x => x.Orderpriority.Equals("5-L"))
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringLikeStartswithColumn()
        {
            var result = await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE Orderpriority like Orderpriority + '%'");

            var expected = TpchData.Orders
                .Where(x => x.Orderpriority.StartsWith(x.Orderpriority))
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringLikeStartsWithParameter()
        {
            var parameters = new SqlParameters()
                .Add(SqlParameter.Create("Parameter", "5-L"));
            var result = await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE Orderpriority like @Parameter + '%'", parameters);

            var expected = TpchData.Orders
                .Where(x => x.Orderpriority.StartsWith("5-L"))
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringLikeEndsWithParameter()
        {
            var parameters = new SqlParameters()
                .Add(SqlParameter.Create<object>("Parameter", "5-L"));
            var result = await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE Orderpriority like '%' + @Parameter", parameters);

            var expected = TpchData.Orders
                .Where(x => x.Orderpriority.EndsWith("5-L"))
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringLikeContainsParameter()
        {
            var parameters = new SqlParameters()
                .Add(SqlParameter.Create("Parameter", "L"));
            var result = await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE Orderpriority like '%' + @Parameter + '%'", parameters);

            var expected = TpchData.Orders
                .Where(x => x.Orderpriority.Contains("L"))
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestWhereEnumEqualsStringParameter()
        {
            var parameters = new SqlParameters()
               .Add(SqlParameter.Create("Parameter", "testval"));
            var result = await SqlExecutor.Execute("SELECT enum FROM \"enumtable\" WHERE enum = @Parameter", parameters);

            var expected = TestData.GetEnumTestData()
                .Where(x => x.Enum == Models.Enum.testval)
                .Select(x => new { x.Enum })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestStringLikeContainsParameterNotSelectingWhereParameter()
        {
            var parameters = new SqlParameters()
                .Add(SqlParameter.Create("Parameter", "L"));
            var result = await SqlExecutor.Execute("SELECT Orderkey FROM \"order\" WHERE Orderpriority like '%' + @Parameter + '%'", parameters);

            var expected = TpchData.Orders
                .Where(x => x.Orderpriority.Contains("L"))
                .Select(x => new { x.Orderkey })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestInPredicateLong()
        {
            var result = await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE orderkey in (1)");


            var expectedList = new List<long> { 1 };
            var expected = TpchData.Orders
                .Where(x => expectedList.Contains(x.Orderkey))
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestInPredicateString()
        {
            var result = await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE Orderpriority in ('5-L')");

            var expectedList = new List<string> { "5-L" };
            var expected = TpchData.Orders
                .Where(x => expectedList.Contains(x.Orderpriority))
                .Select(x => new { x.Orderkey, x.Orderpriority })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public void TestSearchFunction()
        {
            Assert.That(async () =>
            {
                await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE CONTAINS(*, 'Text')");
            }, Throws.InstanceOf<SqlErrorException>().With.Message.EqualTo("Search is not implemented for this table"));
        }

        [Test]
        public void TestSearchFunctionWithParameter()
        {
            Assert.That(async () =>
            {
                SqlParameters sqlParameters = new SqlParameters()
                    .Add(SqlParameter.Create("P0", "test"));
                await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE CONTAINS(*, @P0)", sqlParameters);
            }, Throws.InstanceOf<SqlErrorException>().With.Message.EqualTo("Search is not implemented for this table"));
        }

        [Test]
        public async Task TestSetVariable()
        {
            var result = await SqlExecutor.Execute(@"
            SET @test = 'test';
            select name from customer;
            ");
        }

        [Test]
        public void TestParameterNotFound()
        {
            Assert.That(async () =>
            {
                SqlParameters sqlParameters = new SqlParameters();
                await SqlExecutor.Execute("SELECT Orderkey, Orderpriority FROM \"order\" WHERE orderkey > @P0", sqlParameters);
            }, Throws.InstanceOf<SqlErrorException>().With.Message.EqualTo("The parameter @P0 could not be found, did you have include @ before the parameter name?"));
        }

        [Test]
        public async Task TestCast()
        {
            var result = await SqlExecutor.Execute("SELECT CAST(orderkey AS single) FROM \"order\"");

            var expected = TpchData.Orders
                .Select(x => new { Orderkey = (float)x.Orderkey })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestWhereNotComparison()
        {
            var result = await SqlExecutor.Execute("SELECT orderkey FROM \"order\" WHERE NOT orderkey != 1");

            var expected = TpchData.Orders
                .Where(x => x.Orderkey == 1)
                .Select(x => new { x.Orderkey })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestBetweenExpressionIntegers()
        {
            var result = await SqlExecutor.Execute("SELECT orderkey FROM \"order\" WHERE orderkey BETWEEN 1 AND 10");

            var expected = TpchData.Orders
                .Where(x => x.Orderkey >= 1 && x.Orderkey <= 10)
                .Select(x => new { x.Orderkey })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestBetweenExpressionStrings()
        {
            var result = await SqlExecutor.Execute("SELECT orderkey FROM \"order\" WHERE Orderpriority BETWEEN '4' AND '5'");

            var expected = TpchData.Orders
                .Where(x => x.Orderpriority.CompareTo("4") >= 0 && x.Orderpriority.CompareTo("5") <= 0)
                .Select(x => new { x.Orderkey })
                .AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        [Test]
        public async Task TestSelectColumnWithTableNamePrefix()
        {
            var result = await SqlExecutor.Execute("select customer.name from customer");
            var expected = TpchData.Customers.Select(x => new { x.Name }).AsQueryable();

            AssertAreEqual(expected, result.Result);
        }

        //select name from customer where name > 'customer#000001500'
        //Gives the wrong results
    }
}
