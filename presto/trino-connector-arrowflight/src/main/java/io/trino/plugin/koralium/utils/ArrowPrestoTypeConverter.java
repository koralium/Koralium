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
package io.trino.plugin.koralium.utils;

import com.google.common.collect.ImmutableList;
import io.trino.plugin.koralium.KoraliumType;
import io.trino.spi.type.ArrayType;
import io.trino.spi.type.RowType;
import org.apache.arrow.vector.types.pojo.ArrowType;
import org.apache.arrow.vector.types.pojo.Field;

import java.util.List;

public class ArrowPrestoTypeConverter
{
    private ArrowPrestoTypeConverter()
    {
        //NOP
    }

    private static PrestoArrowTypeVisitor visitor = new PrestoArrowTypeVisitor();

    public static TypeConvertResult Convert(Field field)
    {
        ArrowType type = field.getFieldType().getType();

        //Check if it is a complex type
        if (type.isComplex()) {
            switch (type.getTypeID()) {
                case List:
                    return ConvertList(field);
                case Struct:
                    return ConvertStruct(field);
                default:
                    throw new UnsupportedOperationException("Unsupported type" + type);
            }
        }
        else {
            return type.accept(visitor);
        }
    }

    private static TypeConvertResult ConvertStruct(Field field)
    {
        ImmutableList.Builder<RowType.Field> builder = ImmutableList.builder();
        for (Field child : field.getChildren()) {
            TypeConvertResult childType = Convert(child);
            builder.add(RowType.field(child.getName(), childType.getPrestoType()));
        }
        return new TypeConvertResult(RowType.from(builder.build()), KoraliumType.OBJECT);
    }

    private static TypeConvertResult ConvertList(Field field)
    {
        List<Field> children = field.getChildren();

        if (children.size() != 1) {
            throw new UnsupportedOperationException("Can not handle lists with more than 1 child");
        }

        Field child = children.get(0);
        TypeConvertResult childType = Convert(child);
        return new TypeConvertResult(new ArrayType(childType.getPrestoType()), KoraliumType.ARRAY);
    }
}
