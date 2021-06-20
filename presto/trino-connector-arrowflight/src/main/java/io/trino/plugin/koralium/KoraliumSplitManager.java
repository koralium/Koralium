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

import com.google.common.collect.ImmutableList;
import io.trino.plugin.koralium.cache.QueryCacheFactory;
import io.trino.plugin.koralium.cache.QueryCacheSplitManager;
import io.trino.plugin.koralium.client.FilterExtractor;
import io.trino.plugin.koralium.client.KoraliumClient;
import io.trino.plugin.koralium.client.QueryBuilder;
import io.trino.spi.HostAddress;
import io.trino.spi.connector.ConnectorPartitionHandle;
import io.trino.spi.connector.ConnectorSession;
import io.trino.spi.connector.ConnectorSplit;
import io.trino.spi.connector.ConnectorSplitManager;
import io.trino.spi.connector.ConnectorSplitSource;
import io.trino.spi.connector.ConnectorTableHandle;
import io.trino.spi.connector.ConnectorTransactionHandle;
import io.trino.spi.connector.DynamicFilter;
import io.trino.spi.connector.FixedSplitSource;
import io.trino.spi.predicate.TupleDomain;
import org.apache.arrow.flight.FlightEndpoint;
import org.apache.arrow.flight.FlightInfo;
import org.apache.arrow.flight.Location;

import javax.inject.Inject;

import java.net.URI;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.concurrent.CompletableFuture;
import java.util.concurrent.ExecutionException;

import static io.trino.spi.connector.DynamicFilter.NOT_BLOCKED;
import static java.util.Objects.requireNonNull;

public class KoraliumSplitManager
        implements ConnectorSplitManager
{
    private final KoraliumClient client;
    private final QueryCacheSplitManager queryCacheSplitManager;

    @Inject
    public KoraliumSplitManager(KoraliumClient client, QueryCacheFactory queryCacheFactory)
    {
        this.client = requireNonNull(client, "client is null");
        queryCacheSplitManager = queryCacheFactory.getCacheSplitManager();
    }

    @Override
    public ConnectorSplitSource getSplits(
            ConnectorTransactionHandle transaction,
            ConnectorSession session,
            ConnectorTableHandle table,
            SplitSchedulingStrategy splitSchedulingStrategy,
            DynamicFilter dynamicFilter)
    {
        if (!dynamicFilter.isAwaitable()) {
            return getSplitSource(session, table, splitSchedulingStrategy, dynamicFilter);
        }

        CompletableFuture<?> dynamicFilterFuture = whenCompleted(dynamicFilter);
        CompletableFuture<ConnectorSplitSource> splitSourceFuture = dynamicFilterFuture.thenApply(
                ignored -> getSplitSource(session, table, splitSchedulingStrategy, dynamicFilter));

        return new KoraliumDynamicFilterSplitSource(dynamicFilterFuture, splitSourceFuture);
    }

    private ConnectorSplitSource getSplitSource(
            ConnectorSession session,
            ConnectorTableHandle table,
            SplitSchedulingStrategy splitSchedulingStrategy,
            DynamicFilter dynamicFilter)
    {
        String authToken = session.getIdentity().getExtraCredentials().get("auth_token");

        KoraliumTableHandle tableHandle = (KoraliumTableHandle) table;

        TupleDomain<KoraliumPrestoColumn> dynamicConstraint = dynamicFilter.getCurrentPredicate().transform(KoraliumPrestoColumn.class::cast);
        String filter = FilterExtractor.getFilter(session, tableHandle.getConstraint().transform(KoraliumPrestoColumn.class::cast).intersect(dynamicConstraint));

        QueryBuilder queryBuilder = new QueryBuilder();

        String query = "";

        boolean isCount = false;
        if (tableHandle.getDesiredColumns().isPresent() && tableHandle.getDesiredColumns().get().size() == 0) {
            query = queryBuilder.buildCountQuery(tableHandle.getTableName(), filter, tableHandle.getLimit());
            isCount = true;
        }
        else {
            query = queryBuilder.buildQuery(tableHandle.getDesiredColumns(), tableHandle.getTableName(), filter, tableHandle.getSortOrder(), tableHandle.getLimit());
        }

        Map<String, String> headers = new HashMap<String, String>();

        if (authToken != null) {
            headers.put("Authorization", "Bearer " + authToken);
        }

        headers.put("enable-partitions", "true");

        FlightInfo flightInfo = this.client.getFlightInfo(query, headers);

        List<ConnectorSplit> splits = new ArrayList<>();
        for (FlightEndpoint endpoint : flightInfo.getEndpoints()) {
            ImmutableList.Builder<URI> locationBuilder = new ImmutableList.Builder<>();
            List<Location> locations = endpoint.getLocations();

            if (locations.size() == 0) {
                locationBuilder.add(client.getUri());
            }
            else {
                for (Location location : locations) {
                    locationBuilder.add(location.getUri());
                }
            }

            String splitQuery = new String(endpoint.getTicket().getBytes(), StandardCharsets.UTF_8);
            HostAddress cacheNode = queryCacheSplitManager.getCacheNode(splitQuery);

            splits.add(new KoraliumSplit(endpoint.getTicket().getBytes(), locationBuilder.build(), isCount, cacheNode));
        }

        return new FixedSplitSource(splits);
    }

    private static CompletableFuture<?> whenCompleted(DynamicFilter dynamicFilter)
    {
        if (dynamicFilter.isAwaitable()) {
            return dynamicFilter.isBlocked().thenCompose(ignored -> whenCompleted(dynamicFilter));
        }
        return NOT_BLOCKED;
    }

    private static class KoraliumDynamicFilterSplitSource
            implements ConnectorSplitSource
    {
        private final CompletableFuture<?> dynamicFilterFuture;
        private final CompletableFuture<ConnectorSplitSource> splitSourceFuture;

        private KoraliumDynamicFilterSplitSource(
                CompletableFuture<?> dynamicFilterFuture,
                CompletableFuture<ConnectorSplitSource> splitSourceFuture)
        {
            this.dynamicFilterFuture = requireNonNull(dynamicFilterFuture, "dynamicFilterFuture is null");
            this.splitSourceFuture = requireNonNull(splitSourceFuture, "splitSourceFuture is null");
        }

        @Override
        public CompletableFuture<ConnectorSplitBatch> getNextBatch(ConnectorPartitionHandle partitionHandle, int maxSize)
        {
            return splitSourceFuture.thenCompose(splitSource -> splitSource.getNextBatch(partitionHandle, maxSize));
        }

        @Override
        public void close()
        {
            if (!dynamicFilterFuture.cancel(true)) {
                splitSourceFuture.thenAccept(ConnectorSplitSource::close);
            }
        }

        @Override
        public boolean isFinished()
        {
            if (!splitSourceFuture.isDone()) {
                return false;
            }
            if (splitSourceFuture.isCompletedExceptionally()) {
                return false;
            }
            try {
                return splitSourceFuture.get().isFinished();
            }
            catch (InterruptedException | ExecutionException e) {
                throw new RuntimeException(e);
            }
        }
    }
}
