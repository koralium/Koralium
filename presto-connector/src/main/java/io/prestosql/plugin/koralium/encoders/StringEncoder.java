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
package io.prestosql.plugin.grpc.encoders;

import io.airlift.slice.Slice;
import io.prestosql.plugin.grpc.Presto;
import io.prestosql.spi.connector.RecordCursor;

import java.util.HashMap;
import java.util.Map;

public class StringEncoder
        implements IEncoder
{
    private Presto.Block.Builder blockBuilder;
    private Presto.StringRefBlock.Builder builder;
    private final int columnId;
    private Map<String, Integer> lookup;
    private Presto.StringColumn.Builder stringColumnBuilder;
    private int counter;

    public StringEncoder()
    {
        columnId = -1;
    }

    public StringEncoder(Presto.Block.Builder blockBuilder, Presto.StringRefBlock.Builder builder, int columnId)
    {
        this.blockBuilder = blockBuilder;
        this.builder = builder;
        this.columnId = columnId;
        lookup = new HashMap<>();
        stringColumnBuilder = Presto.StringColumn.newBuilder()
            .setColumnId(this.columnId);
        counter = 0;
    }

    @Override
    public IEncoder create(int columnId)
    {
        return new StringEncoder(Presto.Block.newBuilder(), Presto.StringRefBlock.newBuilder(), columnId);
    }

    @Override
    public void encode(int rowIndex, RecordCursor cursor, int index)
    {
        if (cursor.isNull(index)) {
            blockBuilder.addNulls(rowIndex);
            return;
        }
        String str = cursor.getSlice(index).toStringUtf8();

        int stringIndex = 0;
        if (!lookup.containsKey(str)) {
            stringIndex = counter++;
            lookup.put(str, stringIndex);
            stringColumnBuilder.addStrings(str);
        }
        else {
            stringIndex = lookup.get(str);
        }

        builder.addStringId(stringIndex);
    }

    @Override
    public void addBlock(Presto.Columns.Builder blockBatchBuilder, Presto.Page.Builder pageBuilder)
    {
        blockBatchBuilder.addBlocks(blockBuilder.setStrings(builder.build()).build());
        pageBuilder.addStrings(stringColumnBuilder.build());
    }

    @Override
    public String toFilter(Object object)
    {
        if (object instanceof String) {
            return (String) object;
        }
        else if (object instanceof Slice) {
            return "'" + ((Slice) object).toStringUtf8() + "'";
        }

        return object.toString();
    }
}
