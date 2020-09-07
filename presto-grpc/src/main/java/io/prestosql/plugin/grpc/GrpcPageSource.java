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
package io.prestosql.plugin.grpc;

import io.grpc.Metadata;
import io.grpc.stub.MetadataUtils;
import io.grpc.stub.StreamObserver;
import io.prestosql.plugin.grpc.client.FilterExtractor;
import io.prestosql.plugin.grpc.client.PrestoGrpcClient;
import io.prestosql.spi.block.PageBuilderStatus;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.predicate.TupleDomain;

import java.util.List;
import java.util.Optional;

public class GrpcPageSource
        extends GrpcBasePageSource
{
    private final QueryServiceGrpc.QueryServiceStub client;

    public GrpcPageSource(ConnectorSession session,
                          List<GrpcColumnHandle> columns,
                          PrestoGrpcClient prestoGrpcClient,
                          GrpcTableHandle tableHandle,
                          GrpcSplit split,
                          TupleDomain<GrpcColumnHandle> constraint)
    {
        super(session, columns);

        String authToken = session.getIdentity().getExtraCredentials().get("auth_token");
        String filter = FilterExtractor.getFilter(session, constraint);
        Metadata metadata = new Metadata();

        if (authToken != null) {
            metadata.put(Metadata.Key.of("Authorization", Metadata.ASCII_STRING_MARSHALLER), "Bearer " + authToken);
        }

        this.client = MetadataUtils.attachHeaders(QueryServiceGrpc.newStub(prestoGrpcClient.getChannel()), metadata);

        if (columns.size() == 0) {
            executeCount(tableHandle, filter);
        }
        else {
            executeQuery(tableHandle, columns, getExecutionColumns(), filter, tableHandle.getSortOrder());
        }
    }

    private void executeCount(GrpcTableHandle tableHandle, String filter)
    {
        Presto.CountRequest.Builder countRequestBuilder = Presto.CountRequest.newBuilder();
        countRequestBuilder.setTableId(tableHandle.getTableId());
        countRequestBuilder.setFilter(filter);

        StreamObserver<Presto.CountResponse> responseObserver = new StreamObserver<Presto.CountResponse>() {
            @Override
            public void onNext(Presto.CountResponse summary)
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

        client.getCount(countRequestBuilder.build(), responseObserver);
    }

    private void executeQuery(
            GrpcTableHandle tableHandle,
            List<GrpcColumnHandle> columns,
            List<GrpcExecutionColumn> executionColumns,
            String filter,
            Optional<List<GrpcSortItem>> sortOrder)
    {
        Presto.QueryRequest.Builder requestBuilder = Presto.QueryRequest.newBuilder()
                .setMaxBatchSize(PageBuilderStatus.DEFAULT_MAX_PAGE_SIZE_IN_BYTES)
                .setTableId(tableHandle.getTableId());

        Presto.ColumnSelect.Builder selectBuilder = Presto.ColumnSelect.newBuilder();
        addColumnsToSelect(executionColumns, selectBuilder);

        requestBuilder.setSelect(selectBuilder.build());
        requestBuilder.setFilter(filter);

        if (tableHandle.getLimit().isPresent()) {
            requestBuilder.setLimit((int) tableHandle.getLimit().getAsLong());
        }

        if (sortOrder.isPresent()) {
            for (GrpcSortItem sortItem : sortOrder.get()) {
                Presto.Sort.Builder sortBuilder = Presto.Sort.newBuilder();
                sortBuilder.setColumnId(sortItem.getColumnHandle().getColumnId());
                sortBuilder.setDescending(!sortItem.getSortOrder().isAscending());
                requestBuilder.addOrderby(sortBuilder.build());
            }
        }

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
}
