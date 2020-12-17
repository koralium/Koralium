package io.prestosql.plugin.koralium.decoders;

import io.prestosql.spi.block.BlockBuilder;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.type.Type;
import org.apache.arrow.vector.Float8Vector;
import org.apache.arrow.vector.types.pojo.Field;

import static io.prestosql.spi.type.DoubleType.DOUBLE;

public class DoubleDecoder
        extends PrimitiveDecoder<Float8Vector>
{
    @Override
    protected PrimitiveDecoder<Float8Vector> createDecoder(Field field, ConnectorSession connectorSession, Type prestoType)
    {
        return new DoubleDecoder();
    }

    @Override
    void writeValue(Float8Vector vector, BlockBuilder builder, int index)
    {
        DOUBLE.writeDouble(builder, vector.get(index));
    }
}
