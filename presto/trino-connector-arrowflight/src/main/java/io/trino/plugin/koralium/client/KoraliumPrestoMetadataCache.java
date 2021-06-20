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

import com.google.common.collect.ImmutableList;
import com.google.common.collect.ImmutableMap;
import io.trino.plugin.koralium.KoraliumConfig;
import io.trino.plugin.koralium.KoraliumPrestoColumn;
import io.trino.plugin.koralium.KoraliumPrestoTable;
import io.trino.plugin.koralium.KoraliumTableHandle;
import io.trino.plugin.koralium.KoraliumTableIndex;
import io.trino.plugin.koralium.utils.ArrowPrestoTypeConverter;
import io.trino.plugin.koralium.utils.SqlUtils;
import io.trino.plugin.koralium.utils.TypeConvertResult;
import io.trino.spi.connector.ColumnHandle;
import io.trino.spi.connector.ConnectorTableMetadata;
import io.trino.spi.connector.SchemaTableName;
import org.apache.arrow.flight.Criteria;
import org.apache.arrow.flight.FlightClient;
import org.apache.arrow.flight.FlightInfo;
import org.apache.arrow.flight.Location;
import org.apache.arrow.memory.BufferAllocator;
import org.apache.arrow.memory.RootAllocator;
import org.apache.arrow.vector.types.pojo.Field;
import org.apache.arrow.vector.types.pojo.Schema;

import javax.inject.Inject;

import java.nio.charset.StandardCharsets;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

import static com.google.common.collect.ImmutableList.toImmutableList;
import static java.util.Locale.ENGLISH;

public class KoraliumPrestoMetadataCache
        implements KoraliumMetadataClient
{
    private static final String schemaName = "default";

    private BufferAllocator allocator;
    FlightClient flightClient;
    private List<KoraliumPrestoTable> tables;
    private Map<SchemaTableName, KoraliumPrestoTable> schemaTableNameToTable;
    private Map<String, List<SchemaTableName>> schemaNameToSchemaTableNames;

    @Inject
    public KoraliumPrestoMetadataCache(KoraliumConfig config)
    {
        allocator = new RootAllocator(Long.MAX_VALUE);

        String[] urlSplit = config.getUrl().split(":");

        String host = urlSplit[0];
        int port = 80;
        if (urlSplit.length > 1) {
            port = Integer.parseInt(urlSplit[1]);
        }

        Location l = Location.forGrpcInsecure(host, port);
        flightClient = FlightClient.builder(allocator, l).build();

        buildMetadata();
    }

    private void buildMetadata()
    {
        Iterable<FlightInfo> flightInfos = flightClient.listFlights(Criteria.ALL);

        ImmutableList.Builder<KoraliumPrestoTable> tableListBuilder = new ImmutableList.Builder<>();
        for (FlightInfo flightInfo : flightInfos) {
            String sql = new String(flightInfo.getDescriptor().getCommand(), StandardCharsets.UTF_8);
            String tableName = SqlUtils.getTableName(sql);

            Schema schema = flightInfo.getSchema();
            List<Field> fields = schema.getFields();

            ImmutableList.Builder<KoraliumPrestoColumn> builder = new ImmutableList.Builder<>();
            for (Field field : fields) {
                TypeConvertResult convertResult = ArrowPrestoTypeConverter.Convert(field);
                KoraliumPrestoColumn column = new KoraliumPrestoColumn(field.getName(), convertResult.getPrestoType(), convertResult.getKoraliumType(), field.getName());
                builder.add(column);
            }
            List<KoraliumPrestoColumn> columns = builder.build();
            SchemaTableName schemaTableName = new SchemaTableName(schemaName, tableName);
            ConnectorTableMetadata connectorTableMetadata = new ConnectorTableMetadata(schemaTableName, columns.stream().map(KoraliumPrestoColumn::getColumnMetadata).collect(Collectors.toList()));
            tableListBuilder.add(new KoraliumPrestoTable(schemaTableName, connectorTableMetadata, columns));
        }
        List<KoraliumPrestoTable> tables = tableListBuilder.build();
        schemaTableNameToTable = getSchemaTableNameToTable(tables);
        schemaNameToSchemaTableNames = getSchemaNameToTables(tables);
    }

    private Map<SchemaTableName, KoraliumPrestoTable> getSchemaTableNameToTable(List<KoraliumPrestoTable> tables)
    {
        ImmutableMap.Builder<SchemaTableName, KoraliumPrestoTable> builder = new ImmutableMap.Builder<>();

        for (KoraliumPrestoTable table : tables) {
            builder.put(table.getSchemaTableName(), table);
        }

        return builder.build();
    }

    private Map<String, List<SchemaTableName>> getSchemaNameToTables(List<KoraliumPrestoTable> tables)
    {
        List<String> schemas = getSchemaNames();

        ImmutableMap.Builder<String, List<SchemaTableName>> builder = new ImmutableMap.Builder<>();

        for (String schemaName : schemas) {
            List<SchemaTableName> tableNames = tables
                    .stream()
                    .filter(table -> table.getSchemaName().equals(schemaName))
                    .map(KoraliumPrestoTable::getSchemaTableName)
                    .collect(toImmutableList());

            builder.put(schemaName, tableNames);
        }
        return builder.build();
    }

    @Override
    public List<String> getSchemaNames()
    {
        return ImmutableList.of(schemaName);
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
        KoraliumPrestoTable table = schemaTableNameToTable.get(schemaTableName);
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
        KoraliumPrestoTable table = schemaTableNameToTable.get(schemaTableName);

        ImmutableMap.Builder<String, ColumnHandle> columnHandles = ImmutableMap.builder();
        for (KoraliumPrestoColumn columnHandle : table.getColumns()) {
            columnHandles.put(columnHandle.getColumnName().toLowerCase(ENGLISH), columnHandle);
        }

        return columnHandles.build();
    }

    @Override
    public KoraliumTableIndex getTableIndex(String key)
    {
        return null;
    }
}
