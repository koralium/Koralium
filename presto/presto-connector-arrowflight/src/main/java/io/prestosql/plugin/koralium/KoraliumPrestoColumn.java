package io.prestosql.plugin.koralium;

import com.fasterxml.jackson.annotation.JsonCreator;
import com.fasterxml.jackson.annotation.JsonProperty;
import io.prestosql.spi.connector.ColumnMetadata;
import io.prestosql.spi.type.Type;

import java.util.Objects;

public class KoraliumPrestoColumnHandle
{
    private final String columnName;
    private final Type type;

    @JsonCreator
    public KoraliumPrestoColumnHandle(
            @JsonProperty("columnName") String columnName,
            @JsonProperty("type") Type type)
    {
        this.columnName = columnName;
        this.type = type;
    }

    @JsonProperty
    public String getColumnName()
    {
        return columnName;
    }

    @JsonProperty
    public Type getType()
    {
        return type;
    }

    public ColumnMetadata getColumnMetadata()
    {
        return ColumnMetadata.builder()
                .setName(columnName)
                .setType(type)
                .build();
    }

    @Override
    public int hashCode()
    {
        return Objects.hash(
                columnName,
                type);
    }

    @Override
    public boolean equals(Object obj)
    {
        if (this == obj) {
            return true;
        }
        if (obj == null || getClass() != obj.getClass()) {
            return false;
        }
        KoraliumPrestoColumnHandle other = (KoraliumPrestoColumnHandle) obj;
        return Objects.equals(this.columnName, other.columnName) &&
                Objects.equals(this.type, other.type);
    }
}
