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

import com.fasterxml.jackson.annotation.JsonCreator;
import com.fasterxml.jackson.annotation.JsonProperty;
import io.trino.spi.connector.ColumnHandle;
import io.trino.spi.connector.ColumnMetadata;
import io.trino.spi.type.Type;

import java.util.Objects;

public class KoraliumPrestoColumn
        implements ColumnHandle
{
    private final String columnName;
    private final Type type;
    private final KoraliumType koraliumType;
    private final String expression;

    @JsonCreator
    public KoraliumPrestoColumn(
            @JsonProperty("columnName") String columnName,
            @JsonProperty("type") Type type,
            @JsonProperty("koraliumType") KoraliumType koraliumType,
            @JsonProperty("expression") String expression)
    {
        this.columnName = columnName;
        this.type = type;
        this.koraliumType = koraliumType;
        this.expression = expression;
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

    @JsonProperty
    public String getExpression()
    {
        return expression;
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
                type,
                expression);
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
                Objects.equals(this.type, other.type) &&
                Objects.equals(this.expression, other.expression);
    }
}
