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
package io.prestosql.plugin.koralium.encoders;

import io.prestosql.plugin.koralium.Presto;
import io.prestosql.spi.connector.RecordCursor;

public class FloatEncoder
        implements IEncoder
{
    private Presto.Block.Builder blockBuilder;
    private Presto.FloatBlock.Builder builder;

    public FloatEncoder()
    {
        //NO-OP
    }

    public FloatEncoder(Presto.Block.Builder blockBuilder, Presto.FloatBlock.Builder builder)
    {
        this.blockBuilder = blockBuilder;
        this.builder = builder;
    }

    @Override
    public IEncoder create(int columnId)
    {
        return new FloatEncoder(Presto.Block.newBuilder(), Presto.FloatBlock.newBuilder());
    }

    @Override
    public void encode(int rowIndex, RecordCursor cursor, int index)
    {
        if (cursor.isNull(index)) {
            blockBuilder.addNulls(rowIndex);
            return;
        }
        builder.addValues((float) cursor.getDouble(index));
    }

    @Override
    public void addBlock(Presto.Columns.Builder blockBatchBuilder, Presto.Page.Builder pageBuilder)
    {
        blockBatchBuilder.addBlocks(blockBuilder.setFloats(builder.build()).build());
    }

    @Override
    public String toFilter(Object object)
    {
        return object.toString();
    }
}
