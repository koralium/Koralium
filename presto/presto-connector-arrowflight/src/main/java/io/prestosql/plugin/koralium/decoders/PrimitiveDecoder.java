package io.prestosql.plugin.koralium.decoders;

import io.prestosql.spi.block.BlockBuilder;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.type.Type;
import org.apache.arrow.vector.FieldVector;
import org.apache.arrow.vector.types.pojo.Field;

public abstract class PrimitiveDecoder<T extends FieldVector>
        implements KoraliumDecoder
{
    private boolean isNullable;

    @Override
    public KoraliumDecoder create(Field field, ConnectorSession connectorSession, Type prestoType) {
        PrimitiveDecoder<T> decoder = createDecoder(field, connectorSession, prestoType);
        decoder.isNullable = field.isNullable();
        return decoder;
    }

    protected abstract PrimitiveDecoder<T> createDecoder(Field field, ConnectorSession connectorSession, Type prestoType);

    @Override
    public void decode(FieldVector vector, BlockBuilder builder, int start, int end) {
        T values = (T)vector;

        if (isNullable) {
            for (int i = start; i < end; i++) {
                if (values.isNull(i)) {
                    builder.appendNull();
                    continue;
                }
                writeValue(values, builder, i);
            }
        }
        else {
            for (int i = start; i < end; i++) {
                writeValue(values, builder, i);
            }
        }
    }

    abstract void writeValue(T vector, BlockBuilder builder, int index);

    @Override
    public void Clear() {

    }
}
