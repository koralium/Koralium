package io.prestosql.plugin.koralium.utils;

import io.prestosql.plugin.koralium.KoraliumPrestoColumn;
import io.prestosql.plugin.koralium.decoders.KoraliumDecoder;
import io.prestosql.spi.connector.ConnectorSession;
import org.apache.arrow.vector.types.pojo.Field;
import org.apache.arrow.vector.types.pojo.Schema;

import java.util.List;

public class SchemaToDecoders
{
    private SchemaToDecoders()
    {
        //NOP
    }

    public static KoraliumDecoder[] createDecoders(ConnectorSession session, Schema schema, List<KoraliumPrestoColumn> columns)
    {
        KoraliumDecoder[] decoders = new KoraliumDecoder[columns.size()];
        List<Field> fields = schema.getFields();
        for (int i = 0; i < columns.size(); i++) {
            KoraliumPrestoColumn column = columns.get(i);
            decoders[i] = column.getKoraliumType().getDecoder().create(fields.get(i), session, column.getType());
        }
        return decoders;
    }
}
