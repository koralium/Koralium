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

import io.grpc.Channel;
import io.grpc.netty.shaded.io.grpc.netty.NettyServerBuilder;
import io.prestosql.plugin.koralium.GrpcConfig;
import io.prestosql.plugin.koralium.GrpcTableHandle;
import io.prestosql.plugin.koralium.GrpcTableIndex;
import io.prestosql.spi.connector.ColumnHandle;
import io.prestosql.spi.connector.ConnectorTableMetadata;
import io.prestosql.spi.connector.SchemaTableName;

import javax.inject.Inject;

import java.util.List;
import java.util.Map;

public class PrestoGrpcClient
        implements GrpcMetadataClient
{
    private final GrpcConfig config;
    private final Channel channel;
    private GrpcMetadataCache cache;

    @Inject
    public PrestoGrpcClient(GrpcConfig config)
    {
        this.config = config;
        this.channel = config.getChannel();

        //Just using a method from the library to use it
        NettyServerBuilder builder = NettyServerBuilder.forPort(1111);
    }

    public String getUrl()
    {
        return config.getUrl();
    }

    public Channel getChannel()
    {
        return channel;
    }

    private void loadCache()
    {
        if (cache == null) {
            reloadCache();
        }
    }

    private void reloadCache()
    {
        this.cache = new GrpcMetadataCache(channel);
    }

    @Override
    public List<String> getSchemaNames()
    {
        loadCache();
        return cache.getSchemaNames();
    }

    @Override
    public GrpcTableHandle getTableHandle(SchemaTableName schemaTableName)
    {
        loadCache();
        return cache.getTableHandle(schemaTableName);
    }

    @Override
    public ConnectorTableMetadata getTableMetadata(SchemaTableName schemaTableName)
    {
        loadCache();
        return cache.getTableMetadata(schemaTableName);
    }

    @Override
    public List<SchemaTableName> getSchemaTableNames(String schema)
    {
        loadCache();
        return cache.getSchemaTableNames(schema);
    }

    @Override
    public Map<String, ColumnHandle> getColumnHandles(SchemaTableName schemaTableName)
    {
        loadCache();
        return cache.getColumnHandles(schemaTableName);
    }

    @Override
    public GrpcTableIndex getTableIndex(String key)
    {
        loadCache();
        return cache.getTableIndex(key);
    }
}
