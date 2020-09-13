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
import io.prestosql.spi.connector.ConnectorIndex;
import io.prestosql.spi.connector.ConnectorIndexHandle;
import io.prestosql.spi.connector.ConnectorIndexProvider;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.connector.ConnectorTransactionHandle;

import javax.inject.Inject;

import java.util.List;

import static com.google.common.collect.ImmutableList.toImmutableList;

public class KoraliumIndexProvider
        implements ConnectorIndexProvider
{
    private final PrestoKoraliumClient client;

    @Inject
    public KoraliumIndexProvider(
            PrestoKoraliumClient client)
    {
        this.client = client;
    }

    @Override
    public ConnectorIndex getIndex(
            ConnectorTransactionHandle transactionHandle,
            ConnectorSession session,
            ConnectorIndexHandle indexHandle,
            List<ColumnHandle> lookupSchema,
            List<ColumnHandle> outputSchema)
    {
        KoraliumIndexHandle koraliumIndexHandle = (KoraliumIndexHandle) indexHandle;
        List<KoraliumColumnHandle> lookupColumns = lookupSchema.stream()
                .map(KoraliumColumnHandle.class::cast)
                .collect(toImmutableList());

        List<KoraliumColumnHandle> outputColumns = outputSchema.stream()
                .map(KoraliumColumnHandle.class::cast)
                .collect(toImmutableList());

        return new KoraliumConnectorIndex(session, client, koraliumIndexHandle, lookupColumns, outputColumns);
    }
}
