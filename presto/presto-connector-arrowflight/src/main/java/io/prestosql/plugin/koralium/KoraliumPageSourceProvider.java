package io.prestosql.plugin.koralium;

import io.prestosql.spi.connector.*;

import java.util.List;

import static com.google.common.collect.ImmutableList.toImmutableList;

public class KoraliumPageSourceProvider
        implements ConnectorPageSourceProvider
{
    @Override
    public ConnectorPageSource createPageSource(
            ConnectorTransactionHandle transaction,
            ConnectorSession session,
            ConnectorSplit split,
            ConnectorTableHandle table,
            List<ColumnHandle> columns,
            DynamicFilter dynamicFilter)
    {
        List<KoraliumPrestoColumn> columnHandles = columns.stream()
                .map(KoraliumPrestoColumn.class::cast)
                .collect(toImmutableList());

        KoraliumSplit koraliumSplit = (KoraliumSplit)split;

        return new KoraliumPageSource(koraliumSplit, columnHandles, session);
    }
}
