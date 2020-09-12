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
package io.prestosql.plugin.grpc.client;

import io.prestosql.plugin.grpc.GrpcTableHandle;
import io.prestosql.plugin.grpc.GrpcTableIndex;
import io.prestosql.spi.connector.ColumnHandle;
import io.prestosql.spi.connector.ConnectorTableMetadata;
import io.prestosql.spi.connector.SchemaTableName;

import java.util.List;
import java.util.Map;

public interface GrpcMetadataClient
{
    List<String> getSchemaNames();

    GrpcTableHandle getTableHandle(SchemaTableName schemaTableName);

    ConnectorTableMetadata getTableMetadata(SchemaTableName schemaTableName);

    List<SchemaTableName> getSchemaTableNames(String schema);

    Map<String, ColumnHandle> getColumnHandles(SchemaTableName schemaTableName);

    GrpcTableIndex getTableIndex(String key);
}
