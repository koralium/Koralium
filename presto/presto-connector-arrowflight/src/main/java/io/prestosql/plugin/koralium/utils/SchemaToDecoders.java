/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
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
