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

import io.grpc.Metadata;
import io.grpc.stub.MetadataUtils;
import io.grpc.stub.StreamObserver;
import io.prestosql.plugin.koralium.client.FilterExtractor;
import io.prestosql.plugin.koralium.client.PrestoKoraliumClient;
import io.prestosql.plugin.koralium.client.QueryBuilder;
import io.prestosql.spi.block.PageBuilderStatus;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.connector.DynamicFilter;
import io.prestosql.spi.predicate.TupleDomain;

import java.util.List;
import java.util.concurrent.CompletableFuture;

public class KoraliumPageSource
        extends KoraliumBasePageSource
{
    private final KoraliumServiceGrpc.KoraliumServiceStub client;
    private final DynamicFilter dynamicFilter;
    private final List<KoraliumColumnHandle> columns;
    private final TupleDomain<KoraliumColumnHandle> constraint;
    private final KoraliumTableHandle tableHandle;
    private boolean querySent;

    public KoraliumPageSource(ConnectorSession session,
                              List<KoraliumColumnHandle> columns,
                              PrestoKoraliumClient prestoKoraliumClient,
                              KoraliumTableHandle tableHandle,
                              KoraliumSplit split,
                              TupleDomain<KoraliumColumnHandle> constraint,
                              DynamicFilter dynamicFilter)
    {
        super(session, columns);

        this.dynamicFilter = dynamicFilter;
        this.columns = columns;
        this.constraint = constraint;
        this.tableHandle = tableHandle;

        String authToken = session.getIdentity().getExtraCredentials().get("auth_token");

        Metadata metadata = new Metadata();

        if (authToken != null) {
            metadata.put(Metadata.Key.of("Authorization", Metadata.ASCII_STRING_MARSHALLER), "Bearer " + authToken);
        }

        this.client = MetadataUtils.attachHeaders(KoraliumServiceGrpc.newStub(prestoKoraliumClient.getChannel()), metadata);
    }

    private void executeCount(String query)
    {
        Presto.QueryRequest.Builder requestBuilder = Presto.QueryRequest.newBuilder()
                .setMaxBatchSize(PageBuilderStatus.DEFAULT_MAX_PAGE_SIZE_IN_BYTES)
                .setQuery(query);

        StreamObserver<Presto.Scalar> responseObserver = new StreamObserver<>() {
            @Override
            public void onNext(Presto.Scalar summary)
            {
                addCompletedCount(summary);
            }

            @Override
            public void onError(Throwable t)
            {
                //TODO
                setError(t);
            }

            @Override
            public void onCompleted()
            {
                setFinalReadTime();
                setFinished();
            }
        };

        client.queryScalar(requestBuilder.build(), responseObserver);
    }

    private void executeQuery(String query)
    {
        Presto.QueryRequest.Builder requestBuilder = Presto.QueryRequest.newBuilder()
                .setMaxBatchSize(PageBuilderStatus.DEFAULT_MAX_PAGE_SIZE_IN_BYTES)
                .setQuery(query);

        Presto.QueryRequest request = requestBuilder.build();

        StreamObserver<Presto.Page> responseObserver = new StreamObserver<Presto.Page>() {
            @Override
            public void onNext(Presto.Page summary)
            {
                addCompletedBatch(summary);
            }

            @Override
            public void onError(Throwable t)
            {
                //TODO
                setError(t);
            }

            @Override
            public void onCompleted()
            {
                setFinalReadTime();
                setFinished();
            }
        };

        client.query(request, responseObserver);
    }

    @Override
    public CompletableFuture<?> isBlocked()
    {
        if (!dynamicFilter.isComplete()) {
            return dynamicFilter.isBlocked();
        }
        return super.isBlocked();
    }

    @Override
    protected boolean readyForNextPage()
    {
        if (!dynamicFilter.isComplete()) {
            return false;
        }

        if (!querySent) {
            TupleDomain<KoraliumColumnHandle> dynamicConstraint = dynamicFilter.getCurrentPredicate().transform(KoraliumColumnHandle.class::cast);
            String filter = FilterExtractor.getFilter(session, constraint.intersect(dynamicConstraint));
            if (columns.size() == 0) {
                String query = new QueryBuilder().buildCountQuery(tableHandle.getTableName(), filter);

                executeCount(query);
            }
            else {
                String query = new QueryBuilder().buildQuery(
                        columns,
                        tableHandle.getTableName(),
                        filter,
                        tableHandle.getSortOrder(),
                        tableHandle.getLimit());

                executeQuery(query);
            }
            querySent = true;
        }

        return super.readyForNextPage();
    }
}
