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

import com.google.common.base.Joiner;
import com.google.common.collect.ImmutableList;
import com.google.common.collect.ImmutableMap;
import com.google.common.collect.ImmutableSet;
import io.prestosql.plugin.koralium.client.PrestoKoraliumClient;
import io.prestosql.spi.connector.*;
import io.prestosql.spi.expression.ConnectorExpression;
import io.prestosql.spi.predicate.Domain;
import io.prestosql.spi.predicate.TupleDomain;

import javax.inject.Inject;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.OptionalLong;
import java.util.Set;
import java.util.stream.Collectors;

import static com.google.common.collect.ImmutableList.toImmutableList;
import static java.util.Objects.requireNonNull;

public class KoraliumMetadata
        implements ConnectorMetadata
{
    private final PrestoKoraliumClient koraliumClient;

    @Inject
    public KoraliumMetadata(PrestoKoraliumClient client)
    {
        this.koraliumClient = requireNonNull(client, "client is null");
    }

    @Override
    public List<String> listSchemaNames(ConnectorSession session)
    {
        return koraliumClient.getSchemaNames();
    }

    @Override
    public KoraliumTableHandle getTableHandle(ConnectorSession session, SchemaTableName tableName)
    {
        return koraliumClient.getTableHandle(tableName);
    }

    @Override
    public boolean usesLegacyTableLayouts()
    {
        return false;
    }

    private static SchemaTableName getTableName(ConnectorTableHandle tableHandle)
    {
        return ((KoraliumTableHandle) tableHandle).getSchemaTableName();
    }

    @Override
    public ConnectorTableMetadata getTableMetadata(ConnectorSession session, ConnectorTableHandle tableHandle)
    {
        requireNonNull(tableHandle, "tableHandle is null");
        return getTableMetadata(getTableName(tableHandle));
    }

    private ConnectorTableMetadata getTableMetadata(SchemaTableName tableName)
    {
        return koraliumClient.getTableMetadata(tableName);
    }

    private List<String> listSchemas(ConnectorSession session, Optional<String> schemaName)
    {
        if (schemaName.isPresent()) {
            return listSchemaNames(session)
                    .stream()
                    .filter(schema -> schema.equals(schemaName.get()))
                    .collect(toImmutableList());
        }

        return (ImmutableList<String>) listSchemaNames(session);
    }

    @Override
    public List<SchemaTableName> listTables(ConnectorSession session, Optional<String> optionalSchemaName)
    {
        ImmutableList.Builder<SchemaTableName> tableNames = ImmutableList.builder();
        List<String> schemaNames = listSchemas(session, optionalSchemaName);
        for (String schemaName : schemaNames) {
            try {
                for (SchemaTableName schemaTableName : koraliumClient.getSchemaTableNames(schemaName)) {
                    tableNames.add(schemaTableName);
                }
            }
            catch (SchemaNotFoundException e) {
                // schema disappeared during listing operation
            }
        }
        return tableNames.build();
    }

    @Override
    public Map<String, ColumnHandle> getColumnHandles(ConnectorSession session, ConnectorTableHandle tableHandle)
    {
        requireNonNull(session, "session is null");
        requireNonNull(tableHandle, "tableHandle is null");

        return koraliumClient.getColumnHandles(getTableName(tableHandle));
    }

    @Override
    public Map<SchemaTableName, List<ColumnMetadata>> listTableColumns(ConnectorSession session, SchemaTablePrefix prefix)
    {
        requireNonNull(prefix, "prefix is null");
        ImmutableMap.Builder<SchemaTableName, List<ColumnMetadata>> columns = ImmutableMap.builder();
        for (SchemaTableName tableName : listTables(session, prefix)) {
            ConnectorTableMetadata tableMetadata = getTableMetadata(tableName);
            // table can disappear during listing operation
            if (tableMetadata != null) {
                columns.put(tableName, tableMetadata.getColumns());
            }
        }
        return columns.build();
    }

    private List<SchemaTableName> listTables(ConnectorSession session, SchemaTablePrefix prefix)
    {
        if (prefix.getSchema().isPresent() && !schemaExists(session, prefix.getSchema().get())) {
            return ImmutableList.of();
        }

        if (!prefix.getTable().isPresent()) {
            return listTables(session, prefix.getSchema());
        }
        return ImmutableList.of(prefix.toSchemaTableName());
    }

    @Override
    public ColumnMetadata getColumnMetadata(ConnectorSession session, ConnectorTableHandle tableHandle, ColumnHandle columnHandle)
    {
        return ((KoraliumPrestoColumn) columnHandle).getColumnMetadata();
    }

    @Override
    public ConnectorTableProperties getTableProperties(ConnectorSession session, ConnectorTableHandle table)
    {
        return new ConnectorTableProperties();
    }

    @Override
    public Optional<LimitApplicationResult<ConnectorTableHandle>> applyLimit(ConnectorSession session, ConnectorTableHandle handle, long limit)
    {
        KoraliumTableHandle tableHandle = (KoraliumTableHandle) handle;

        if (tableHandle.getLimit().isPresent() && tableHandle.getLimit().getAsLong() <= limit) {
            return Optional.empty();
        }

        tableHandle = new KoraliumTableHandle(
                tableHandle.getSchemaName(),
                tableHandle.getTableName(),
                tableHandle.getConstraint(),
                tableHandle.getDesiredColumns(),
                tableHandle.getTableId(),
                OptionalLong.of(limit),
                tableHandle.getSortOrder());

        return Optional.of(new LimitApplicationResult<>(tableHandle, false));
    }

    @Override
    public Optional<ProjectionApplicationResult<ConnectorTableHandle>> applyProjection(
            ConnectorSession session,
            ConnectorTableHandle handle,
            List<ConnectorExpression> projections,
            Map<String, ColumnHandle> assignments)
    {
        KoraliumTableHandle tableHandle = (KoraliumTableHandle)handle;

        List<KoraliumPrestoColumn> newColumns = assignments.values().stream()
                .map(KoraliumPrestoColumn.class::cast)
                .collect(toImmutableList());

        if (tableHandle.getDesiredColumns().isPresent() && containSameElements(newColumns, tableHandle.getDesiredColumns().get())) {
            return Optional.empty();
        }

        return Optional.of(new ProjectionApplicationResult<>(
                new KoraliumTableHandle(
                        tableHandle.getSchemaName(),
                        tableHandle.getTableName(),
                        tableHandle.getConstraint(),
                        Optional.of(newColumns),
                        tableHandle.getTableId(),
                        tableHandle.getLimit(),
                        tableHandle.getSortOrder()),
                projections,
                assignments.entrySet().stream()
                        .map(assignment -> new Assignment(
                                assignment.getKey(),
                                assignment.getValue(),
                                ((KoraliumPrestoColumn) assignment.getValue()).getType()))
                        .collect(toImmutableList())));
    }

    @Override
    public Optional<TopNApplicationResult<ConnectorTableHandle>> applyTopN(ConnectorSession session, ConnectorTableHandle handle, long topNCount, List<SortItem> sortItems, Map<String, ColumnHandle> assignments)
    {
        KoraliumTableHandle tableHandle = (KoraliumTableHandle) handle;

        if (tableHandle.getLimit().isPresent() && tableHandle.getSortOrder().isPresent() && tableHandle.getLimit().getAsLong() <= topNCount) {
            return Optional.of(new TopNApplicationResult<>(handle, true));
        }

        if (!sortItems.stream()
                .allMatch(sortItem -> assignments.containsKey(sortItem.getName()))) {
            return Optional.empty();
        }

        List<KoraliumSortItem> sortOrder = sortItems.stream()
                .map(sortItem -> new KoraliumSortItem(((KoraliumPrestoColumn) assignments.get(sortItem.getName())), sortItem.getSortOrder()))
                .collect(Collectors.toList());

        tableHandle = new KoraliumTableHandle(
                tableHandle.getSchemaName(),
                tableHandle.getTableName(),
                tableHandle.getConstraint(),
                tableHandle.getDesiredColumns(),
                tableHandle.getTableId(),
                OptionalLong.of(topNCount),
                Optional.of(sortOrder));

        return Optional.of(new TopNApplicationResult<>(tableHandle, true));
    }

    @Override
    public Optional<ConstraintApplicationResult<ConnectorTableHandle>> applyFilter(
            ConnectorSession session,
            ConnectorTableHandle handle,
            Constraint constraint)
    {
        KoraliumTableHandle tableHandle = (KoraliumTableHandle) handle;

        Map<ColumnHandle, Domain> supported = new HashMap<>();
        Map<ColumnHandle, Domain> unsupported = new HashMap<>();
        if (constraint.getSummary().getDomains().isPresent()) {
            for (Map.Entry<ColumnHandle, Domain> entry : constraint.getSummary().getDomains().get().entrySet()) {
                supported.put(entry.getKey(), entry.getValue());
            }
        }

        TupleDomain<ColumnHandle> oldDomain = tableHandle.getConstraint();
        TupleDomain<ColumnHandle> newDomain = oldDomain.intersect(TupleDomain.withColumnDomains(supported));
        if (oldDomain.equals(newDomain)) {
            return Optional.empty();
        }

        tableHandle = new KoraliumTableHandle(
                tableHandle.getSchemaName(),
                tableHandle.getTableName(),
                newDomain,
                tableHandle.getDesiredColumns(),
                tableHandle.getTableId(),
                tableHandle.getLimit(),
                tableHandle.getSortOrder());

        return Optional.of(new ConstraintApplicationResult<>(tableHandle, TupleDomain.withColumnDomains(unsupported)));
    }

    @Override
    public Optional<AggregationApplicationResult<ConnectorTableHandle>> applyAggregation(ConnectorSession session, ConnectorTableHandle handle, List<AggregateFunction> aggregates, Map<String, ColumnHandle> assignments, List<List<ColumnHandle>> groupingSets)
    {
        return Optional.empty();
    }

    private static boolean containSameElements(Iterable<? extends ColumnHandle> first, Iterable<? extends ColumnHandle> second)
    {
        return ImmutableSet.copyOf(first).equals(ImmutableSet.copyOf(second));
    }
}
