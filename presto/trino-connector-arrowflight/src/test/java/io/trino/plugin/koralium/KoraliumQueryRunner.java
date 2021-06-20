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
import io.airlift.log.Logger;
import io.trino.Session;
import io.trino.metadata.QualifiedObjectName;
import io.trino.plugin.tpch.TpchPlugin;
import io.trino.spi.security.Identity;
import io.trino.spi.type.TimeZoneKey;
import io.trino.testing.DistributedQueryRunner;
import io.trino.testing.QueryRunner;
import io.trino.testing.TestingTrinoClient;
import io.trino.tpch.TpchTable;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.HashMap;
import java.util.Map;

import static io.trino.plugin.tpch.TpchMetadata.TINY_SCHEMA_NAME;
import static io.trino.testing.TestingSession.testSessionBuilder;
import static java.lang.String.format;
import static java.util.Locale.ENGLISH;

public final class KoraliumQueryRunner
{
    private KoraliumQueryRunner() {}

    private static final Logger LOG = Logger.get(KoraliumQueryRunner.class);

    private static final String TPCH_SCHEMA = "tpch";

    public static DistributedQueryRunner createGrpcQueryRunner(
            String uri,
            Map<String, String> extraProperties,
            String catalog,
            String schema,
            Iterable<TpchTable<?>> tables,
            QueryServer server,
            String authToken,
            Map<String, String> extraConfig) throws Exception
    {
        DistributedQueryRunner queryRunner = null;

        queryRunner = DistributedQueryRunner.builder(createSession(catalog, schema, authToken))
                .setExtraProperties(extraProperties)
                .build();

        queryRunner.installPlugin(new TpchPlugin());
        queryRunner.createCatalog("tpch", "tpch");

        TestingKoraliumConnectorFactory testFactory = new TestingKoraliumConnectorFactory();

        TestingTrinoClient prestoClient = queryRunner.getClient();

        for (TpchTable<?> table : tables) {
            getTpchTopic(prestoClient, table);
        }

        if (server != null) {
            server.start();

            uri = server.getHost() + ":" + server.getPort();
        }

        installGrpcPlugin(uri, queryRunner, testFactory, extraConfig);

        return queryRunner;
    }

    private static void getTpchTopic(TestingTrinoClient prestoClient, TpchTable<?> table) throws FileNotFoundException
    {
        CsvOutput csvOutput = new CsvOutput();
        DataLoader loader = new DataLoader(
                prestoClient.getServer(),
                prestoClient.getDefaultSession(),
                table.getTableName().toLowerCase(ENGLISH),
                TPCH_SCHEMA,
                csvOutput);

        loader.execute(format("SELECT * from %s", new QualifiedObjectName(TPCH_SCHEMA, TINY_SCHEMA_NAME, table.getTableName().toLowerCase(ENGLISH))));

        //Create the tmpData directory if it does not exist
        File file = new File("./tmpData");
        boolean dirCreated = file.mkdir();

        csvOutput.print("./tmpData/" + table.getTableName() + ".csv");
    }

    private static void installGrpcPlugin(String uri, QueryRunner queryRunner, TestingKoraliumConnectorFactory factory, Map<String, String> extraConfig)
    {
        queryRunner.installPlugin(new KoraliumPlugin(factory));
        ImmutableMap.Builder<String, String> builder = ImmutableMap.<String, String>builder()
                .put("koralium.url", uri);

        builder.putAll(extraConfig);

        Map<String, String> config = builder.build();

        queryRunner.createCatalog("koralium", "koralium", config);
    }

    public static Session createSession(String catalog, String schema, String authToken)
    {
        HashMap<String, String> extraCredentials = new HashMap<>();
        if (authToken != null) {
            extraCredentials.put("auth_token", authToken);
        }
        Identity rootIdentity = Identity.forUser("root").withAdditionalExtraCredentials(extraCredentials).build();
        return testSessionBuilder().setTimeZoneKey(TimeZoneKey.UTC_KEY).setCatalog(catalog).setSchema(schema).setIdentity(rootIdentity).build();
    }

    public static Session createSession(String schema)
    {
        return testSessionBuilder().setCatalog("koralium").setSchema(schema).build();
    }
}
