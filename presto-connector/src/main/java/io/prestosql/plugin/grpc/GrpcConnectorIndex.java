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
package io.prestosql.plugin.grpc;

import io.prestosql.plugin.grpc.client.PrestoGrpcClient;
import io.prestosql.spi.connector.ConnectorIndex;
import io.prestosql.spi.connector.ConnectorPageSource;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.connector.RecordSet;

import java.util.List;

public class GrpcConnectorIndex
        implements ConnectorIndex
{
    private final ConnectorSession session;
    private final PrestoGrpcClient client;
    private final GrpcIndexHandle indexHandle;
    private final List<GrpcColumnHandle> lookupSchema;
    private final List<GrpcColumnHandle> outputSchema;

    public GrpcConnectorIndex(
            ConnectorSession session,
            PrestoGrpcClient client,
            GrpcIndexHandle indexHandle,
            List<GrpcColumnHandle> lookupSchema,
            List<GrpcColumnHandle> outputSchema)
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
        return new GrpcIndexPageSource(session, lookupSchema, outputSchema, client, indexHandle, recordSet);
    }
}
