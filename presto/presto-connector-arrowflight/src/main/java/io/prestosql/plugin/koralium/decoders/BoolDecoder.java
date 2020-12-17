package io.prestosql.plugin.koralium.decoders;

import io.prestosql.spi.block.BlockBuilder;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.type.Type;
import org.apache.arrow.vector.BitVector;
import org.apache.arrow.vector.FieldVector;
import org.apache.arrow.vector.types.pojo.Field;

import static io.prestosql.spi.type.BooleanType.BOOLEAN;

public class BoolDecoder extends PrimitiveDecoder<BitVector>
{
    @Override
    protected PrimitiveDecoder<BitVector> createDecoder(Field field, ConnectorSession connectorSession, Type prestoType)
    {
        return new BoolDecoder();
    }

    @Override
    void writeValue(BitVector vector, BlockBuilder builder, int index)
    {
        BOOLEAN.writeBoolean(builder, vector.get(index) == 1);
    }
}
