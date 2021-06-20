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
package io.trino.plugin.koralium;

import com.google.common.collect.ImmutableMap;
import io.trino.testing.AbstractTestQueryFramework;
import io.trino.testing.QueryRunner;
import io.trino.tpch.TpchTable;
import org.testng.annotations.AfterClass;
import org.testng.annotations.Test;

import java.util.Map;

public class TestCache
        extends AbstractTestQueryFramework
{
    private QueryServer server;
    private RedisServer redisServer;

    @Override
    protected QueryRunner createQueryRunner() throws Exception
    {
        redisServer = new RedisServer();

        redisServer.start();
        server = new QueryServer();
        Map<String, String> config = ImmutableMap.<String, String>builder()
                .put("koralium.cache.enabled", "true")
                .put("koralium.cache.redisUrl", redisServer.getHost() + ":" + redisServer.getPort())
                .build();

        String accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlRlc3QgdGVzdCIsInVuaXF1ZV9uYW1lIjoidGVzdCIsImlhdCI6MTUxNjIzOTAyMn0.aF80OiteMckPhSQcAL549V4AcyKHJA8LUs4mhzBnf2w";
        return KoraliumQueryRunner.createGrpcQueryRunner("127.0.0.1:5016", ImmutableMap.of(), "koralium", "default", TpchTable.getTables(), server, accessToken, config);
    }

    @AfterClass(alwaysRun = true)
    public void tearDown()
    {
        if (server != null) {
            server.close();
        }
        if (redisServer != null) {
            redisServer.close();
        }
    }

    @Test
    public void testCache()
    {
        this.computeActual("SELECT sum(l.Orderkey) FROM lineitem l left join orders o on l.orderkey = o.orderkey group by o.Orderstatus");
        this.computeActual("SELECT sum(l.Orderkey) FROM lineitem l left join orders o on l.orderkey = o.orderkey group by o.Orderstatus");
        this.computeActual("SELECT sum(l.Orderkey) FROM lineitem l left join orders o on l.orderkey = o.orderkey group by o.Orderstatus");
        this.computeActual("SELECT sum(l.Orderkey) FROM lineitem l left join orders o on l.orderkey = o.orderkey group by o.Orderstatus");
    }

    @Test
    public void testSlowQuery()
    {
        this.computeActual("SELECT SUM(C_24) AS C1_26 FROM (SELECT C_21 AS C_24 FROM (SELECT C_4f54424c.\"orderkey\" AS C_43, C_4f54424c.\"partkey\" AS C_0, C_4f54424c.\"suppkey\" AS C_6, C_4f54424c.\"linenumber\" AS C_2, C_4f54424c.\"quantity\" AS C_21, C_4f54424c.\"extendedprice\" AS C_20, C_4f54424c.\"discount\" AS C_1, C_4f54424c.\"tax\" AS C_18, C_4f54424c.\"returnflag\" AS C_3, C_4f54424c.\"linestatus\" AS C_7, C_4f54424c.\"shipdate\" AS C_15, C_4f54424c.\"commitdate\" AS C_14, C_4f54424c.\"receiptdate\" AS C_8, C_4f54424c.\"shipinstruct\" AS C_19, C_4f54424c.\"shipmode\" AS C_11, C_4f54424c.\"comment\" AS C_9, C_4954424c.\"orderkey\" AS C_4331, C_4954424c.\"custkey\" AS C_16, C_4954424c.\"orderstatus\" AS C_4, C_4954424c.\"totalprice\" AS C_5, C_4954424c.\"orderdate\" AS C_10, C_4954424c.\"orderpriority\" AS C_12, C_4954424c.\"clerk\" AS C_13, C_4954424c.\"shippriority\" AS C_17, C_4954424c.\"comment\" AS C_4332 FROM \"default\".\"lineitem\" C_4f54424c LEFT OUTER JOIN \"default\".\"orders\" C_4954424c ON (C_4f54424c.\"orderkey\" = C_4954424c.\"orderkey\") WHERE (CAST(C_4954424c.\"custkey\" AS DOUBLE) = 2.000000000000000E+001)) OTBL_23 LEFT OUTER JOIN \"default\".\"customer\" ITBL_22 ON (C_16 = ITBL_22.\"custkey\") WHERE (ITBL_22.\"name\" = 'Customer#000000020')) ITBL_25\n");
        this.computeActual("SELECT SUM(C_24) AS C1_26 FROM (SELECT C_21 AS C_24 FROM (SELECT C_4f54424c.\"orderkey\" AS C_43, C_4f54424c.\"partkey\" AS C_0, C_4f54424c.\"suppkey\" AS C_6, C_4f54424c.\"linenumber\" AS C_2, C_4f54424c.\"quantity\" AS C_21, C_4f54424c.\"extendedprice\" AS C_20, C_4f54424c.\"discount\" AS C_1, C_4f54424c.\"tax\" AS C_18, C_4f54424c.\"returnflag\" AS C_3, C_4f54424c.\"linestatus\" AS C_7, C_4f54424c.\"shipdate\" AS C_15, C_4f54424c.\"commitdate\" AS C_14, C_4f54424c.\"receiptdate\" AS C_8, C_4f54424c.\"shipinstruct\" AS C_19, C_4f54424c.\"shipmode\" AS C_11, C_4f54424c.\"comment\" AS C_9, C_4954424c.\"orderkey\" AS C_4331, C_4954424c.\"custkey\" AS C_16, C_4954424c.\"orderstatus\" AS C_4, C_4954424c.\"totalprice\" AS C_5, C_4954424c.\"orderdate\" AS C_10, C_4954424c.\"orderpriority\" AS C_12, C_4954424c.\"clerk\" AS C_13, C_4954424c.\"shippriority\" AS C_17, C_4954424c.\"comment\" AS C_4332 FROM \"default\".\"lineitem\" C_4f54424c LEFT OUTER JOIN \"default\".\"orders\" C_4954424c ON (C_4f54424c.\"orderkey\" = C_4954424c.\"orderkey\") WHERE (CAST(C_4954424c.\"custkey\" AS DOUBLE) = 2.000000000000000E+001)) OTBL_23 LEFT OUTER JOIN \"default\".\"customer\" ITBL_22 ON (C_16 = ITBL_22.\"custkey\") WHERE (ITBL_22.\"name\" = 'Customer#000000020')) ITBL_25\n");
        this.computeActual("SELECT SUM(C_24) AS C1_26 FROM (SELECT C_21 AS C_24 FROM (SELECT C_4f54424c.\"orderkey\" AS C_43, C_4f54424c.\"partkey\" AS C_0, C_4f54424c.\"suppkey\" AS C_6, C_4f54424c.\"linenumber\" AS C_2, C_4f54424c.\"quantity\" AS C_21, C_4f54424c.\"extendedprice\" AS C_20, C_4f54424c.\"discount\" AS C_1, C_4f54424c.\"tax\" AS C_18, C_4f54424c.\"returnflag\" AS C_3, C_4f54424c.\"linestatus\" AS C_7, C_4f54424c.\"shipdate\" AS C_15, C_4f54424c.\"commitdate\" AS C_14, C_4f54424c.\"receiptdate\" AS C_8, C_4f54424c.\"shipinstruct\" AS C_19, C_4f54424c.\"shipmode\" AS C_11, C_4f54424c.\"comment\" AS C_9, C_4954424c.\"orderkey\" AS C_4331, C_4954424c.\"custkey\" AS C_16, C_4954424c.\"orderstatus\" AS C_4, C_4954424c.\"totalprice\" AS C_5, C_4954424c.\"orderdate\" AS C_10, C_4954424c.\"orderpriority\" AS C_12, C_4954424c.\"clerk\" AS C_13, C_4954424c.\"shippriority\" AS C_17, C_4954424c.\"comment\" AS C_4332 FROM \"default\".\"lineitem\" C_4f54424c LEFT OUTER JOIN \"default\".\"orders\" C_4954424c ON (C_4f54424c.\"orderkey\" = C_4954424c.\"orderkey\") WHERE (CAST(C_4954424c.\"custkey\" AS DOUBLE) = 2.000000000000000E+001)) OTBL_23 LEFT OUTER JOIN \"default\".\"customer\" ITBL_22 ON (C_16 = ITBL_22.\"custkey\") WHERE (ITBL_22.\"name\" = 'Customer#000000020')) ITBL_25\n");
        this.computeActual("SELECT SUM(C_24) AS C1_26 FROM (SELECT C_21 AS C_24 FROM (SELECT C_4f54424c.\"orderkey\" AS C_43, C_4f54424c.\"partkey\" AS C_0, C_4f54424c.\"suppkey\" AS C_6, C_4f54424c.\"linenumber\" AS C_2, C_4f54424c.\"quantity\" AS C_21, C_4f54424c.\"extendedprice\" AS C_20, C_4f54424c.\"discount\" AS C_1, C_4f54424c.\"tax\" AS C_18, C_4f54424c.\"returnflag\" AS C_3, C_4f54424c.\"linestatus\" AS C_7, C_4f54424c.\"shipdate\" AS C_15, C_4f54424c.\"commitdate\" AS C_14, C_4f54424c.\"receiptdate\" AS C_8, C_4f54424c.\"shipinstruct\" AS C_19, C_4f54424c.\"shipmode\" AS C_11, C_4f54424c.\"comment\" AS C_9, C_4954424c.\"orderkey\" AS C_4331, C_4954424c.\"custkey\" AS C_16, C_4954424c.\"orderstatus\" AS C_4, C_4954424c.\"totalprice\" AS C_5, C_4954424c.\"orderdate\" AS C_10, C_4954424c.\"orderpriority\" AS C_12, C_4954424c.\"clerk\" AS C_13, C_4954424c.\"shippriority\" AS C_17, C_4954424c.\"comment\" AS C_4332 FROM \"default\".\"lineitem\" C_4f54424c LEFT OUTER JOIN \"default\".\"orders\" C_4954424c ON (C_4f54424c.\"orderkey\" = C_4954424c.\"orderkey\") WHERE (CAST(C_4954424c.\"custkey\" AS DOUBLE) = 2.000000000000000E+001)) OTBL_23 LEFT OUTER JOIN \"default\".\"customer\" ITBL_22 ON (C_16 = ITBL_22.\"custkey\") WHERE (ITBL_22.\"name\" = 'Customer#000000020')) ITBL_25\n");
    }
}
