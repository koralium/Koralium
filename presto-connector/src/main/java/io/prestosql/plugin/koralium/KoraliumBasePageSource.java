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
import io.prestosql.plugin.koralium.decoders.KoraliumDecoder;
import io.prestosql.plugin.koralium.utils.GrpcColumnReverter;
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

public class KoraliumBasePageSource
        implements ConnectorPageSource
{
    protected ConnectorSession session;
    private long completedBytes;
    private final AtomicLong readTimeNanos = new AtomicLong(0);
    private final long readStart;
    private final AtomicBoolean finished;
    private final ConcurrentLinkedQueue<Presto.Scalar> completedCount = new ConcurrentLinkedQueue<>();
    private final ConcurrentLinkedQueue<Presto.Page> completedBatches = new ConcurrentLinkedQueue<>();
    private final BlockBuilder[] columnBuilders;
    private List<KoraliumDecoder> decoders;
    private Throwable error;

    public KoraliumBasePageSource(
            ConnectorSession session,
            List<KoraliumColumnHandle> columns)
    {
        this.session = session;
        readStart = System.nanoTime();
        readTimeNanos.set(0);
        finished = new AtomicBoolean();

        columnBuilders = columns.stream()
                .map(KoraliumColumnHandle::getType)
                .map(type -> type.createBlockBuilder(null, 1))
                .toArray(BlockBuilder[]::new);
    }

    protected void addCompletedCount(Presto.Scalar countResponse)
    {
        completedCount.add(countResponse);
    }

    protected void addCompletedBatch(Presto.Page page)
    {
        completedBatches.add(page);
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

        //If the page contains column metadata
        //Use it to create the decoders
        if (page.getMetadataCount() > 0) {
            List<Presto.ColumnMetadata> columnMetadatas = page.getMetadataList();

            List<KoraliumExecutionColumn> executionColumns = GrpcColumnReverter.BuildExecutionColumns(columnMetadatas);

            ImmutableList.Builder<KoraliumDecoder> decodersBuilder = new ImmutableList.Builder<>();

            for (int i = 0; i < executionColumns.size(); i++) {
                KoraliumExecutionColumn column = executionColumns.get(i);

                decodersBuilder.add(column.getKoraliumType().getDecoder().create(column.getColumnId(), column, session));
            }
            decoders = decodersBuilder.build();
        }

        Presto.Columns batch = page.getColumns();
        //normal columns are always first
        int blockId = 0;
        for (; blockId < decoders.size(); blockId++) {
            //Reset the decoder before reading a new page
            decoders.get(blockId).newPage(page);
            decoders.get(blockId).decode(batch.getBlocks(blockId), columnBuilders[blockId], page);
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
        if (!readyForNextPage()) {
            return null;
        }
        if (!completedCount.isEmpty()) {
            Presto.Scalar countResponse = completedCount.poll();
            return new Page(countResponse.getInt());
        }
        if (!completedBatches.isEmpty()) {
            Presto.Page page = completedBatches.poll();
            return createPage(page);
        }
        return null;
    }

    protected boolean readyForNextPage()
    {
        return true;
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
