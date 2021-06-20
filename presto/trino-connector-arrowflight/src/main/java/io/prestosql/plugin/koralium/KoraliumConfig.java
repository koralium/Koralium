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

import io.airlift.configuration.Config;
import io.trino.spi.HostAddress;

import javax.validation.constraints.NotNull;

public class KoraliumConfig
{
    private String url;
    private boolean cacheEnabled;
    private HostAddress cacheRedisUrl;
    private long cacheExpireTime = 60;
    private long cacheMaxSizeInBytes = 1024 * 1024 * 100;

    @NotNull
    public String getUrl()
    {
        return url;
    }

    public boolean isCacheEnabled()
    {
        return cacheEnabled;
    }

    public HostAddress getCacheRedisUrl()
    {
        return cacheRedisUrl;
    }

    public long getCacheExpireTime()
    {
        return cacheExpireTime;
    }

    public long getCacheMaxSizeInBytes()
    {
        return cacheMaxSizeInBytes;
    }

    @Config("koralium.url")
    public KoraliumConfig setUrl(String url)
    {
        this.url = url;
        return this;
    }

    @Config("koralium.cache.enabled")
    public KoraliumConfig setCacheEnabled(boolean value)
    {
        this.cacheEnabled = value;
        return this;
    }

    @Config("koralium.cache.redisUrl")
    public KoraliumConfig setCacheRedisUrl(String url)
    {
        this.cacheRedisUrl = HostAddress.fromString(url);
        return this;
    }

    @Config("koralium.cache.expireTime")
    public KoraliumConfig setCacheExpireTime(long cacheExpireTime)
    {
        this.cacheExpireTime = cacheExpireTime;
        return this;
    }

    @Config("koralium.cache.maxSizeInBytes")
    public KoraliumConfig setCacheMaxSizeInBytes(long maxSize)
    {
        this.cacheMaxSizeInBytes = maxSize;
        return this;
    }
}
