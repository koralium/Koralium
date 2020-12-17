package io.prestosql.plugin.koralium.decoders;

import io.prestosql.spi.block.BlockBuilder;
import io.prestosql.spi.connector.ConnectorSession;
import org.apache.arrow.vector.FieldVector;
import org.apache.arrow.vector.types.pojo.Field;

import static io.prestosql.spi.type.RealType.REAL;

public abstract class PrimitiveEncoder<T extends FieldVector>
        implements KoraliumDecoder
{
    private boolean isNullable;

    @Override
    public KoraliumDecoder create(Field field, ConnectorSession connectorSession) {
        isNullable = field.isNullable();
        return createDecoder(field, connectorSession);
    }

    protected abstract KoraliumDecoder createDecoder(Field field, ConnectorSession connectorSession);

    @Override
    public void decode(FieldVector vector, BlockBuilder builder, int start, int end) {
        T values = (T)vector;

        if (isNullable) {
            for (int i = start; i < end; i++) {
                if (values.isNull(i)) {
                    builder.appendNull();
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
