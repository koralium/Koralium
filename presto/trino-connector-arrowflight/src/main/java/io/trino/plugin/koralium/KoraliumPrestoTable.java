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

import io.trino.spi.connector.ConnectorTableMetadata;
import io.trino.spi.connector.SchemaTableName;
import io.trino.spi.predicate.TupleDomain;

import java.util.List;
import java.util.Optional;
import java.util.OptionalLong;

public class KoraliumPrestoTable
{
    private final SchemaTableName schemaTableName;
    private final ConnectorTableMetadata connectorTableMetadata;
    private final List<KoraliumPrestoColumn> columns;

    public KoraliumPrestoTable(
            SchemaTableName schemaTableName,
            ConnectorTableMetadata connectorTableMetadata,
            List<KoraliumPrestoColumn> columns)
    {
        this.schemaTableName = schemaTableName;
        this.connectorTableMetadata = connectorTableMetadata;
        this.columns = columns;
    }

    public KoraliumTableHandle getTableHandle()
    {
        return new KoraliumTableHandle(schemaTableName.getSchemaName(), schemaTableName.getTableName(), TupleDomain.all(), Optional.empty(), 0, OptionalLong.empty(), Optional.empty());
    }

    public SchemaTableName getSchemaTableName()
    {
        return schemaTableName;
    }

    public ConnectorTableMetadata getConnectorTableMetadata()
    {
        return connectorTableMetadata;
    }

    public String getSchemaName()
    {
        return schemaTableName.getSchemaName();
    }

    public List<KoraliumPrestoColumn> getColumns()
    {
        return columns;
    }
}
