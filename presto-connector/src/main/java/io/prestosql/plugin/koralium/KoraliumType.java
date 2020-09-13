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
package io.prestosql.plugin.koralium;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.google.common.collect.ImmutableList;
import io.prestosql.plugin.koralium.decoders.ArrayDecoder;
import io.prestosql.plugin.koralium.decoders.BoolDecoder;
import io.prestosql.plugin.koralium.decoders.DoubleDecoder;
import io.prestosql.plugin.koralium.decoders.FloatDecoder;
import io.prestosql.plugin.koralium.decoders.Int64Decoder;
import io.prestosql.plugin.koralium.decoders.IntDecoder;
import io.prestosql.plugin.koralium.decoders.KoraliumDecoder;
import io.prestosql.plugin.koralium.decoders.ObjectTypeDecoder;
import io.prestosql.plugin.koralium.decoders.StringDecoder;
import io.prestosql.plugin.koralium.decoders.TimestampDecoder;
import io.prestosql.plugin.koralium.encoders.BoolEncoder;
import io.prestosql.plugin.koralium.encoders.DoubleEncoder;
import io.prestosql.plugin.koralium.encoders.FloatEncoder;
import io.prestosql.plugin.koralium.encoders.IEncoder;
import io.prestosql.plugin.koralium.encoders.Int64Encoder;
import io.prestosql.plugin.koralium.encoders.IntEncoder;
import io.prestosql.plugin.koralium.encoders.StringEncoder;
import io.prestosql.plugin.koralium.encoders.TimestampEncoder;
import io.prestosql.spi.type.ArrayType;
import io.prestosql.spi.type.BigintType;
import io.prestosql.spi.type.BooleanType;
import io.prestosql.spi.type.DoubleType;
import io.prestosql.spi.type.IntegerType;
import io.prestosql.spi.type.RealType;
import io.prestosql.spi.type.RowType;
import io.prestosql.spi.type.TimestampType;
import io.prestosql.spi.type.Type;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import static io.prestosql.spi.type.VarcharType.createUnboundedVarcharType;

public enum KoraliumType
{
    @JsonProperty("DOUBLE")
    DOUBLE(DoubleType.DOUBLE, 0, new DoubleDecoder(), new DoubleEncoder()),
    @JsonProperty("FLOAT")
    FLOAT(RealType.REAL, 1, new FloatDecoder(), new FloatEncoder()),
    @JsonProperty("INT32")
    INT32(IntegerType.INTEGER, 2, new IntDecoder(), new IntEncoder()),
    @JsonProperty("INT64")
    INT64(BigintType.BIGINT, 3, new Int64Decoder(), new Int64Encoder()),
    @JsonProperty("BOOL")
    BOOL(BooleanType.BOOLEAN, 4, new BoolDecoder(), new BoolEncoder()),
    @JsonProperty("STRING")
    STRING(createUnboundedVarcharType(), 5, new StringDecoder(), new StringEncoder()),
    @JsonProperty("TIMESTAMP")
    TIMESTAMP(TimestampType.TIMESTAMP_MILLIS, 6, new TimestampDecoder(), new TimestampEncoder()),
    @JsonProperty("OBJECT")
    OBJECT(null, 7, new ObjectTypeDecoder(), null), //Object is not used as a presto out type
    @JsonProperty("ARRAY")
    ARRAY(null, 8, new ArrayDecoder(), null);

    private static Map map = new HashMap<>();
    private final Type prestoType;
    private final int id;
    private final KoraliumDecoder decoder;
    private final IEncoder encoder;

    KoraliumType(Type prestoType, int id, KoraliumDecoder decoder, IEncoder encoder)
    {
        this.prestoType = prestoType;
        this.id = id;
        this.decoder = decoder;
        this.encoder = encoder;
    }

    public Type getPrestoType()
    {
        return prestoType;
    }

    static {
        for (KoraliumType pageType : KoraliumType.values()) {
            map.put(pageType.id, pageType);
        }
    }

    public static KoraliumType valueOf(int pageType)
    {
        return (KoraliumType) map.get(pageType);
    }

    //Creates presto types from column metadata
    public static Type CreatePrestoType(Presto.ColumnMetadata columnMetadata)
    {
        Presto.KoraliumType type = columnMetadata.getType();

        if (type.equals(Presto.KoraliumType.OBJECT)) {
            ImmutableList.Builder<RowType.Field> builder = ImmutableList.builder();
            List<Presto.ColumnMetadata> children = columnMetadata.getSubColumnsList();
            for (Presto.ColumnMetadata child : children) {
                Type childPrestoType = CreatePrestoType(child);
                builder.add(RowType.field(child.getName(), childPrestoType));
            }

            List<RowType.Field> fields = builder.build();

            return RowType.from(fields);
        }

        if (type.equals(Presto.KoraliumType.ARRAY)) {
            Presto.ColumnMetadata subColumn = columnMetadata.getSubColumns(0);
            Type childType = CreatePrestoType(subColumn);

            ArrayType arrayType = new ArrayType(childType);
            return arrayType;
        }

        return KoraliumType.valueOf(type.getNumber()).getPrestoType();
    }

    public int getId()
    {
        return id;
    }

    public KoraliumDecoder getDecoder()
    {
        return decoder;
    }

    public IEncoder getEncoder()
    {
        return encoder;
    }
}
