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

import io.trino.plugin.koralium.KoraliumConfig;
import io.trino.plugin.koralium.KoraliumTableHandle;
import io.trino.plugin.koralium.KoraliumTableIndex;
import io.trino.spi.connector.ColumnHandle;
import io.trino.spi.connector.ConnectorTableMetadata;
import io.trino.spi.connector.SchemaTableName;

import javax.inject.Inject;

import java.util.List;
import java.util.Map;

public class PrestoKoraliumMetadataClient
        implements KoraliumMetadataClient
{
    private final KoraliumConfig config;
    private KoraliumMetadataClient cache;

    @Inject
    public PrestoKoraliumMetadataClient(KoraliumConfig config)
    {
        this.config = config;
    }

    private void loadCache()
    {
        if (cache == null) {
            reloadCache();
        }
    }

    private void reloadCache()
    {
        this.cache = new KoraliumPrestoMetadataCache(config);
    }

    @Override
    public List<String> getSchemaNames()
    {
        loadCache();
        return cache.getSchemaNames();
    }

    @Override
    public KoraliumTableHandle getTableHandle(SchemaTableName schemaTableName)
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
    public KoraliumTableIndex getTableIndex(String key)
    {
        loadCache();
        return cache.getTableIndex(key);
    }
}
