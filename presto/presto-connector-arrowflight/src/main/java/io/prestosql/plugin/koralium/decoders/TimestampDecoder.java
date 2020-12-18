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
package io.prestosql.plugin.koralium.decoders;

import io.prestosql.spi.block.BlockBuilder;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.type.Timestamps;
import io.prestosql.spi.type.Type;
import org.apache.arrow.vector.TimeStampVector;
import org.apache.arrow.vector.types.pojo.Field;

import java.time.ZoneId;

import static io.prestosql.spi.type.TimestampType.TIMESTAMP_MILLIS;

public class TimestampDecoder
        extends PrimitiveDecoder<TimeStampVector>
{
    private static final ZoneId ZULU = ZoneId.of("Z");
    private final ZoneId zoneId;
    private final Type type;

    public TimestampDecoder()
    {
        zoneId = ZoneId.of("Z");
        this.type = TIMESTAMP_MILLIS;
    }

    public TimestampDecoder(ZoneId zoneId, Type type)
    {
        this.zoneId = zoneId;
        this.type = type;
    }

    @Override
    protected PrimitiveDecoder<TimeStampVector> createDecoder(Field field, ConnectorSession connectorSession, Type prestoType)
    {
        return new TimestampDecoder(ZoneId.of(connectorSession.getTimeZoneKey().getId()), prestoType);
    }

    @Override
    void writeValue(TimeStampVector vector, BlockBuilder builder, int index)
    {
        long val = vector.get(index) * Timestamps.MICROSECONDS_PER_MILLISECOND;
        type.writeLong(builder, val);
    }
}
