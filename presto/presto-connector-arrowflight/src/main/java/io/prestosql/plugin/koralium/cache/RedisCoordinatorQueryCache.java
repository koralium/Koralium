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

import io.prestosql.spi.HostAddress;
import redis.clients.jedis.Jedis;
import redis.clients.jedis.JedisPool;
import redis.clients.jedis.JedisPoolConfig;

import java.time.LocalDateTime;
import java.util.HashMap;
import java.util.Map;

import static java.util.Objects.requireNonNull;

//Uses redis as a coordinator for the cache
public class RedisCoordinatorQueryCache
        implements QueryCache
{
    private long cacheMaxSize;
    private long totalSize;
    private final Map<String, QueryCacheEntry> entries;

    private final JedisPool jedisPool;
    private final String nodeAddress;
    private final long defaultExpireTime;

    public RedisCoordinatorQueryCache(
            HostAddress redisUrl,
            String nodeAddress,
            long defaultExpireTime,
            long cacheMaxSize)
    {
        requireNonNull(redisUrl, "redisUrl was null");

        JedisPoolConfig poolConfig = new JedisPoolConfig();
        poolConfig.setMaxTotal(128);
        jedisPool = new JedisPool(poolConfig, redisUrl.getHostText(), redisUrl.getPort());
        entries = new HashMap<>();
        this.nodeAddress = nodeAddress;
        this.defaultExpireTime = defaultExpireTime;
        this.cacheMaxSize = cacheMaxSize;
    }

    @Override
    public boolean containsQuery(String query)
    {
        return getEntry(query) != null;
    }

    @Override
    public QueryCacheEntry newEntry(String query)
    {
        return new RedisCoordinatorCacheEntry(query, defaultExpireTime);
    }

    private QueryCacheEntry getEntry(String query)
    {
        QueryCacheEntry block = entries.get(query);

        if (block == null) {
            return null;
        }

        LocalDateTime currentDate = LocalDateTime.now();
        //Check if the entry has already expired
        if (block.getExpireAt().compareTo(currentDate) < 0) {
            entries.remove(query);
            return null;
        }
        return block;
    }

    @Override
    public QueryCacheEntry get(String query)
    {
        QueryCacheEntry block = getEntry(query);

        if (block != null) {
            block.updateLastUsed();
        }

        return block;
    }

    @Override
    public void add(QueryCacheEntry entry)
    {
        if (entry.getSize() > cacheMaxSize) {
            return;
        }
        //Check if the total size will be met with the new entry
        if ((entry.getSize() + totalSize) > cacheMaxSize) {
            clearLeastUsed();
        }

        entries.put(entry.getQuery(), entry);
        totalSize += entry.getSize();

        long expirationTime = entry.getExpirationTime();

        Jedis jedis = null;
        //Add to redis that this node contains this query
        try {
            jedis = jedisPool.getResource();
            jedis.set(entry.getQuery(), nodeAddress);
            jedis.expire(entry.getQuery(), (int) expirationTime);
        }
        catch (Exception ex) {
            //NOP
        }
        finally {
            if (jedis != null) {
                jedis.close();
            }
        }
    }

    private void clearLeastUsed()
    {
        LocalDateTime oldestEntryTime = null;
        QueryCacheEntry block = null;
        for (QueryCacheEntry entry : entries.values()) {
            if (oldestEntryTime == null) {
                oldestEntryTime = entry.getLastUsed();
                block = entry;
                continue;
            }
            if (oldestEntryTime.compareTo(entry.getLastUsed()) > 0) {
                oldestEntryTime = entry.getLastUsed();
                block = entry;
            }
        }

        //If no block could be found, the cache must be emtpy, reset the size.
        if (block == null) {
            totalSize = 0;
            return;
        }

        entries.remove(block.getQuery());

        //Get the entry in redis
        Jedis jedis = null;
        try {
            jedis = jedisPool.getResource();
            String url = jedis.get(block.getQuery());
            //If it is pointing to this node, remove cache entry from redis as well
            if (nodeAddress.equals(url)) {
                jedis.del(block.getQuery());
            }
        }
        catch (Exception e) {
            //NOP
        }
        finally {
            if (jedis != null) {
                jedis.close();
            }
        }

        totalSize -= block.getSize();
    }
}
