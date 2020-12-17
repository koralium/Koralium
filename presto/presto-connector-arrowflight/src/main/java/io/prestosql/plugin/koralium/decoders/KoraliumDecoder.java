package io.prestosql.plugin.koralium.decoders;

import io.prestosql.plugin.koralium.Presto;
import io.prestosql.spi.block.BlockBuilder;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.type.Type;
import org.apache.arrow.vector.FieldVector;
import org.apache.arrow.vector.types.pojo.Field;

public interface KoraliumDecoder
{
    KoraliumDecoder create(Field field, ConnectorSession connectorSession, Type prestoType);

    //int decode(int rowCount, FieldVector vector, BlockBuilder builder);

    //int decode(int rowCount, FieldVector vector, BlockBuilder builder, int numberOfElements);

    void decode(FieldVector vector, BlockBuilder builder, int start, int c);

    void Clear();
}
