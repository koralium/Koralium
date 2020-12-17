package io.prestosql.plugin.koralium.client;

import io.prestosql.plugin.koralium.KoraliumConfig;
import org.apache.arrow.flight.*;
import org.apache.arrow.memory.BufferAllocator;
import org.apache.arrow.memory.RootAllocator;

import javax.inject.Inject;
import java.net.URI;
import java.nio.charset.StandardCharsets;
import java.util.Map;

public class KoraliumClient
{
    private final Location location;
    private BufferAllocator allocator;
    FlightClient flightClient;
    private final FlightHeaderFactory headerFactory;

    @Inject
    public KoraliumClient(KoraliumConfig config)
    {
        allocator = new RootAllocator(Long.MAX_VALUE);

        String[] urlSplit = config.getUrl().split(":");

        String host = urlSplit[0];
        int port = 80;
        if (urlSplit.length > 1) {
            port = Integer.parseInt(urlSplit[1]);
        }
        this.headerFactory = new FlightHeaderFactory();
        this.location = Location.forGrpcInsecure(host, port);
        flightClient = FlightClient.builder(allocator, location).intercept(headerFactory).build();
    }

    public KoraliumClient(URI uri)
    {
        allocator = new RootAllocator(Long.MAX_VALUE);

        this.headerFactory = new FlightHeaderFactory();
        this.location = new Location(uri);
        flightClient = FlightClient.builder(allocator, location).intercept(headerFactory).build();
    }

    public URI getUri()
    {
        return location.getUri();
    }

    public FlightInfo getFlightInfo(String command, Map<String, String> headers)
    {
        if (headers != null) {
            headerFactory.setHeaders(headers);
        }
        return flightClient.getInfo(FlightDescriptor.command(command.getBytes(StandardCharsets.UTF_8)));
    }

    public FlightStream GetStream(byte[] ticket, Map<String, String> headers)
    {
        if (headers != null) {
            headerFactory.setHeaders(headers);
        }
         return flightClient.getStream(new Ticket(ticket));
    }
}
