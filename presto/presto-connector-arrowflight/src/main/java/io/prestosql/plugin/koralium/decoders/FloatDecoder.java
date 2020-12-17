package io.prestosql.plugin.koralium.decoders;

import io.prestosql.spi.block.BlockBuilder;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.type.Type;
import org.apache.arrow.vector.Float4Vector;
import org.apache.arrow.vector.types.pojo.Field;

import static io.prestosql.spi.type.RealType.REAL;

public class FloatDecoder
        extends PrimitiveDecoder<Float4Vector>
{
    @Override
    protected PrimitiveDecoder<Float4Vector> createDecoder(Field field, ConnectorSession connectorSession, Type prestoType)
    {
        return new FloatDecoder();
    }

    @Override
    void writeValue(Float4Vector vector, BlockBuilder builder, int index)
    {
        REAL.writeLong(builder, Float.floatToRawIntBits(vector.get(index)));
    }
}
