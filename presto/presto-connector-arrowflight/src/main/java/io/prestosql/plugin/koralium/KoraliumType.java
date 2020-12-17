package io.prestosql.plugin.koralium;

import com.fasterxml.jackson.annotation.JsonProperty;
import io.airlift.slice.Slice;
import io.prestosql.plugin.koralium.decoders.*;

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
    ARRAY(null, new ListDecoder());

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
