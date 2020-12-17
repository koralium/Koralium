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

import com.google.protobuf.Timestamp;
import io.prestosql.plugin.koralium.Presto;
import io.prestosql.spi.connector.RecordCursor;

import java.time.Instant;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class TimestampEncoder
        implements IEncoder
{
    private Presto.Block.Builder blockBuilder;
    private Presto.TimestampBlock.Builder builder;

    public TimestampEncoder()
    {
        //NO-OP
    }

    public TimestampEncoder(Presto.Block.Builder blockBuilder, Presto.TimestampBlock.Builder builder)
    {
        this.blockBuilder = blockBuilder;
        this.builder = builder;
    }

    @Override
    public IEncoder create(int columnId)
    {
        return new TimestampEncoder(Presto.Block.newBuilder(), Presto.TimestampBlock.newBuilder());
    }

    @Override
    public void encode(int rowIndex, RecordCursor cursor, int index)
    {
        if (cursor.isNull(index)) {
            blockBuilder.addNulls(rowIndex);
            return;
        }

        long val = cursor.getLong(index);

        Instant instant = Instant.ofEpochMilli(val);
        Timestamp timestamp = Timestamp.newBuilder().setSeconds(instant.getEpochSecond())
                .setNanos(instant.getNano()).build();

        builder.addValues(timestamp);
    }

    @Override
    public void addBlock(Presto.Columns.Builder blockBatchBuilder, Presto.Page.Builder pageBuilder)
    {
        blockBatchBuilder.addBlocks(blockBuilder.setTimestamps(builder.build()).build());
    }

    @Override
    public String toFilter(Object object)
    {
        if (object instanceof Long) {
            DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd'T'HH:mm:ss'Z'");
            java.sql.Timestamp timestamp = new java.sql.Timestamp((long) object);
            LocalDateTime localDateTime = timestamp.toLocalDateTime();

            return localDateTime.format(formatter);
        }
        return object.toString();
    }
}
