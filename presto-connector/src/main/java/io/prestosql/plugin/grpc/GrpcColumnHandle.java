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
package io.prestosql.plugin.grpc;

import com.fasterxml.jackson.annotation.JsonCreator;
import com.fasterxml.jackson.annotation.JsonProperty;
import io.prestosql.spi.connector.ColumnHandle;
import io.prestosql.spi.connector.ColumnMetadata;
import io.prestosql.spi.type.Type;

import java.util.List;
import java.util.Objects;

public class GrpcColumnHandle
        implements ColumnHandle
{
    private final String columnName;
    private final GrpcType grpcType;
    private final int columnId;
    private GrpcColumnHandle parent;
    private final int catalogUniqueId;
    private final Type prestoType;
    private final List<GrpcColumnHandle> children;

    @JsonCreator
    public GrpcColumnHandle(
            @JsonProperty("columnName") String columnName,
            @JsonProperty("grpcType") GrpcType grpcType,
            @JsonProperty("columnId") int columnId,
            @JsonProperty("parent") GrpcColumnHandle parent,
            @JsonProperty("catalogUniqueId") int catalogUniqueId,
            @JsonProperty("prestoType") Type prestoType,
            @JsonProperty("children") List<GrpcColumnHandle> children)
    {
        this.columnName = columnName;
        this.grpcType = grpcType;
        this.columnId = columnId;
        this.parent = parent;
        this.catalogUniqueId = catalogUniqueId;
        this.prestoType = prestoType;
        this.children = children;
    }

    @JsonProperty
    public String getColumnName()
    {
        return columnName;
    }

    @JsonProperty
    public GrpcType getGrpcType()
    {
        return grpcType;
    }

    @JsonProperty
    public int getColumnId()
    {
        return columnId;
    }

    @JsonProperty
    public GrpcColumnHandle getParent()
    {
        return parent;
    }

    @JsonProperty
    public int getCatalogUniqueId()
    {
        return catalogUniqueId;
    }

    @JsonProperty
    public Type getPrestoType()
    {
        return prestoType;
    }

    @JsonProperty
    public List<GrpcColumnHandle> getChildren()
    {
        return children;
    }

    public Type getType()
    {
        return prestoType;
    }

    public ColumnMetadata getColumnMetadata()
    {
        return ColumnMetadata.builder()
                .setName(columnName)
                .setType(prestoType)
                .build();
    }

    @Override
    public int hashCode()
    {
        return Objects.hash(
                columnName,
                grpcType,
                columnId,
                parent);
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
        GrpcColumnHandle other = (GrpcColumnHandle) obj;
        return Objects.equals(this.columnName, other.columnName) &&
                Objects.equals(this.grpcType, other.grpcType) &&
                Objects.equals(this.columnId, other.columnId) &&
                Objects.equals(this.parent, other.parent);
    }
}
