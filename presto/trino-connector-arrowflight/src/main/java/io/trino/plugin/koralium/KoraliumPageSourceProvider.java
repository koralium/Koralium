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

import io.trino.plugin.koralium.cache.QueryCache;
import io.trino.plugin.koralium.cache.QueryCacheEntry;
import io.trino.plugin.koralium.cache.QueryCacheFactory;
import io.trino.spi.NodeManager;
import io.trino.spi.connector.ColumnHandle;
import io.trino.spi.connector.ConnectorPageSource;
import io.trino.spi.connector.ConnectorPageSourceProvider;
import io.trino.spi.connector.ConnectorSession;
import io.trino.spi.connector.ConnectorSplit;
import io.trino.spi.connector.ConnectorTableHandle;
import io.trino.spi.connector.ConnectorTransactionHandle;
import io.trino.spi.connector.DynamicFilter;

import javax.inject.Inject;

import java.nio.charset.StandardCharsets;
import java.util.List;

import static com.google.common.collect.ImmutableList.toImmutableList;

public class KoraliumPageSourceProvider
        implements ConnectorPageSourceProvider
{
    private final QueryCache queryCache;
    private final NodeManager nodeManager;

    @Inject
    public KoraliumPageSourceProvider(QueryCacheFactory queryCacheFactory, NodeManager nodeManager)
    {
        this.queryCache = queryCacheFactory.getCache();
        this.nodeManager = nodeManager;
    }

    @Override
    public ConnectorPageSource createPageSource(
            ConnectorTransactionHandle transaction,
            ConnectorSession session,
            ConnectorSplit split,
            ConnectorTableHandle table,
            List<ColumnHandle> columns,
            DynamicFilter dynamicFilter)
    {
        List<KoraliumPrestoColumn> columnHandles = columns.stream()
                .map(KoraliumPrestoColumn.class::cast)
                .collect(toImmutableList());

        KoraliumSplit koraliumSplit = (KoraliumSplit) split;

        String query = new String(koraliumSplit.getTicket(), StandardCharsets.UTF_8);

        QueryCacheEntry cacheEntry = queryCache.get(query);
        if (cacheEntry != null) {
            return new KoraliumPageSourceCache(cacheEntry.getIterator());
        }

        return new KoraliumPageSource(koraliumSplit, columnHandles, session, queryCache, query);
    }
}
