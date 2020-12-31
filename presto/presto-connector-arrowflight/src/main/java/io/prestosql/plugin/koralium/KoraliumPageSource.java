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
import io.prestosql.plugin.koralium.cache.QueryCache;
import io.prestosql.plugin.koralium.cache.QueryCacheEntry;
import io.prestosql.plugin.koralium.client.KoraliumClient;
import io.prestosql.plugin.koralium.decoders.KoraliumDecoder;
import io.prestosql.plugin.koralium.utils.SchemaToDecoders;
import io.prestosql.spi.Page;
import io.prestosql.spi.block.Block;
import io.prestosql.spi.block.BlockBuilder;
import io.prestosql.spi.connector.ConnectorPageSource;
import io.prestosql.spi.connector.ConnectorSession;
import org.apache.arrow.flight.FlightStream;
import org.apache.arrow.vector.BigIntVector;
import org.apache.arrow.vector.VectorSchemaRoot;
import org.apache.arrow.vector.types.pojo.Schema;

import java.io.IOException;
import java.net.URI;
import java.util.Arrays;
import java.util.List;
import java.util.Map;
import java.util.concurrent.CompletableFuture;
import java.util.concurrent.ConcurrentLinkedQueue;
import java.util.concurrent.atomic.AtomicBoolean;
import java.util.concurrent.atomic.AtomicLong;

public class KoraliumPageSource
        implements ConnectorPageSource
{
    private final KoraliumSplit split;
    private final KoraliumClient client;
    private final List<KoraliumPrestoColumn> columns;
    private final KoraliumDecoder[] decoders;
    private final BlockBuilder[] columnBuilders;

    private final AtomicBoolean finished;
    private final ConcurrentLinkedQueue<Page> completedBatches = new ConcurrentLinkedQueue<>();
    private long completedBytes;
    private final AtomicLong readTimeNanos = new AtomicLong(0);
    private final long readStart;
    private Throwable error;
    private final QueryCache queryCache;
    private final QueryCacheEntry cacheEntry;

    public KoraliumPageSource(KoraliumSplit split,
                              List<KoraliumPrestoColumn> columns,
                              ConnectorSession session,
                              QueryCache queryCache,
                              String query)
    {
        this.split = split;
        this.columns = columns;
        finished = new AtomicBoolean();
        readStart = System.nanoTime();
        this.queryCache = queryCache;
        this.cacheEntry = queryCache.newEntry(query);

        columnBuilders = columns.stream()
                .map(KoraliumPrestoColumn::getType)
                .map(type -> type.createBlockBuilder(null, 1))
                .toArray(BlockBuilder[]::new);

        URI uri = split.getUriAddresses().get(0);
        this.client = new KoraliumClient(uri);

        String authToken = session.getIdentity().getExtraCredentials().get("auth_token");
        Map<String, String> headers = null;

        if (authToken != null) {
            headers = ImmutableMap.of("Authorization", "Bearer " + authToken);
        }

        FlightStream stream = client.GetStream(split.getTicket(), headers);
        Schema schema = stream.getSchema();

        //Create decoders using the schema
        decoders = SchemaToDecoders.createDecoders(session, schema, columns);

        if (split.isCount()) {
            readCount(stream);
        }
        else {
            readQuery(stream);
        }
    }

    private void readCount(FlightStream stream)
    {
        VectorSchemaRoot root = stream.getRoot();

        if (stream.next()) {
            BigIntVector vector = (BigIntVector) root.getVector(0);
            long val = vector.get(0);
            Page page = new Page((int) val);
            cacheEntry.addPage(page);
            queryCache.add(cacheEntry);
            completedBatches.add(page);
        }
        else {
            completedBatches.add(new Page(0));
        }
        try {
            root.close();
            client.close();
        }
        catch (Exception e) {
            e.printStackTrace();
        }

        finished.set(true);
        setFinalReadTime();
    }

    private void readQuery(FlightStream stream)
    {
        CompletableFuture.runAsync(() -> {
            try {
                VectorSchemaRoot root = stream.getRoot();
                while (stream.next()) {
                    if (!stream.hasRoot()) {
                        continue;
                    }

                    int rowCount = root.getRowCount();

                    for (int i = 0; i < columnBuilders.length; i++) {
                        decoders[i].decode(root.getVector(i), columnBuilders[i], 0, rowCount);
                    }

                    completedBytes += Arrays.stream(columnBuilders)
                            .mapToLong(BlockBuilder::getSizeInBytes)
                            .sum();

                    Block[] blocks = new Block[columnBuilders.length];
                    for (int i = 0; i < columnBuilders.length; i++) {
                        blocks[i] = columnBuilders[i].build();
                        columnBuilders[i] = columnBuilders[i].newBlockBuilderLike(null);
                    }
                    Page page = new Page(blocks);
                    this.cacheEntry.addPage(page);
                    completedBatches.add(page);
                }

                try {
                    stream.close(); //Close the stream
                }
                catch (Exception e) {
                    e.printStackTrace();
                }

                queryCache.add(cacheEntry);
                finished.set(true);
                setFinalReadTime();

                //Close root allocator
                root.close();
                //Close the stream
                stream.close();
                //close the client
                this.client.close();
            }
            catch (Exception e) {
                e.printStackTrace();
                this.error = e;
                finished.set(true);
                setFinalReadTime();
            }
        });
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
        return finished.get() && completedBatches.isEmpty();
    }

    @Override
    public Page getNextPage()
    {
        if (this.error != null) {
            throw new RuntimeException(error);
        }
        if (completedBatches.isEmpty()) {
            return null;
        }
        return completedBatches.poll();
    }

    @Override
    public long getSystemMemoryUsage()
    {
        return 0;
    }

    @Override
    public void close() throws IOException
    {
        //NOP
    }
}
