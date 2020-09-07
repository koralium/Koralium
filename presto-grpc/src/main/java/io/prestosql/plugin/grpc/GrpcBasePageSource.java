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

import com.google.common.collect.ImmutableList;
import io.prestosql.plugin.grpc.decoders.GrpcDecoder;
import io.prestosql.plugin.grpc.utils.GrpcColumnReverter;
import io.prestosql.spi.Page;
import io.prestosql.spi.block.Block;
import io.prestosql.spi.block.BlockBuilder;
import io.prestosql.spi.connector.ConnectorPageSource;
import io.prestosql.spi.connector.ConnectorSession;

import java.io.IOException;
import java.util.Arrays;
import java.util.List;
import java.util.concurrent.ConcurrentLinkedQueue;
import java.util.concurrent.atomic.AtomicBoolean;
import java.util.concurrent.atomic.AtomicLong;

public class GrpcBasePageSource
        implements ConnectorPageSource
{
    private long completedBytes;
    private final AtomicLong readTimeNanos = new AtomicLong(0);
    private final long readStart;
    private final AtomicBoolean finished;
    private final ConcurrentLinkedQueue<Presto.Page> completedBatches = new ConcurrentLinkedQueue<>();
    private final ConcurrentLinkedQueue<Presto.CountResponse> completedCount = new ConcurrentLinkedQueue<>();
    private final BlockBuilder[] columnBuilders;
    private final List<GrpcDecoder> decoders;
    private final List<Integer> decoderToColumnId;
    private final List<GrpcExecutionColumn> executionColumns;
    private Throwable error;

    public GrpcBasePageSource(
            ConnectorSession session,
            List<GrpcColumnHandle> columns)
    {
        readStart = System.nanoTime();
        readTimeNanos.set(0);
        finished = new AtomicBoolean();

        columnBuilders = columns.stream()
                .map(GrpcColumnHandle::getType)
                .map(type -> type.createBlockBuilder(null, 1))
                .toArray(BlockBuilder[]::new);

        executionColumns = GrpcColumnReverter.buildColumnsTree(columns);

        ImmutableList.Builder<Integer> decoderToColumnIdBuilder = new ImmutableList.Builder<>();
        ImmutableList.Builder<GrpcDecoder> decodersBuilder = new ImmutableList.Builder<>();

        for (int i = 0; i < executionColumns.size(); i++) {
            GrpcExecutionColumn column = executionColumns.get(i);

            decoderToColumnIdBuilder.add(column.getReturnId());
            decodersBuilder.add(column.getGrpcType().getDecoder().create(column.getColumnId(), column, session));
        }

        decoders = decodersBuilder.build();
        decoderToColumnId = decoderToColumnIdBuilder.build();
    }

    protected List<GrpcExecutionColumn> getExecutionColumns()
    {
        return executionColumns;
    }

    protected void addColumnsToSelect(List<GrpcExecutionColumn> columns, Presto.ColumnSelect.Builder selectBuilder)
    {
        for (int i = 0; i < columns.size(); i++) {
            GrpcExecutionColumn column = columns.get(i);
            if (column.isObject()) {
                Presto.ObjectColumnSelect.Builder objectColumnSelectBuilder = Presto.ObjectColumnSelect.newBuilder();

                objectColumnSelectBuilder.setColumnId(column.getColumnId());
                Presto.ColumnSelect.Builder childSelectBuilder = Presto.ColumnSelect.newBuilder();

                addColumnsToSelect(column.getChildren(), childSelectBuilder);

                objectColumnSelectBuilder.setSelects(childSelectBuilder.build());

                selectBuilder.addObjects(objectColumnSelectBuilder.build());
            }
            else if (column.isArray()) {
                Presto.ArrayColumnSelect.Builder arrayColumnSelectBuilder = Presto.ArrayColumnSelect.newBuilder();

                arrayColumnSelectBuilder.setColumnId(column.getColumnId());
                Presto.ColumnSelect.Builder childSelectBuilder = Presto.ColumnSelect.newBuilder();

                addColumnsToSelect(column.getChildren(), childSelectBuilder);
                arrayColumnSelectBuilder.setSelects(childSelectBuilder.build());

                selectBuilder.addArrays(arrayColumnSelectBuilder.build());
            }
            else {
                selectBuilder.addSelectColumns(column.getColumnId());
            }
        }
    }

    protected void addCompletedBatch(Presto.Page page)
    {
        completedBatches.add(page);
    }

    protected void addCompletedCount(Presto.CountResponse countResponse)
    {
        completedCount.add(countResponse);
    }

    protected void setError(Throwable error)
    {
        this.error = error;
    }

    protected void setFinished()
    {
        this.finished.set(true);
    }

    protected void setFinalReadTime()
    {
        readTimeNanos.set(System.nanoTime() - readStart);
    }

    @Override
    public long getCompletedBytes()
    {
        return completedBytes;
    }

    @Override
    public long getReadTimeNanos()
    {
        return readTimeNanos.get();
    }

    @Override
    public boolean isFinished()
    {
        return finished.get() && completedBatches.isEmpty() && completedCount.isEmpty();
    }

    private Page createPage(Presto.Page page)
    {
        if (columnBuilders.length == 0) {
            return null;
        }
        Presto.Columns batch = page.getColumns();
        //normal columns are always first
        int blockId = 0;
        for (; blockId < decoders.size(); blockId++) {
            //Reset the decoder before reading a new page
            decoders.get(blockId).newPage(page);
            decoders.get(blockId).decode(batch.getBlocks(blockId), columnBuilders[decoderToColumnId.get(blockId)], page);
        }

        completedBytes += Arrays.stream(columnBuilders)
                .mapToLong(BlockBuilder::getSizeInBytes)
                .sum();

        Block[] blocks = new Block[columnBuilders.length];
        for (int i = 0; i < columnBuilders.length; i++) {
            blocks[i] = columnBuilders[i].build();
            columnBuilders[i] = columnBuilders[i].newBlockBuilderLike(null);
        }

        return new Page(blocks);
    }

    @Override
    public Page getNextPage()
    {
        if (error != null) {
            throw new RuntimeException(error);
        }
        if (!completedCount.isEmpty()) {
            Presto.CountResponse countResponse = completedCount.poll();
            return new Page((int) countResponse.getCount());
        }
        if (!completedBatches.isEmpty()) {
            Presto.Page page = completedBatches.poll();
            return createPage(page);
        }
        return null;
    }

    @Override
    public long getSystemMemoryUsage()
    {
        return 0;
    }

    @Override
    public void close() throws IOException
    {
        //TODO
    }
}
