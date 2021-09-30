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

import io.airlift.slice.Slice;
import io.trino.spi.block.BlockBuilder;
import io.trino.spi.connector.ConnectorSession;
import io.trino.spi.type.DecimalType;
import io.trino.spi.type.Type;
import org.apache.arrow.vector.DecimalVector;
import org.apache.arrow.vector.types.pojo.Field;

import java.math.BigDecimal;

import static io.trino.spi.type.Decimals.encodeScaledValue;

public class Decimal128Decoder
        extends PrimitiveDecoder<DecimalVector>
{
    private DecimalType type;

    public Decimal128Decoder()
    {
    }

    public Decimal128Decoder(DecimalType type)
    {
        this.type = type;
    }

    @Override
    protected PrimitiveDecoder<DecimalVector> createDecoder(Field field, ConnectorSession connectorSession, Type prestoType)
    {
        return new Decimal128Decoder((DecimalType) prestoType);
    }

    @Override
    void writeValue(DecimalVector vector, BlockBuilder builder, int index)
    {
        BigDecimal value = vector.getObject(index);
        Slice v = encodeScaledValue(value, type.getScale());
        type.writeSlice(builder, v);
    }
}
