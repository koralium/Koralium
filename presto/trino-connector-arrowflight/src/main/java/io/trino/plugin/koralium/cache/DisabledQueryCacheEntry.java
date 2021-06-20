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
package io.trino.plugin.koralium.cache;

import io.trino.spi.Page;

import java.time.LocalDateTime;
import java.util.Iterator;

public class DisabledQueryCacheEntry
        implements QueryCacheEntry
{
    @Override
    public long getSize()
    {
        return 0;
    }

    @Override
    public void updateLastUsed()
    {
        //Do nothing
    }

    @Override
    public void addPage(Page page)
    {
        //Do nothing
    }

    @Override
    public Iterator<Page> getIterator()
    {
        return null;
    }

    @Override
    public LocalDateTime getLastUsed()
    {
        return null;
    }

    @Override
    public LocalDateTime getExpireAt()
    {
        return LocalDateTime.now();
    }

    @Override
    public long getExpirationTime()
    {
        return 0;
    }

    @Override
    public void setExpirationTime(long expirationTimeInSeconds)
    {
        //NOP
    }

    @Override
    public String getQuery()
    {
        return null;
    }
}
