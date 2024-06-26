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
package io.prestosql.plugin.koralium.client;

import com.google.common.base.Joiner;
import com.google.common.collect.ImmutableList;
import com.google.common.collect.ImmutableMap;
import com.google.protobuf.Empty;
import io.grpc.Channel;
import io.prestosql.plugin.koralium.KoraliumColumnHandle;
import io.prestosql.plugin.koralium.KoraliumServiceGrpc;
import io.prestosql.plugin.koralium.KoraliumTable;
import io.prestosql.plugin.koralium.KoraliumTableHandle;
import io.prestosql.plugin.koralium.KoraliumTableIndex;
import io.prestosql.plugin.koralium.KoraliumType;
import io.prestosql.plugin.koralium.Presto;
import io.prestosql.spi.connector.ColumnHandle;
import io.prestosql.spi.connector.ConnectorTableMetadata;
import io.prestosql.spi.connector.SchemaTableName;
import io.prestosql.spi.type.ArrayType;
import io.prestosql.spi.type.RowType;

import java.util.List;
import java.util.Map;

import static com.google.common.collect.ImmutableList.toImmutableList;
import static java.util.Locale.ENGLISH;

public class KoraliumMetadataCache
        implements KoraliumMetadataClient
{
    private static final String schemaName = "default";
    private final KoraliumServiceGrpc.KoraliumServiceBlockingStub client;
    private final List<KoraliumTable> tables;
    private final List<String> schemaNames;
    private final Map<SchemaTableName, KoraliumTable> schemaTableNameToTable;
    private final Map<String, List<SchemaTableName>> schemaNameToSchemaTableNames;
    private final Map<String, KoraliumTableIndex> columnsKeyToIndex;

    public KoraliumMetadataCache(Channel channel)
    {
        this.client = KoraliumServiceGrpc.newBlockingStub(channel);

        Presto.TableMetadataResponse tablesResponse = client.getTables(Empty.getDefaultInstance());
        this.schemaNames = generateSchemaNames(tablesResponse);
        this.tables = generateGrpcTables(tablesResponse);
        this.schemaTableNameToTable = getSchemaTableNameToTable(this.tables);
        this.schemaNameToSchemaTableNames = getSchemaNameToTables(this.tables);
        this.columnsKeyToIndex = generateIndexLookup(this.tables);
    }

    public KoraliumTableIndex getTableIndex(String key)
    {
        return columnsKeyToIndex.get(key);
    }

    private Map<String, KoraliumTableIndex> generateIndexLookup(List<KoraliumTable> tables)
    {
        ImmutableMap.Builder<String, KoraliumTableIndex> builder = new ImmutableMap.Builder<>();

        for (KoraliumTable table : tables) {
            for (KoraliumTableIndex index : table.getIndices()) {
                builder.put(index.getKey(), index);
            }
        }
        return builder.build();
    }

    private List<String> generateSchemaNames(Presto.TableMetadataResponse tableMetadataResponse)
    {
        return ImmutableList.of(schemaName);
    }

    private List<KoraliumTable> generateGrpcTables(Presto.TableMetadataResponse tableMetadataResponse)
    {
        return tableMetadataResponse.getTablesList().stream()
                .map(this::generateTable)
                .collect(toImmutableList());
    }

    private KoraliumTable generateTable(Presto.TableMetadata tableMetadata)
    {
        String name = tableMetadata.getName();
        SchemaTableName schemaTableName = new SchemaTableName(schemaName, name);

        List<Presto.ColumnMetadata> columnsMetadata = tableMetadata.getColumnsList();

        ImmutableList.Builder<KoraliumColumnHandle> builder = new ImmutableList.Builder<>();
        for (Presto.ColumnMetadata column : columnsMetadata) {
            builder.addAll(generateColumnHandle(column, null));
        }

        List<KoraliumColumnHandle> columns = builder.build();

        ConnectorTableMetadata connectorTableMetadata = new ConnectorTableMetadata(schemaTableName, columns.stream().map(KoraliumColumnHandle::getColumnMetadata).collect(toImmutableList()));

        List<KoraliumTableIndex> indices = generateTableIndices(tableMetadata);

        return new KoraliumTable(schemaTableName, tableMetadata.getTableId(), connectorTableMetadata, columns, indices);
    }

    private List<KoraliumTableIndex> generateTableIndices(Presto.TableMetadata tableMetadata)
    {
        List<Presto.IndexMetadata> indices = tableMetadata.getIndiciesList();

        ImmutableList.Builder<KoraliumTableIndex> builder = new ImmutableList.Builder<>();
        for (Presto.IndexMetadata index : indices) {
            List<Presto.ColumnMetadata> columnsMetadata = index.getColumnsList();

            List<Integer> keys = columnsMetadata.stream()
                    .map(Presto.ColumnMetadata::getColumnId)
                    .sorted()
                    .collect(toImmutableList());

            String indexKey = tableMetadata.getTableId() + ":" + Joiner.on('_').join(keys);
            builder.add(new KoraliumTableIndex(tableMetadata.getTableId(), index.getIndexId(), indexKey));
        }
        return builder.build();
    }

    private String generateColumnNamePrefix(KoraliumColumnHandle parent)
    {
        if (parent == null) {
            return "";
        }
        return generateColumnNamePrefix(parent.getParent()) + parent.getColumnName() + "_";
    }

    private List<KoraliumColumnHandle> generateColumnHandle(Presto.ColumnMetadata columnMetadata, KoraliumColumnHandle parent)
    {
        Presto.KoraliumType type = columnMetadata.getType();

        if (type.equals(Presto.KoraliumType.OBJECT)) {
            ImmutableList.Builder<RowType.Field> builder = ImmutableList.builder();
            ImmutableList.Builder<KoraliumColumnHandle> childrenBuilder = new ImmutableList.Builder<>();
            List<Presto.ColumnMetadata> children = columnMetadata.getSubColumnsList();
            for (Presto.ColumnMetadata child : children) {
                List<KoraliumColumnHandle> childColumnHandles = generateColumnHandle(child, null);

                for (KoraliumColumnHandle childColumnHandle : childColumnHandles) {
                    builder.add(RowType.field(child.getName(), childColumnHandle.getPrestoType()));
                    childrenBuilder.add(childColumnHandle);
                }
            }

            List<RowType.Field> fields = builder.build();

            KoraliumColumnHandle handle = new KoraliumColumnHandle(columnMetadata.getName(),
                    KoraliumType.valueOf(type.getNumber()),
                    columnMetadata.getColumnId(),
                    parent,
                    columnMetadata.getColumnId(),
                    RowType.from(fields),
                    childrenBuilder.build());

            return ImmutableList.of(handle);
        }

        if (type.equals(Presto.KoraliumType.ARRAY)) {
            Presto.ColumnMetadata subColumn = columnMetadata.getSubColumns(0);
            KoraliumColumnHandle childColumnHandle = generateColumnHandle(subColumn, null).get(0);

            ArrayType arrayType = new ArrayType(childColumnHandle.getPrestoType());

            KoraliumColumnHandle handle = new KoraliumColumnHandle(columnMetadata.getName(),
                    KoraliumType.valueOf(type.getNumber()),
                    columnMetadata.getColumnId(),
                    parent,
                    columnMetadata.getColumnId(),
                    arrayType,
                    ImmutableList.of(childColumnHandle));

            return ImmutableList.of(handle);
        }

        String columnName = generateColumnNamePrefix(parent) + columnMetadata.getName();
        return ImmutableList.of(new KoraliumColumnHandle(columnName,
                KoraliumType.valueOf(type.getNumber()),
                columnMetadata.getColumnId(),
                parent,
                columnMetadata.getColumnId(),
                KoraliumType.valueOf(type.getNumber()).getPrestoType(),
                ImmutableList.of()));
    }

    private Map<SchemaTableName, KoraliumTable> getSchemaTableNameToTable(List<KoraliumTable> tables)
    {
        ImmutableMap.Builder<SchemaTableName, KoraliumTable> builder = new ImmutableMap.Builder<>();

        for (KoraliumTable table : tables) {
            builder.put(table.getSchemaTableName(), table);
        }

        return builder.build();
    }

    private Map<String, List<SchemaTableName>> getSchemaNameToTables(List<KoraliumTable> tables)
    {
        List<String> schemas = getSchemaNames();

        ImmutableMap.Builder<String, List<SchemaTableName>> builder = new ImmutableMap.Builder<>();

        for (String schemaName : schemas) {
            List<SchemaTableName> tableNames = tables
                    .stream()
                    .filter(table -> table.getSchemaName().equals(schemaName))
                    .map(KoraliumTable::getSchemaTableName)
                    .collect(toImmutableList());

            builder.put(schemaName, tableNames);
        }
        return builder.build();
    }

    @Override
    public List<String> getSchemaNames()
    {
        return schemaNames;
    }

    @Override
    public KoraliumTableHandle getTableHandle(SchemaTableName schemaTableName)
    {
        if (schemaTableNameToTable.containsKey(schemaTableName)) {
            return schemaTableNameToTable.get(schemaTableName).getTableHandle();
        }
        return null;
    }

    @Override
    public ConnectorTableMetadata getTableMetadata(SchemaTableName schemaTableName)
    {
        KoraliumTable table = schemaTableNameToTable.get(schemaTableName);
        return table.getConnectorTableMetadata();
    }

    @Override
    public List<SchemaTableName> getSchemaTableNames(String schema)
    {
        return schemaNameToSchemaTableNames.get(schema);
    }

    @Override
    public Map<String, ColumnHandle> getColumnHandles(SchemaTableName schemaTableName)
    {
        KoraliumTable table = schemaTableNameToTable.get(schemaTableName);

        ImmutableMap.Builder<String, ColumnHandle> columnHandles = ImmutableMap.builder();
        for (KoraliumColumnHandle columnHandle : table.getColumnHandles()) {
            columnHandles.put(columnHandle.getColumnName().toLowerCase(ENGLISH), columnHandle);
        }

        return columnHandles.build();
    }
}
