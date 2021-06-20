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
import io.trino.testing.AbstractTestAggregations;
import io.trino.testing.QueryRunner;
import io.trino.tpch.TpchTable;
import org.testng.annotations.AfterClass;

public class TestKoraliumAggregations
        extends AbstractTestAggregations
{
    private QueryServer server;

    @Override
    protected QueryRunner createQueryRunner() throws Exception
    {
        server = new QueryServer();
        return KoraliumQueryRunner.createGrpcQueryRunner("127.0.0.1:5016", ImmutableMap.of(), "koralium", "default", TpchTable.getTables(), server, null, ImmutableMap.of());
    }

    @AfterClass(alwaysRun = true)
    public void tearDown()
    {
        server.close();
    }

    @Override
    public void testApproximateCountDistinct()
    {
        //Skip this test
    }
}
