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
import io.prestosql.spi.connector.ConnectorIndexHandle;
import io.prestosql.spi.predicate.TupleDomain;

import java.util.Optional;
import java.util.Set;

import static java.util.Objects.requireNonNull;

public class GrpcIndexHandle
        implements ConnectorIndexHandle
{
    private final int tableId;
    private final int indexId;
    private final TupleDomain<ColumnHandle> tupleDomain;
    private final Optional<Set<ColumnHandle>> desiredColumns;

    @JsonCreator
    public GrpcIndexHandle(
            @JsonProperty("tableId") int tableId,
            @JsonProperty("indexId") int indexId,
            @JsonProperty("tupleDomain") TupleDomain<ColumnHandle> tupleDomain,
            @JsonProperty("desiredColumns") Optional<Set<ColumnHandle>> desiredColumns)
    {
        this.tableId = requireNonNull(tableId, "tableId is null");
        this.indexId = requireNonNull(indexId, "indexId is null");
        this.tupleDomain = requireNonNull(tupleDomain, "tupleDomain is null");
        this.desiredColumns = requireNonNull(desiredColumns, "desiredColumns is null");
    }

    @JsonProperty
    public int getTableId()
    {
        return tableId;
    }

    @JsonProperty
    public int getIndexId()
    {
        return indexId;
    }

    @JsonProperty
    public TupleDomain<ColumnHandle> getTupleDomain()
    {
        return tupleDomain;
    }

    @JsonProperty
    public Optional<Set<ColumnHandle>> getDesiredColumns()
    {
        return desiredColumns;
    }
}
