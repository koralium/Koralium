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
package io.prestosql.plugin.koralium.decoders;

import io.trino.spi.block.BlockBuilder;
import io.trino.spi.connector.ConnectorSession;
import io.trino.spi.type.Type;
import org.apache.arrow.vector.FieldVector;
import org.apache.arrow.vector.types.pojo.Field;

public abstract class PrimitiveDecoder<T extends FieldVector>
        implements KoraliumDecoder
{
    private boolean isNullable;

    @Override
    public KoraliumDecoder create(Field field, ConnectorSession connectorSession, Type prestoType)
    {
        PrimitiveDecoder<T> decoder = createDecoder(field, connectorSession, prestoType);
        decoder.isNullable = field.isNullable();
        return decoder;
    }

    protected abstract PrimitiveDecoder<T> createDecoder(Field field, ConnectorSession connectorSession, Type prestoType);

    @Override
    public void decode(FieldVector vector, BlockBuilder builder, int start, int end)
    {
        T values = (T) vector;

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
    public void Clear()
    {
        //NOP
    }
}
