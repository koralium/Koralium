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
package io.prestosql.plugin.koralium.cache;

import io.prestosql.plugin.koralium.KoraliumConfig;
import io.trino.spi.NodeManager;

import javax.inject.Inject;

public class QueryCacheFactory
{
    private final QueryCache queryCache;
    private final QueryCacheSplitManager queryCacheSplitManager;

    @Inject
    public QueryCacheFactory(KoraliumConfig config, NodeManager nodeManager)
    {
        if (!config.isCacheEnabled()) {
            queryCache = new DisabledQueryCache();
            queryCacheSplitManager = new DisabledCacheSplitManager();
        }
        else {
            queryCache = new RedisCoordinatorQueryCache(
                    config.getCacheRedisUrl(),
                    nodeManager.getCurrentNode().getHostAndPort().toString(),
                    config.getCacheExpireTime(),
                    config.getCacheMaxSizeInBytes());

            queryCacheSplitManager = new RedisCoordinatorCacheSplitManager(config.getCacheRedisUrl());
        }
    }

    public QueryCache getCache()
    {
        return queryCache;
    }

    public QueryCacheSplitManager getCacheSplitManager()
    {
        return queryCacheSplitManager;
    }
}
