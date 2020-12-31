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

import com.google.common.collect.ImmutableList;
import com.google.common.collect.ImmutableMap;
import io.prestosql.Session;
import io.prestosql.SystemSessionProperties;
import io.prestosql.spi.type.ArrayType;
import io.prestosql.spi.type.BigintType;
import io.prestosql.spi.type.BooleanType;
import io.prestosql.spi.type.IntegerType;
import io.prestosql.spi.type.RealType;
import io.prestosql.spi.type.RowType;
import io.prestosql.spi.type.SmallintType;
import io.prestosql.spi.type.Type;
import io.prestosql.spi.type.VarbinaryType;
import io.prestosql.spi.type.VarcharType;
import io.prestosql.sql.analyzer.FeaturesConfig;
import io.prestosql.testing.AbstractTestIntegrationSmokeTest;
import io.prestosql.testing.DistributedQueryRunner;
import io.prestosql.testing.MaterializedResult;
import io.prestosql.testing.MaterializedRow;
import io.prestosql.testing.QueryRunner;
import io.prestosql.testing.ResultWithQueryId;
import io.prestosql.testing.assertions.Assert;
import io.prestosql.tpch.TpchTable;
import org.assertj.core.api.Assertions;
import org.testng.annotations.AfterClass;
import org.testng.annotations.Test;

import java.nio.ByteBuffer;

import static io.prestosql.SystemSessionProperties.JOIN_DISTRIBUTION_TYPE;

public class TestKoraliumSmokeTest
        extends AbstractTestIntegrationSmokeTest
{
    private QueryServer server;

    @Override
    protected QueryRunner createQueryRunner() throws Exception
    {
        //server = new QueryServer();
        String accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlRlc3QgdGVzdCIsInVuaXF1ZV9uYW1lIjoidGVzdCIsImlhdCI6MTUxNjIzOTAyMn0.aF80OiteMckPhSQcAL549V4AcyKHJA8LUs4mhzBnf2w";
        return KoraliumQueryRunner.createGrpcQueryRunner("127.0.0.1:5016", ImmutableMap.of(), "koralium", "default", TpchTable.getTables(), null, accessToken, ImmutableMap.of());
    }

    @AfterClass(alwaysRun = true)
    public void tearDown()
    {
        if (server != null) {
            server.close();
        }
    }

    @Test
    public void TestSelectEmpty()
    {
        MaterializedResult result = computeActual("select intvalue from test where intvalue = 5");
    }

    @Test
    public void TestSelectObject()
    {
        ImmutableList.Builder<RowType.Field> otherObjectBuilder = ImmutableList.builder();
        otherObjectBuilder.add(RowType.field("name", VarcharType.createUnboundedVarcharType()));
        Type otherObjectType = RowType.from(otherObjectBuilder.build());

        ImmutableList.Builder<RowType.Field> testObjectBuilder = ImmutableList.builder();
        testObjectBuilder.add(RowType.field("testtest", VarcharType.createUnboundedVarcharType()));
        testObjectBuilder.add(RowType.field("otherobject", otherObjectType));
        Type testObjectType = RowType.from(testObjectBuilder.build());

        MaterializedResult expectedResult = MaterializedResult.resultBuilder(this.getQueryRunner().getDefaultSession(),
                testObjectType)
                .row(new MaterializedRow(5, ImmutableList.of("testar1", new MaterializedRow(5, ImmutableList.of("other")))))
                .row(new MaterializedRow(5, ImmutableList.of("testar2", new MaterializedRow(5, ImmutableList.of("other2")))))
                .build();

        MaterializedResult result = computeActual("select testobject from test");

        Assert.assertEquals(result, expectedResult);
    }

    @Test
    public void TestSelectList()
    {
        MaterializedResult expectedResult = MaterializedResult.resultBuilder(this.getQueryRunner().getDefaultSession(),
                new ArrayType(IntegerType.INTEGER))
                .row(ImmutableList.of(1, 5))
                .row(ImmutableList.of(2, 6))
                .build();

        MaterializedResult result = computeActual("select testlist from test");

        Assert.assertEquals(result, expectedResult);
    }

    @Test
    public void TestSelectBool()
    {
        MaterializedResult expectedResult = MaterializedResult.resultBuilder(this.getQueryRunner().getDefaultSession(),
                BooleanType.BOOLEAN)
                .row(true)
                .row(false)
                .build();

        MaterializedResult result = computeActual("select boolvalue from test");

        Assert.assertEquals(result, expectedResult);
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
    public void TestCount()
    {
        MaterializedResult expectedResult = MaterializedResult.resultBuilder(this.getQueryRunner().getDefaultSession(),
                BigintType.BIGINT)
                .row(2L)
                .build();
        MaterializedResult result = computeActual("select count(*) from test");

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

    @Test
    public void testAggregatePushdown()
    {
        Session session = Session.builder(getSession())
                .setSystemProperty(JOIN_DISTRIBUTION_TYPE, FeaturesConfig.JoinDistributionType.BROADCAST.name())
                .setSystemProperty(SystemSessionProperties.PUSH_AGGREGATION_THROUGH_OUTER_JOIN, "true")
                .setSystemProperty(SystemSessionProperties.PUSH_PARTIAL_AGGREGATION_THROUGH_JOIN, "true")
                .setSystemProperty(SystemSessionProperties.PREFER_PARTIAL_AGGREGATION, "true")
                .build();

        DistributedQueryRunner runner = (DistributedQueryRunner) getQueryRunner();
        ResultWithQueryId<MaterializedResult> result = runner.executeWithQueryId(
                session,
                "SELECT sum(lineitem.Quantity) FROM lineitem where orderkey = 1");
    }

    @Test
    public void TestInt16()
    {
        MaterializedResult expectedResult = MaterializedResult.resultBuilder(this.getQueryRunner().getDefaultSession(),
                SmallintType.SMALLINT)
                .row((short) 1)
                .row((short) 3)
                .row((short) 17)
                .row((short) 1)
                .row((short) 3)
                .build();

        MaterializedResult result = this.computeActual("SELECT shortvalue FROM typetest");

        Assert.assertEquals(result, expectedResult);
    }

    @Test
    public void TestUInt32()
    {
        MaterializedResult expectedResult = MaterializedResult.resultBuilder(this.getQueryRunner().getDefaultSession(),
                BigintType.BIGINT)
                .row(1L)
                .row(3L)
                .row(17L)
                .row(1L)
                .row(3L)
                .build();

        MaterializedResult result = this.computeActual("SELECT UIntValue FROM typetest");

        Assert.assertEquals(result, expectedResult);
    }

    @Test
    public void TestUInt64()
    {
        MaterializedResult expectedResult = MaterializedResult.resultBuilder(this.getQueryRunner().getDefaultSession(),
                BigintType.BIGINT)
                .row(1L)
                .row(3L)
                .row(17L)
                .row(1L)
                .row(3L)
                .build();

        MaterializedResult result = this.computeActual("SELECT ULongValue FROM typetest");

        Assert.assertEquals(result, expectedResult);
    }

    @Test
    public void TestUInt8()
    {
        MaterializedResult expectedResult = MaterializedResult.resultBuilder(this.getQueryRunner().getDefaultSession(),
                SmallintType.SMALLINT)
                .row((short) 1)
                .row((short) 3)
                .row((short) 17)
                .row((short) 1)
                .row((short) 3)
                .build();

        MaterializedResult result = this.computeActual("SELECT ByteValue FROM typetest");

        Assert.assertEquals(result, expectedResult);
    }

    @Test
    public void TestBinary()
    {
        ByteBuffer buffer = ByteBuffer.allocate(3);
        buffer.put(0, (byte) 1);
        buffer.put(1, (byte) 3);
        buffer.put(2, (byte) 17);

        MaterializedResult expectedResult = MaterializedResult.resultBuilder(this.getQueryRunner().getDefaultSession(),
                VarbinaryType.VARBINARY)
                .row(new Object[]{buffer})
                .row(new Object[]{null})
                .row(new Object[]{buffer})
                .row(new Object[]{null})
                .row(new Object[]{buffer})
                .build();

        MaterializedResult result = this.computeActual("SELECT BinaryValue FROM typetest");

        Assert.assertEquals(result, expectedResult);
    }
}
