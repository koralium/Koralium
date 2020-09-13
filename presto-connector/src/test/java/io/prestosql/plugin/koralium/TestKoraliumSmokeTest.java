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
package io.prestosql.plugin.koralium;

import com.google.common.collect.ImmutableMap;
import io.prestosql.Session;
import io.prestosql.spi.type.BigintType;
import io.prestosql.spi.type.RealType;
import io.prestosql.spi.type.Type;
import io.prestosql.spi.type.VarcharType;
import io.prestosql.sql.analyzer.FeaturesConfig;
import io.prestosql.testing.AbstractTestIntegrationSmokeTest;
import io.prestosql.testing.DistributedQueryRunner;
import io.prestosql.testing.MaterializedResult;
import io.prestosql.testing.QueryRunner;
import io.prestosql.testing.ResultWithQueryId;
import io.prestosql.testing.assertions.Assert;
import io.prestosql.tpch.TpchTable;
import org.assertj.core.api.Assertions;
import org.testng.annotations.AfterClass;
import org.testng.annotations.Test;

import static io.prestosql.SystemSessionProperties.JOIN_DISTRIBUTION_TYPE;

public class TestKoraliumSmokeTest
        extends AbstractTestIntegrationSmokeTest
{
    private QueryServer server;

    @Override
    protected QueryRunner createQueryRunner() throws Exception
    {
        server = new QueryServer();
        String accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlRlc3QgdGVzdCIsInVuaXF1ZV9uYW1lIjoidGVzdCIsImlhdCI6MTUxNjIzOTAyMn0.aF80OiteMckPhSQcAL549V4AcyKHJA8LUs4mhzBnf2w";
        return KoraliumQueryRunner.createGrpcQueryRunner("127.0.0.1:5016", ImmutableMap.of(), "koralium", "default", TpchTable.getTables(), server, accessToken);
    }

    @AfterClass(alwaysRun = true)
    public void tearDown()
    {
        server.close();
    }

    @Test
    public void testDynamicFilter()
    {
        Session session = Session.builder(getSession())
                .setSystemProperty(JOIN_DISTRIBUTION_TYPE, FeaturesConfig.JoinDistributionType.BROADCAST.name())
                .build();

        DistributedQueryRunner runner = (DistributedQueryRunner) getQueryRunner();

        ResultWithQueryId<MaterializedResult> result = runner.executeWithQueryId(
                session,
                "SELECT * FROM lineitem JOIN orders ON lineitem.orderkey = orders.orderkey AND orders.comment = 'nstructions sleep furiously among '");
    }

    @Test
    public void testGetSecureData()
    {
        assertQuery("select orderkey from secure", "select orderkey from orders");
    }

    @Override
    public void testShowCreateTable()
    {
        Assertions.assertThat((String) this.computeActual("SHOW CREATE TABLE orders").getOnlyValue()).matches("CREATE TABLE \\w+\\.\\w+\\.orders \\Q(\n   orderkey bigint,\n   custkey bigint,\n   orderstatus varchar,\n   totalprice double,\n   orderdate timestamp(3),\n   orderpriority varchar,\n   clerk varchar,\n   shippriority integer,\n   comment varchar\n)");
    }

    @Test
    public void testStringKeyIndexJoin()
    {
        MaterializedResult expectedResult = MaterializedResult.resultBuilder(this.getQueryRunner().getDefaultSession(),
                VarcharType.VARCHAR, VarcharType.VARCHAR, VarcharType.VARCHAR, VarcharType.VARCHAR)
                .row("test employee", "1", "1", "test company")
                .build();

        MaterializedResult result = computeActual("select e.*, c.*  from employee e inner join company c on e.companyid = c.companyid");

        Assert.assertEquals(result, expectedResult);
    }

    @Test
    public void TestFloat()
    {
        MaterializedResult expectedResult = MaterializedResult.resultBuilder(this.getQueryRunner().getDefaultSession(),
                RealType.REAL)
                .row(3.0f)
                .row(7.0f)
                .build();
        MaterializedResult result = computeActual("select FloatValue  from test");

        Assert.assertEquals(result, expectedResult);
    }

    @Test
    public void testTopN()
    {
        MaterializedResult expectedResult = MaterializedResult.resultBuilder(this.getQueryRunner().getDefaultSession(),
                BigintType.BIGINT)
                .row(56963L)
                .build();

        MaterializedResult result = computeActual("select Orderkey from orders order by comment limit 1");

        Assert.assertEquals(result, expectedResult);
    }

    @Override
    public void testDescribeTable()
    {
        MaterializedResult expectedColumns = MaterializedResult.resultBuilder(this.getQueryRunner().getDefaultSession(),
                new Type[]{VarcharType.VARCHAR, VarcharType.VARCHAR, VarcharType.VARCHAR, VarcharType.VARCHAR})
                .row(new Object[]{"orderkey", "bigint", "", ""})
                .row(new Object[]{"custkey", "bigint", "", ""})
                .row(new Object[]{"orderstatus", "varchar", "", ""})
                .row(new Object[]{"totalprice", "double", "", ""})
                .row(new Object[]{"orderdate", "timestamp(3)", "", ""})
                .row(new Object[]{"orderpriority", "varchar", "", ""})
                .row(new Object[]{"clerk", "varchar", "", ""})
                .row(new Object[]{"shippriority", "integer", "", ""})
                .row(new Object[]{"comment", "varchar", "", ""}).build();
        MaterializedResult actualColumns = this.computeActual("DESCRIBE orders");
        Assert.assertEquals(actualColumns, expectedColumns);
    }

    @Test
    public void testDateTime()
    {
        this.assertQuery("SELECT orderdate FROM orders where orderkey = 1");
    }

    @Test
    public void testTemp()
    {
        assertQuery("SELECT COUNT(*) FROM lineitem JOIN orders ON NOT NOT lineitem.orderkey = orders.orderkey AND NOT NOT lineitem.quantity > 2");
    }
}
