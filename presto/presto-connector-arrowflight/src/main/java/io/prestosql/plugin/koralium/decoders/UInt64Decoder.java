package io.prestosql.plugin.koralium.decoders;

import io.prestosql.spi.block.BlockBuilder;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.type.Type;
import org.apache.arrow.vector.UInt4Vector;
import org.apache.arrow.vector.UInt8Vector;
import org.apache.arrow.vector.types.pojo.Field;

import static io.prestosql.spi.type.BigintType.BIGINT;

public class UInt64Decoder
        extends PrimitiveDecoder<UInt8Vector>
{
    @Override
    protected PrimitiveDecoder<UInt8Vector> createDecoder(Field field, ConnectorSession connectorSession, Type prestoType)
    {
        return new UInt64Decoder();
    }

    @Override
    void writeValue(UInt8Vector vector, BlockBuilder builder, int index)
    {
        BIGINT.writeLong(builder, vector.get(index));
    }
}