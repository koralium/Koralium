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

import io.airlift.bootstrap.LifeCycleManager;
import io.prestosql.spi.connector.Connector;
import io.prestosql.spi.connector.ConnectorMetadata;
import io.prestosql.spi.connector.ConnectorPageSourceProvider;
import io.prestosql.spi.connector.ConnectorSplitManager;
import io.prestosql.spi.connector.ConnectorTransactionHandle;
import io.prestosql.spi.transaction.IsolationLevel;

import javax.inject.Inject;

import static java.util.Objects.requireNonNull;

public class KoraliumConnector
        implements Connector
{
    private final LifeCycleManager lifeCycleManager;
    private final KoraliumMetadata metadata;
    private final KoraliumSplitManager splitManager;
    private final KoraliumPageSourceProvider pageSourceProvider;

    @Inject
    public KoraliumConnector(
            LifeCycleManager lifeCycleManager,
            KoraliumMetadata metadata,
            KoraliumSplitManager splitManager,
            KoraliumPageSourceProvider pageSourceProvider)
    {
        this.lifeCycleManager = requireNonNull(lifeCycleManager, "lifeCycleManager is null");
        this.metadata = requireNonNull(metadata, "metadata is null");
        this.splitManager = requireNonNull(splitManager, "splitManager is null");
        this.pageSourceProvider = requireNonNull(pageSourceProvider, "pageSourceProvider is null");
    }

    @Override
    public ConnectorTransactionHandle beginTransaction(IsolationLevel isolationLevel, boolean readOnly)
    {
        return KoraliumTransactionHandle.INSTANCE;
    }

    @Override
    public ConnectorMetadata getMetadata(ConnectorTransactionHandle transactionHandle)
    {
        return metadata;
    }

    @Override
    public ConnectorSplitManager getSplitManager()
    {
        return splitManager;
    }

    @Override
    public ConnectorPageSourceProvider getPageSourceProvider()
    {
        return pageSourceProvider;
    }

    @Override
    public final void shutdown()
    {
        lifeCycleManager.stop();
    }
}
