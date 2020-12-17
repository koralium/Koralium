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
import io.prestosql.spi.HostAddress;
import io.prestosql.spi.connector.ConnectorSplit;

import java.util.List;

public class KoraliumSplitOld
        implements ConnectorSplit
{
    private String uri;
    private final boolean remotelyAccessible;
    private final List<HostAddress> addresses;

    @JsonCreator
    public KoraliumSplitOld(
            @JsonProperty("uri") String uri)
    {
        this.uri = uri;
        this.remotelyAccessible = true;
        addresses = ImmutableList.of(HostAddress.fromString(uri));
    }

    @JsonProperty
    public String getUri()
    {
        return uri;
    }

    @Override
    public boolean isRemotelyAccessible()
    {
        return remotelyAccessible;
    }

    @Override
    public List<HostAddress> getAddresses()
    {
        return addresses;
    }

    @Override
    public Object getInfo()
    {
        return this;
    }
}
