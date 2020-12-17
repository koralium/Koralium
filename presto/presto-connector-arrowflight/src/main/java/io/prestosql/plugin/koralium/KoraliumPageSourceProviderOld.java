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

import io.prestosql.plugin.koralium.client.PrestoKoraliumClient;
import io.prestosql.spi.connector.ColumnHandle;
import io.prestosql.spi.connector.ConnectorPageSource;
import io.prestosql.spi.connector.ConnectorPageSourceProvider;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.connector.ConnectorSplit;
import io.prestosql.spi.connector.ConnectorTableHandle;
import io.prestosql.spi.connector.ConnectorTransactionHandle;
import io.prestosql.spi.connector.DynamicFilter;
import io.prestosql.spi.predicate.TupleDomain;

import javax.inject.Inject;

import java.util.List;

import static com.google.common.collect.ImmutableList.toImmutableList;

public class KoraliumPageSourceProviderOld
        implements ConnectorPageSourceProvider
{
    private final PrestoKoraliumClient client;

    @Inject
    public KoraliumPageSourceProviderOld(
            PrestoKoraliumClient client)
    {
        this.client = client;
    }

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

        KoraliumTableHandle tableHandle = (KoraliumTableHandle) table;
        TupleDomain<KoraliumColumnHandle> constraint = tableHandle.getConstraint().transform(KoraliumColumnHandle.class::cast);

        return new KoraliumPageSourceOld(session, columnHandles, client, tableHandle, (KoraliumSplitOld) split, constraint, dynamicFilter);
    }

    //    @Override
//    public ConnectorPageSource createPageSource(
//            ConnectorTransactionHandle transaction,
//            ConnectorSession session,
//            ConnectorSplit split,
//            ConnectorTableHandle table,
//            List<ColumnHandle> columns,
//            TupleDomain<ColumnHandle> dynamicFilter)
//    {
//        List<GrpcColumnHandle> columnHandles = columns.stream()
//                .map(GrpcColumnHandle.class::cast)
//                .collect(toImmutableList());
//
//        GrpcTableHandle tableHandle = (GrpcTableHandle) table;
//        TupleDomain<GrpcColumnHandle> constraint = tableHandle.getConstraint().intersect(dynamicFilter).transform(GrpcColumnHandle.class::cast);
//
//        return new GrpcPageSource(session, columnHandles, client, tableHandle, (GrpcSplit) split, constraint);
//    }
}
