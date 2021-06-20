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

import io.trino.spi.Page;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class RedisCoordinatorCacheEntry
        implements QueryCacheEntry
{
    private final String query;
    private long size;
    private LocalDateTime lastUsed;
    private final List<Page> pages;
    private LocalDateTime expireAt;
    private long expirationTime;

    public RedisCoordinatorCacheEntry(String query, long expirationTime)
    {
        this.query = query;
        pages = new ArrayList<>();
        setExpirationTime(expirationTime);
    }

    @Override
    public long getSize()
    {
        return size;
    }

    @Override
    public void updateLastUsed()
    {
        lastUsed = LocalDateTime.now();
    }

    @Override
    public void addPage(Page page)
    {
        this.size += page.getSizeInBytes();
        pages.add(page);
    }

    @Override
    public Iterator<Page> getIterator()
    {
        return pages.iterator();
    }

    @Override
    public LocalDateTime getLastUsed()
    {
        return lastUsed;
    }

    @Override
    public LocalDateTime getExpireAt()
    {
        return expireAt;
    }

    @Override
    public long getExpirationTime()
    {
        return expirationTime;
    }

    @Override
    public void setExpirationTime(long expirationTimeInSeconds)
    {
        this.expireAt = LocalDateTime.now().plusSeconds(expirationTimeInSeconds);
        expirationTime = expirationTimeInSeconds;
    }

    @Override
    public String getQuery()
    {
        return query;
    }
}
