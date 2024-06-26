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
package io.trino.plugin.koralium;

import com.fasterxml.jackson.annotation.JsonProperty;
import io.airlift.slice.Slice;
import io.trino.plugin.koralium.decoders.BinaryDecoder;
import io.trino.plugin.koralium.decoders.BoolDecoder;
import io.trino.plugin.koralium.decoders.Decimal128Decoder;
import io.trino.plugin.koralium.decoders.DoubleDecoder;
import io.trino.plugin.koralium.decoders.FloatDecoder;
import io.trino.plugin.koralium.decoders.Int16Decoder;
import io.trino.plugin.koralium.decoders.Int32Decoder;
import io.trino.plugin.koralium.decoders.Int64Decoder;
import io.trino.plugin.koralium.decoders.KoraliumDecoder;
import io.trino.plugin.koralium.decoders.ListDecoder;
import io.trino.plugin.koralium.decoders.ObjectTypeDecoder;
import io.trino.plugin.koralium.decoders.StringDecoder;
import io.trino.plugin.koralium.decoders.TimestampDecoder;
import io.trino.plugin.koralium.decoders.UInt32Decoder;
import io.trino.plugin.koralium.decoders.UInt64Decoder;
import io.trino.plugin.koralium.decoders.UInt8Decoder;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public enum KoraliumType
{
    @JsonProperty("DOUBLE")
    DOUBLE(KoraliumType::simpleToStringConverter, new DoubleDecoder()),
    @JsonProperty("FLOAT")
    FLOAT(KoraliumType::simpleToStringConverter, new FloatDecoder()),
    @JsonProperty("INT32")
    INT32(KoraliumType::simpleToStringConverter, new Int32Decoder()),
    @JsonProperty("INT64")
    INT64(KoraliumType::simpleToStringConverter, new Int64Decoder()),
    @JsonProperty("BOOL")
    BOOL(KoraliumType::simpleToStringConverter, new BoolDecoder()),
    @JsonProperty("STRING")
    STRING(KoraliumType::StringToSring, new StringDecoder()),
    @JsonProperty("TIMESTAMP")
    TIMESTAMP(KoraliumType::TimestampToString, new TimestampDecoder()),
    @JsonProperty("OBJECT")
    OBJECT(null, new ObjectTypeDecoder()), //Object is not used as a presto out type
    @JsonProperty("ARRAY")
    ARRAY(null, new ListDecoder()),
    @JsonProperty("INT16")
    INT16(KoraliumType::simpleToStringConverter, new Int16Decoder()),
    @JsonProperty("UINT32")
    UINT32(KoraliumType::simpleToStringConverter, new UInt32Decoder()),
    @JsonProperty("UINT64")
    UINT64(KoraliumType::simpleToStringConverter, new UInt64Decoder()),
    @JsonProperty("UINT8")
    UINT8(KoraliumType::simpleToStringConverter, new UInt8Decoder()),
    @JsonProperty("BINARY")
    BINARY(null, new BinaryDecoder()),
    @JsonProperty("DECIMAL")
    DECIMAL(KoraliumType::simpleToStringConverter, new Decimal128Decoder());

    private final ToStringConverter toStringConverter;
    private final KoraliumDecoder decoder;

    KoraliumType(ToStringConverter toStringConverter, KoraliumDecoder decoder)
    {
        this.toStringConverter = toStringConverter;
        this.decoder = decoder;
    }

    public ToStringConverter GetConverter()
    {
        return toStringConverter;
    }

    public KoraliumDecoder getDecoder()
    {
        return decoder;
    }

    static String simpleToStringConverter(Object value)
    {
        return String.valueOf(value);
    }

    static String StringToSring(Object object)
    {
        if (object instanceof String) {
            return (String) object;
        }
        else if (object instanceof Slice) {
            return "'" + ((Slice) object).toStringUtf8() + "'";
        }

        return object.toString();
    }

    static String TimestampToString(Object object)
    {
        if (object instanceof Long) {
            DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd'T'HH:mm:ss'Z'");
            java.sql.Timestamp timestamp = new java.sql.Timestamp((long) object);
            LocalDateTime localDateTime = timestamp.toLocalDateTime();

            return localDateTime.format(formatter);
        }
        return object.toString();
    }

    @FunctionalInterface
    public interface ToStringConverter
    {
        String convertToString(Object value);
    }
}
