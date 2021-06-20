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

import io.airlift.slice.Slice;
import io.airlift.slice.Slices;
import io.trino.spi.block.BlockBuilder;
import io.trino.spi.connector.ConnectorSession;
import io.trino.spi.type.Type;
import org.apache.arrow.vector.VarCharVector;
import org.apache.arrow.vector.types.pojo.Field;

import java.nio.charset.StandardCharsets;

import static io.trino.spi.type.VarcharType.VARCHAR;

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
