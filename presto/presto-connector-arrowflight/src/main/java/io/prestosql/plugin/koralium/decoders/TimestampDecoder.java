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
