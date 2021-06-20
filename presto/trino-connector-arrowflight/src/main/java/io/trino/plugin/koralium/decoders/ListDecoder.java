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

import io.prestosql.plugin.koralium.utils.ArrowPrestoTypeConverter;
import io.prestosql.plugin.koralium.utils.TypeConvertResult;
import io.trino.spi.block.BlockBuilder;
import io.trino.spi.connector.ConnectorSession;
import io.trino.spi.type.Type;
import org.apache.arrow.vector.FieldVector;
import org.apache.arrow.vector.complex.ListVector;
import org.apache.arrow.vector.types.pojo.Field;

import java.util.List;

public class ListDecoder
        implements KoraliumDecoder
{
    private final KoraliumDecoder decoder;

    public ListDecoder()
    {
        decoder = null;
    }

    public ListDecoder(KoraliumDecoder decoder)
    {
        this.decoder = decoder;
    }

    @Override
    public KoraliumDecoder create(Field field, ConnectorSession connectorSession, Type prestoType)
    {
        List<Field> children = field.getChildren();

        if (children.size() != 1) {
            throw new UnsupportedOperationException("List cannot have anything else than 1 child");
        }
        Field child = children.get(0);
        TypeConvertResult convertResult = ArrowPrestoTypeConverter.Convert(child);
        KoraliumDecoder decoder = convertResult.getKoraliumType().getDecoder().create(child, connectorSession, convertResult.getPrestoType());

        return new ListDecoder(decoder);
    }

    @Override
    public void decode(FieldVector vector, BlockBuilder builder, int start, int end)
    {
        ListVector values = (ListVector) vector;
        List<FieldVector> childVectors = values.getChildrenFromFields();

        if (childVectors.size() != 1) {
            throw new UnsupportedOperationException("List can only have 1 child");
        }

        FieldVector childVector = childVectors.get(0);
        for (int i = start; i < end; i++) {
            int startIndex = values.getElementStartIndex(i);
            int endIndex = values.getElementEndIndex(i);

            BlockBuilder array = builder.beginBlockEntry();
            decoder.decode(childVector, array, startIndex, endIndex);
            builder.closeEntry();
        }
    }

    @Override
    public void Clear()
    {
        //NOP
    }
}
