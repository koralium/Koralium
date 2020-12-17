package io.prestosql.plugin.koralium.decoders;

import io.prestosql.spi.block.BlockBuilder;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.type.Type;
import org.apache.arrow.vector.BigIntVector;
import org.apache.arrow.vector.types.pojo.Field;

import static io.prestosql.spi.type.BigintType.BIGINT;

public class Int64Decoder
        extends PrimitiveDecoder<BigIntVector>
{

    @Override
    protected PrimitiveDecoder<BigIntVector> createDecoder(Field field, ConnectorSession connectorSession, Type prestoType)
    {
        return new Int64Decoder();
    }

    @Override
    void writeValue(BigIntVector vector, BlockBuilder builder, int index)
    {
        BIGINT.writeLong(builder, vector.get(index));
    }
}
