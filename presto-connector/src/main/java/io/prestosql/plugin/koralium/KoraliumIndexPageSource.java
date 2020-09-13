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
import io.grpc.Metadata;
import io.grpc.stub.MetadataUtils;
import io.grpc.stub.StreamObserver;
import io.prestosql.plugin.koralium.client.PrestoGrpcClient;
import io.prestosql.plugin.koralium.encoders.IEncoder;
import io.prestosql.spi.block.PageBuilderStatus;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.connector.RecordCursor;
import io.prestosql.spi.connector.RecordSet;

import java.util.List;
import java.util.stream.Collectors;

public class GrpcIndexPageSource
        extends GrpcBasePageSource
{
    private final ConnectorSession session;

    private final KoraliumServiceGrpc.KoraliumServiceStub client;

    public GrpcIndexPageSource(
            ConnectorSession session,
            List<GrpcColumnHandle> lookupColumns,
            List<GrpcColumnHandle> outputColumns,
            PrestoGrpcClient prestoGrpcClient,
            GrpcIndexHandle indexHandle,
            RecordSet recordSet)
    {
        super(session, outputColumns);
        this.session = session;

        String authToken = session.getIdentity().getExtraCredentials().get("auth_token");
        Metadata metadata = new Metadata();

        if (authToken != null) {
            metadata.put(Metadata.Key.of("Authorization", Metadata.ASCII_STRING_MARSHALLER), "Bearer " + authToken);
        }

        this.client = MetadataUtils.attachHeaders(KoraliumServiceGrpc.newStub(prestoGrpcClient.getChannel()), metadata);

        List<String> fields = outputColumns.stream().map(x -> x.getColumnName()).collect(Collectors.toList());

        ImmutableList.Builder<IEncoder> encodersBuilder = new ImmutableList.Builder<>();

        for (int i = 0; i < lookupColumns.size(); i++) {
            GrpcColumnHandle column = lookupColumns.get(i);
            encodersBuilder.add(column.getGrpcType().getEncoder().create(column.getColumnId()));
        }

        ImmutableList<IEncoder> encoders = encodersBuilder.build();

        RecordCursor cursor = recordSet.cursor();

        int rowIndex = 0;
        while (cursor.advanceNextPosition()) {
            for (int i = 0; i < encoders.size(); i++) {
                encoders.get(i).encode(rowIndex, cursor, i);
            }
            rowIndex++;
        }

        Presto.Page.Builder pageBuilder = Presto.Page.newBuilder();
        pageBuilder.setRowCount(rowIndex);

        Presto.Columns.Builder blocksBuilder = Presto.Columns.newBuilder();

        for (int i = 0; i < encoders.size(); i++) {
            encoders.get(i).addBlock(blocksBuilder, pageBuilder);
        }

        Presto.Page recordsPage = pageBuilder.setColumns(blocksBuilder.build()).build();
        executeQuery(indexHandle, fields, recordsPage);
    }

    private void executeQuery(
            GrpcIndexHandle indexHandle,
            List<String> fields,
            Presto.Page recordsPage)
    {
        Presto.IndexRequest.Builder requestBuilder = Presto.IndexRequest.newBuilder()
                .setMaxBatchSize(PageBuilderStatus.DEFAULT_MAX_PAGE_SIZE_IN_BYTES)
                .setTableId(indexHandle.getTableId())
                .setIndexId(indexHandle.getIndexId())
                .setRecords(recordsPage);

        requestBuilder.addAllFields(fields);

        Presto.IndexRequest request = requestBuilder.build();

        StreamObserver<Presto.Page> responseObserver = new StreamObserver<Presto.Page>() {
            @Override
            public void onNext(Presto.Page summary)
            {
                addCompletedBatch(summary);
            }

            @Override
            public void onError(Throwable t)
            {
                setError(t);
                int error;
                //TODO
            }

            @Override
            public void onCompleted()
            {
                setFinalReadTime();
                setFinished();
            }
        };

        client.getIndex(request, responseObserver);
    }
}
