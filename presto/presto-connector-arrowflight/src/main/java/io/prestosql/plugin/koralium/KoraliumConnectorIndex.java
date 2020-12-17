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
import io.prestosql.spi.connector.ConnectorIndex;
import io.prestosql.spi.connector.ConnectorPageSource;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.connector.RecordSet;

import java.util.List;

public class KoraliumConnectorIndex
        implements ConnectorIndex
{
    private final ConnectorSession session;
    private final PrestoKoraliumClient client;
    private final KoraliumIndexHandle indexHandle;
    private final List<KoraliumColumnHandle> lookupSchema;
    private final List<KoraliumPrestoColumn> outputSchema;

    public KoraliumConnectorIndex(
            ConnectorSession session,
            PrestoKoraliumClient client,
            KoraliumIndexHandle indexHandle,
            List<KoraliumColumnHandle> lookupSchema,
            List<KoraliumPrestoColumn> outputSchema)
    {
        this.session = session;
        this.client = client;
        this.indexHandle = indexHandle;
        this.lookupSchema = lookupSchema;
        this.outputSchema = outputSchema;
    }

    @Override
    public ConnectorPageSource lookup(RecordSet recordSet)
    {
        return new KoraliumIndexPageSource(session, lookupSchema, outputSchema, client, indexHandle, recordSet);
    }
}
