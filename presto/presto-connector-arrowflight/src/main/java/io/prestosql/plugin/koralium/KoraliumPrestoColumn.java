package io.prestosql.plugin.koralium;

import com.fasterxml.jackson.annotation.JsonCreator;
import com.fasterxml.jackson.annotation.JsonProperty;
import io.prestosql.spi.connector.ColumnHandle;
import io.prestosql.spi.connector.ColumnMetadata;
import io.prestosql.spi.type.Type;

import java.util.Objects;

public class KoraliumPrestoColumn
        implements ColumnHandle
{
    private final String columnName;
    private final Type type;
    private final KoraliumType koraliumType;

    @JsonCreator
    public KoraliumPrestoColumn(
            @JsonProperty("columnName") String columnName,
            @JsonProperty("type") Type type,
            @JsonProperty("koraliumType") KoraliumType koraliumType)
    {
        this.columnName = columnName;
        this.type = type;
        this.koraliumType = koraliumType;
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

    @JsonProperty
    public KoraliumType getKoraliumType()
    {
        return koraliumType;
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
        KoraliumPrestoColumn other = (KoraliumPrestoColumn) obj;
        return Objects.equals(this.columnName, other.columnName) &&
                Objects.equals(this.type, other.type);
    }
}
