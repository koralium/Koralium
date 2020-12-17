package io.prestosql.plugin.koralium.decoders;

import io.airlift.slice.Slice;
import io.airlift.slice.Slices;
import io.prestosql.spi.block.BlockBuilder;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.type.Type;
import org.apache.arrow.vector.VarCharVector;
import org.apache.arrow.vector.types.pojo.Field;

import java.nio.charset.StandardCharsets;

import static io.prestosql.spi.type.VarcharType.VARCHAR;

public class StringDecoder
        extends PrimitiveDecoder<VarCharVector>
{
    @Override
    protected PrimitiveDecoder<VarCharVector> createDecoder(Field field, ConnectorSession connectorSession, Type prestoType)
    {
        return new StringDecoder();
    }

    @Override
    void writeValue(VarCharVector vector, BlockBuilder builder, int index)
    {
        Slice slice = Slices.utf8Slice(new String(vector.get(index), StandardCharsets.UTF_8));
        VARCHAR.writeSlice(builder, slice);
    }
}
