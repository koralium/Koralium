package io.prestosql.plugin.koralium;

import com.fasterxml.jackson.annotation.JsonCreator;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.google.common.collect.ImmutableList;
import io.prestosql.spi.HostAddress;
import io.prestosql.spi.connector.ConnectorSplit;

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

    @JsonCreator
    public KoraliumSplit(
            @JsonProperty("ticket") byte[] ticket,
            @JsonProperty("uriAddresses") List<URI> uriAddresses,
            @JsonProperty("isCount") boolean isCount)
    {
        this.ticket = ticket;
        this.uriAddresses = uriAddresses;
        this.remoteAddresses = uriAddresses.stream().map(HostAddress::fromUri).collect(Collectors.toList());
        this.isCount = isCount;
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

    @Override
    public boolean isRemotelyAccessible() {
        return true;
    }

    @Override
    public List<HostAddress> getAddresses() {
        return remoteAddresses;
    }

    @Override
    public Object getInfo() {
        return this;
    }
}
