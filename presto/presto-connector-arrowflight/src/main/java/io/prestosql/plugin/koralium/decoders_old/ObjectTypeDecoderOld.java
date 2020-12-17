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
package io.prestosql.plugin.koralium.decoders_old;

import com.google.common.collect.ImmutableList;
import io.prestosql.plugin.koralium.KoraliumExecutionColumn;
import io.prestosql.plugin.koralium.Presto;
import io.prestosql.spi.block.BlockBuilder;
import io.prestosql.spi.connector.ConnectorSession;

import java.util.List;
import java.util.Optional;

public class ObjectTypeDecoderOld
        implements KoraliumDecoderOld
{
    private final List<KoraliumDecoderOld> decoders;
    private BlockBuilder blockBuilder;
    private int columnId;

    private int count;
    private int globalCount;
    private int nullCounter;

    public ObjectTypeDecoderOld()
    {
        decoders = null;
    }

    public ObjectTypeDecoderOld(int columnId, KoraliumExecutionColumn column, ConnectorSession session)
    {
        this.columnId = columnId;

        List<KoraliumExecutionColumn> children = column.getChildren();

        ImmutableList.Builder<Integer> decoderToColumnIdBuilder = new ImmutableList.Builder<>();
        ImmutableList.Builder<KoraliumDecoderOld> decodersBuilder = new ImmutableList.Builder<>();

        for (int i = 0; i < children.size(); i++) {
            KoraliumExecutionColumn child = children.get(i);

            decoderToColumnIdBuilder.add(child.getReturnId());
            decodersBuilder.add(child.getKoraliumTypeOld().getDecoder().create(child.getColumnId(), child, session));
        }
        decoders = decodersBuilder.build();
        blockBuilder = column.getPrestoType().createBlockBuilder(null, 1);
    }

    @Override
    public KoraliumDecoderOld create(int columnId, KoraliumExecutionColumn column, ConnectorSession session)
    {
        return new ObjectTypeDecoderOld(columnId, column, session);
    }

    private void buildCache(Presto.Page page)
    {
        List<Presto.ObjectColumn> a = page.getObjectsList();

        Optional<Presto.ObjectColumn> optObjectColumn = a.stream()
                .filter(s -> s.getColumnId() == columnId)
                .findFirst();

        if (!optObjectColumn.isPresent()) {
            throw new RuntimeException("Missing object column");
        }

        Presto.ObjectColumn objectColumn = optObjectColumn.get();

        //Check if previous data needs to be cleared
        if (objectColumn.getClearPrevious()) {
            //Create a new block builder that starts from scratch
            blockBuilder = blockBuilder.newBlockBuilderLike(null);
        }

        Presto.Columns objects = objectColumn.getObjects();

        List<Presto.Block> blockList = objects.getBlocksList();

        int objectCount = objectColumn.getCount();
        for (int i = 0; i < objectCount; i++) {
            BlockBuilder builder = blockBuilder.beginBlockEntry();

            for (int blockId = 0; blockId < decoders.size(); blockId++) {
                //take out the data
                decoders.get(blockId).decode(blockList.get(blockId), builder, page, 1);
            }
            blockBuilder.closeEntry();
        }
    }

    @Override
    public int decode(Presto.Block block, BlockBuilder builder, Presto.Page page)
    {
        List<Integer> nulls = block.getNullsList();
        List<Integer> objectRefs = block.getObjects().getValuesList();

        while (nulls.size() > nullCounter || objectRefs.size() > count) {
            //Check null list if there are elements left
            if (nulls.size() > nullCounter) {
                if (nulls.get(nullCounter) == globalCount) {
                    builder.appendNull();
                    nullCounter++;
                    globalCount++;
                    continue;
                }
            }
            if (objectRefs.size() > count) {
                int ref = objectRefs.get(count);

                blockBuilder.writePositionTo(ref, builder);
                count++;
                globalCount++;
            }
        }
        return globalCount;
    }

    @Override
    public int decode(Presto.Block block, BlockBuilder builder, Presto.Page page, int numberOfElements)
    {
        List<Integer> nulls = block.getNullsList();
        List<Integer> objectRefs = block.getObjects().getValuesList();

        int localCount = 0;
        while ((nulls.size() > nullCounter || objectRefs.size() > count) && numberOfElements > localCount) {
            //Check null list if there are elements left
            if (nulls.size() > nullCounter) {
                if (nulls.get(nullCounter) == globalCount) {
                    builder.appendNull();
                    nullCounter++;
                    globalCount++;
                    localCount++;
                    continue;
                }
            }
            if (objectRefs.size() > count) {
                int ref = objectRefs.get(count);

                blockBuilder.writePositionTo(ref, builder);
                count++;
                globalCount++;
                localCount++;
            }
        }
        return 0;
    }

    @Override
    public void newPage(Presto.Page page)
    {
        //Mark all the decoders that there is a new page
        for (int blockId = 0; blockId < decoders.size(); blockId++) {
            decoders.get(blockId).newPage(page);
        }
        buildCache(page);
        this.count = 0;
        this.globalCount = 0;
        this.nullCounter = 0;
    }
}
