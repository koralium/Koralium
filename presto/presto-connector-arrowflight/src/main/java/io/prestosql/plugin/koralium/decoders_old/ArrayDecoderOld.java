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

import io.prestosql.plugin.koralium.KoraliumExecutionColumn;
import io.prestosql.plugin.koralium.Presto;
import io.prestosql.spi.block.BlockBuilder;
import io.prestosql.spi.connector.ConnectorSession;

import java.util.List;

public class ArrayDecoderOld
        implements KoraliumDecoderOld
{
    private KoraliumDecoderOld decoder;
    private int count;
    private int globalCount;
    private int nullCounter;

    public ArrayDecoderOld() {}

    public ArrayDecoderOld(int columnId, KoraliumExecutionColumn column, ConnectorSession session)
    {
        KoraliumExecutionColumn child = column.getChildren().get(0);
        decoder = child.getKoraliumTypeOld().getDecoder().create(child.getColumnId(), child, session);
    }

    @Override
    public KoraliumDecoderOld create(int columnId, KoraliumExecutionColumn column, ConnectorSession session)
    {
        return new ArrayDecoderOld(columnId, column, session);
    }

    @Override
    public int decode(Presto.Block block, BlockBuilder builder, Presto.Page page)
    {
        List<Integer> sizeList = block.getArrays().getSizeList();
        Presto.Block values = block.getArrays().getValues();
        List<Integer> nulls = block.getNullsList();

        while (nulls.size() > nullCounter || sizeList.size() > count) {
            //Check null list if there are elements left
            if (nulls.size() > nullCounter) {
                if (nulls.get(nullCounter) == globalCount) {
                    builder.appendNull();
                    nullCounter++;
                    globalCount++;
                    continue;
                }
            }
            if (sizeList.size() > count) {
                BlockBuilder array = builder.beginBlockEntry();
                decoder.decode(values, array, page, sizeList.get(count));
                builder.closeEntry();
                count++;
                globalCount++;
            }
        }

        return 0;
    }

    @Override
    public int decode(Presto.Block block, BlockBuilder builder, Presto.Page page, int numberOfElements)
    {
        List<Integer> sizeList = block.getArrays().getSizeList();
        Presto.Block values = block.getArrays().getValues();
        List<Integer> nulls = block.getNullsList();

        int localCount = 0;
        while ((nulls.size() > nullCounter || sizeList.size() > count) && numberOfElements > localCount) {
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
            if (sizeList.size() > count) {
                BlockBuilder array = builder.beginBlockEntry();
                decoder.decode(values, array, page, sizeList.get(count));
                builder.closeEntry();
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
        this.decoder.newPage(page);
        this.count = 0;
        this.globalCount = 0;
        this.nullCounter = 0;
    }
}
