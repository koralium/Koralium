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
package io.trino.plugin.koralium.decoders;

import io.trino.spi.block.BlockBuilder;
import io.trino.spi.connector.ConnectorSession;
import io.trino.spi.type.Type;
import org.apache.arrow.vector.Float4Vector;
import org.apache.arrow.vector.types.pojo.Field;

import static io.trino.spi.type.RealType.REAL;

public class FloatDecoder
        extends PrimitiveDecoder<Float4Vector>
{
    @Override
    protected PrimitiveDecoder<Float4Vector> createDecoder(Field field, ConnectorSession connectorSession, Type prestoType)
    {
        return new FloatDecoder();
    }

    @Override
    void writeValue(Float4Vector vector, BlockBuilder builder, int index)
    {
        REAL.writeLong(builder, Float.floatToRawIntBits(vector.get(index)));
    }
}
