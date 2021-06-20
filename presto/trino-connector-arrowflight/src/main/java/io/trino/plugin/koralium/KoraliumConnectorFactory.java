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

import com.google.inject.Injector;
import io.airlift.bootstrap.Bootstrap;
import io.airlift.json.JsonModule;
import io.trino.spi.connector.Connector;
import io.trino.spi.connector.ConnectorContext;
import io.trino.spi.connector.ConnectorFactory;
import io.trino.spi.connector.ConnectorHandleResolver;

import java.util.Map;

import static java.util.Objects.requireNonNull;

public class KoraliumConnectorFactory
        implements ConnectorFactory
{
    @Override
    public String getName()
    {
        return "koralium";
    }

    @Override
    public ConnectorHandleResolver getHandleResolver()
    {
        return new KoraliumHandleResolver();
    }

    @Override
    public Connector create(String catalogName, Map<String, String> config, ConnectorContext context)
    {
        requireNonNull(catalogName, "catalogName is null");
        requireNonNull(config, "config is null");

        Bootstrap app = new Bootstrap(
                new JsonModule(),
                new KoraliumConnectorModule(context.getTypeManager(), context.getNodeManager()));

        Injector injector = app.strictConfig()
                .doNotInitializeLogging()
                .setRequiredConfigurationProperties(config)
                .initialize();

        return injector.getInstance(KoraliumConnector.class);
    }
}
