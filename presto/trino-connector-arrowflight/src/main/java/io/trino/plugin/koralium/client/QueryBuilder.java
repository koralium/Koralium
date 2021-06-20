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
package io.trino.plugin.koralium.client;

import io.trino.plugin.koralium.KoraliumPrestoColumn;
import io.trino.plugin.koralium.KoraliumSortItem;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.OptionalLong;
import java.util.stream.Collectors;

public class QueryBuilder
{
    public String buildCountQuery(
            String tableName,
            String filter,
            OptionalLong limit)
    {
        if (limit.isPresent()) {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.append("SELECT count(*) FROM ( SELECT * FROM ");
            stringBuilder.append(tableName);

            if (filter != null && !filter.isEmpty()) {
                stringBuilder.append(" WHERE ");
                stringBuilder.append(filter);
            }

            stringBuilder.append(" LIMIT ");
            stringBuilder.append(limit.getAsLong());

            stringBuilder.append(")");
            return stringBuilder.toString();
        }
        else {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.append("SELECT count(*) FROM ");
            stringBuilder.append(tableName);

            if (filter != null && !filter.isEmpty()) {
                stringBuilder.append(" WHERE ");
                stringBuilder.append(filter);
            }

            return stringBuilder.toString();
        }
    }

    public String buildQuery(
            Optional<List<KoraliumPrestoColumn>> columns,
            String tableName,
            String filter,
            Optional<List<KoraliumSortItem>> sortItems,
            OptionalLong limit)
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.append("SELECT ");

        if (columns.isPresent()) {
            String columnSelect = String.join(", ", columns.get().stream().map(x -> x.getColumnName()).collect(Collectors.toList()));
            stringBuilder.append(columnSelect);
        }
        else {
            stringBuilder.append("*");
        }

        stringBuilder.append(" FROM ");
        stringBuilder.append(tableName);

        if (filter != null && !filter.isEmpty()) {
            stringBuilder.append(" WHERE ");
            stringBuilder.append(filter);
        }

        if (sortItems.isPresent()) {
            List<String> orderBys = new ArrayList<>();
            List<KoraliumSortItem> items = sortItems.get();

            for (KoraliumSortItem item : items) {
                String sortString = item.getColumnHandle().getColumnName();

                if (item.getSortOrder().isAscending()) {
                    sortString += " ASC";
                }
                else {
                    sortString += " DESC";
                }
                orderBys.add(sortString);
            }

            if (orderBys.size() > 0) {
                stringBuilder.append(" ORDER BY ");
                stringBuilder.append(String.join(", ", orderBys));
            }
        }

        if (limit.isPresent()) {
            stringBuilder.append(" LIMIT ");
            stringBuilder.append(limit.getAsLong());
        }

        return stringBuilder.toString();
    }
}
