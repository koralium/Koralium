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

import com.fasterxml.jackson.annotation.JsonCreator;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.google.common.collect.ImmutableList;
import io.trino.spi.HostAddress;
import io.trino.spi.connector.ConnectorSplit;

import java.net.URI;
import java.util.List;
import java.util.stream.Collectors;

public class KoraliumSplit
        implements ConnectorSplit
{
    private final byte[] ticket;
    private final List<URI> uriAddresses;
    private final List<HostAddress> remoteAddresses;
    private final boolean isCount;
    private final HostAddress cacheUrl;

    @JsonCreator
    public KoraliumSplit(
            @JsonProperty("ticket") byte[] ticket,
            @JsonProperty("uriAddresses") List<URI> uriAddresses,
            @JsonProperty("isCount") boolean isCount,
            @JsonProperty("cacheNode") HostAddress cacheUrl)
    {
        this.ticket = ticket;
        this.uriAddresses = uriAddresses;

        if (cacheUrl != null) {
            this.remoteAddresses = ImmutableList.of(cacheUrl);
        }
        else {
            this.remoteAddresses = uriAddresses.stream().map(HostAddress::fromUri).collect(Collectors.toList());
        }

        this.isCount = isCount;
        this.cacheUrl = cacheUrl;
    }

    @JsonProperty
    public byte[] getTicket()
    {
        return ticket;
    }

    @JsonProperty
    public List<URI> getUriAddresses()
    {
        return uriAddresses;
    }

    @JsonProperty("isCount")
    public boolean isCount()
    {
        return isCount;
    }

    @JsonProperty("cacheNode")
    public HostAddress getCacheUrl()
    {
        return cacheUrl;
    }

    @Override
    public boolean isRemotelyAccessible()
    {
        return true;
    }

    @Override
    public List<HostAddress> getAddresses()
    {
        return remoteAddresses;
    }

    @Override
    public Object getInfo()
    {
        return this;
    }
}
