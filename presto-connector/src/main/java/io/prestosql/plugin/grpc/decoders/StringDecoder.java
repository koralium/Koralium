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
package io.prestosql.plugin.grpc.decoders;

import io.airlift.slice.Slice;
import io.airlift.slice.Slices;
import io.prestosql.plugin.grpc.GrpcExecutionColumn;
import io.prestosql.plugin.grpc.Presto;
import io.prestosql.spi.block.BlockBuilder;
import io.prestosql.spi.connector.ConnectorSession;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

import static io.prestosql.spi.type.VarcharType.VARCHAR;

public class StringDecoder
        implements GrpcDecoder
{
    private int columnId;
    private List<Slice> cache;

    private int count;
    private int globalCount;
    private int nullCounter;

    public StringDecoder()
    {
        this.columnId = 0;
        this.cache = null;
    }

    public StringDecoder(int columnId)
    {
        this.columnId = columnId;
        this.cache = new ArrayList<>();
    }

    @Override
    public GrpcDecoder create(int columnId, GrpcExecutionColumn column, ConnectorSession session)
    {
        return new StringDecoder(columnId);
    }

    private void buildCache(Presto.Page page)
    {
        List<Presto.StringColumn> a = page.getStringsList();

        Optional<Presto.StringColumn> optStringColumn = a.stream()
                .filter(s -> s.getColumnId() == columnId)
                .findFirst();

        if (!optStringColumn.isPresent()) {
            throw new RuntimeException("Missing string column");
        }

        Presto.StringColumn stringColumn = optStringColumn.get();

        //Check if we need to clear the previous cache
        if (stringColumn.getClearPrevious()) {
            this.cache.clear();
        }
        //Add all the new strings to the local cache
        this.cache.addAll(stringColumn.getStringsList()
                .stream()
                .map(Slices::utf8Slice)
                .collect(Collectors.toList()));
    }

    @Override
    public int decode(Presto.Block block, BlockBuilder builder, Presto.Page page)
    {
        List<Integer> nulls = block.getNullsList();
        List<Integer> stringRefs = block.getStrings().getStringIdList();

        while (nulls.size() > nullCounter || stringRefs.size() > count) {
            //Check null list if there are elements left
            if (nulls.size() > nullCounter) {
                if (nulls.get(nullCounter) == globalCount) {
                    builder.appendNull();
                    nullCounter++;
                    globalCount++;
                    continue;
                }
            }
            if (stringRefs.size() > count) {
                int ref = stringRefs.get(count);
                VARCHAR.writeSlice(builder, cache.get(ref));
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
        List<Integer> stringRefs = block.getStrings().getStringIdList();

        int localCount = 0;
        while ((nulls.size() > nullCounter || stringRefs.size() > count) && numberOfElements > localCount) {
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
            if (stringRefs.size() > count) {
                int ref = stringRefs.get(count);
                VARCHAR.writeSlice(builder, cache.get(ref));
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
        buildCache(page);
        this.count = 0;
        this.globalCount = 0;
        this.nullCounter = 0;
    }
}
