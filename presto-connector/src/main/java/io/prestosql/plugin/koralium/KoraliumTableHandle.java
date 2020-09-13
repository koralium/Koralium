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

import com.fasterxml.jackson.annotation.JsonCreator;
import com.fasterxml.jackson.annotation.JsonProperty;
import io.prestosql.spi.connector.ColumnHandle;
import io.prestosql.spi.connector.ConnectorTableHandle;
import io.prestosql.spi.connector.SchemaTableName;
import io.prestosql.spi.predicate.TupleDomain;

import java.util.List;
import java.util.Objects;
import java.util.Optional;
import java.util.OptionalLong;
import java.util.Set;

import static java.util.Objects.requireNonNull;

public class GrpcTableHandle
        implements ConnectorTableHandle
{
    private final String schemaName;
    private final String tableName;
    private final TupleDomain<ColumnHandle> constraint;
    private final Optional<Set<ColumnHandle>> desiredColumns;
    private final OptionalLong limit;
    private final int tableId;
    private final Optional<List<GrpcSortItem>> sortOrder;

    @JsonCreator
    public GrpcTableHandle(
            @JsonProperty("schemaName") String schemaName,
            @JsonProperty("tableName") String tableName,
            @JsonProperty("constraint") TupleDomain<ColumnHandle> constraint,
            @JsonProperty("desiredColumns") Optional<Set<ColumnHandle>> desiredColumns,
            @JsonProperty("tableId") int tableId,
            @JsonProperty("limit") OptionalLong limit,
            @JsonProperty("sortOrder") Optional<List<GrpcSortItem>> sortOrder)
    {
        this.schemaName = requireNonNull(schemaName, "schemaName is null");
        this.tableName = requireNonNull(tableName, "tableName is null");
        this.constraint = requireNonNull(constraint, "constraint is null");
        this.desiredColumns = requireNonNull(desiredColumns, "desiredColumns is null");
        this.tableId = tableId;
        this.limit = limit;
        this.sortOrder = requireNonNull(sortOrder, "sortOrder is null");
    }

    @JsonProperty
    public String getSchemaName()
    {
        return schemaName;
    }

    @JsonProperty
    public String getTableName()
    {
        return tableName;
    }

    @JsonProperty
    public TupleDomain<ColumnHandle> getConstraint()
    {
        return constraint;
    }

    @JsonProperty
    public Optional<Set<ColumnHandle>> getDesiredColumns()
    {
        return desiredColumns;
    }

    @JsonProperty
    public int getTableId()
    {
        return tableId;
    }

    @JsonProperty
    public OptionalLong getLimit()
    {
        return limit;
    }

    @JsonProperty
    public Optional<List<GrpcSortItem>> getSortOrder()
    {
        return sortOrder;
    }

    public SchemaTableName getSchemaTableName()
    {
        return new SchemaTableName(schemaName, tableName);
    }

    @Override
    public boolean equals(Object obj)
    {
        if (this == obj) {
            return true;
        }
        if ((obj == null) || (getClass() != obj.getClass())) {
            return false;
        }

        GrpcTableHandle other = (GrpcTableHandle) obj;
        return Objects.equals(this.schemaName, other.schemaName) &&
                Objects.equals(this.tableName, other.tableName) &&
                Objects.equals(this.constraint, other.constraint) &&
                Objects.equals(this.desiredColumns, other.desiredColumns);
    }

    @Override
    public int hashCode()
    {
        return Objects.hash(
                schemaName,
                tableName,
                constraint,
                desiredColumns);
    }

    public SchemaTableName toSchemaTableName()
    {
        return new SchemaTableName(schemaName, tableName);
    }
}
