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
import io.prestosql.spi.connector.SortOrder;

import java.util.Objects;

import static java.util.Objects.requireNonNull;

public class KoraliumSortItem
{
    private final KoraliumPrestoColumn columnHandle;
    private final SortOrder sortOrder;

    @JsonCreator
    public KoraliumSortItem(
            @JsonProperty("columnHandle") KoraliumPrestoColumn columnHandle,
            @JsonProperty("SortOrder") SortOrder sortOrder)
    {
        this.columnHandle = requireNonNull(columnHandle, "columnHandle is null");
        this.sortOrder = requireNonNull(sortOrder, "sortOrder is null");
    }

    @JsonProperty
    public KoraliumPrestoColumn getColumnHandle()
    {
        return columnHandle;
    }

    @JsonProperty
    public SortOrder getSortOrder()
    {
        return sortOrder;
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

        KoraliumSortItem other = (KoraliumSortItem) obj;
        return Objects.equals(this.columnHandle, other.columnHandle) &&
                Objects.equals(this.sortOrder, other.sortOrder);
    }

    @Override
    public int hashCode()
    {
        return Objects.hash(
                columnHandle,
                sortOrder);
    }
}
