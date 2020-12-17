package io.prestosql.plugin.koralium;

import io.prestosql.spi.connector.ConnectorTableMetadata;
import io.prestosql.spi.connector.SchemaTableName;
import io.prestosql.spi.predicate.TupleDomain;

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
