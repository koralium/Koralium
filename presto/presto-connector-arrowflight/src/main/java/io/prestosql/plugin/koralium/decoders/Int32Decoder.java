package io.prestosql.plugin.koralium.decoders;

import io.prestosql.spi.block.BlockBuilder;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.type.Type;
import org.apache.arrow.vector.IntVector;
import org.apache.arrow.vector.types.pojo.Field;

import static io.prestosql.spi.type.IntegerType.INTEGER;

public class Int32Decoder
        extends PrimitiveDecoder<IntVector>
{
    @Override
    protected PrimitiveDecoder<IntVector> createDecoder(Field field, ConnectorSession connectorSession, Type prestoType)
    {
        return new Int32Decoder();
    }

    @Override
    void writeValue(IntVector vector, BlockBuilder builder, int index)
    {
        INTEGER.writeLong(builder, vector.get(index));
    }
}
