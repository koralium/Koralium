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

import io.prestosql.spi.Page;
import io.prestosql.spi.connector.ConnectorPageSource;

import java.io.IOException;
import java.util.Iterator;

public class KoraliumPageSourceCache
        implements ConnectorPageSource
{
    private final Iterator<Page> iterator;
    private final long readStart;

    public KoraliumPageSourceCache(Iterator<Page> iterator)
    {
        this.iterator = iterator;
        readStart = System.nanoTime();
    }

    @Override
    public long getCompletedBytes()
    {
        return 0;
    }

    @Override
    public long getReadTimeNanos()
    {
        return System.nanoTime() - readStart;
    }

    @Override
    public boolean isFinished()
    {
        return !iterator.hasNext();
    }

    @Override
    public Page getNextPage()
    {
        if (!iterator.hasNext()) {
            return null;
        }
        return iterator.next();
    }

    @Override
    public long getSystemMemoryUsage()
    {
        return 0;
    }

    @Override
    public void close() throws IOException
    {
        //NOP
    }
}
