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
package io.prestosql.plugin.koralium.client;

import io.prestosql.plugin.koralium.KoraliumConfig;
import org.apache.arrow.flight.FlightClient;
import org.apache.arrow.flight.FlightDescriptor;
import org.apache.arrow.flight.FlightInfo;
import org.apache.arrow.flight.FlightStream;
import org.apache.arrow.flight.Location;
import org.apache.arrow.flight.Ticket;
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
        FlightInfo result = flightClient.getInfo(FlightDescriptor.command(command.getBytes(StandardCharsets.UTF_8)));
        headerFactory.clearHeaders();
        return result;
    }

    public FlightStream GetStream(byte[] ticket, Map<String, String> headers)
    {
        if (headers != null) {
            headerFactory.setHeaders(headers);
        }
        FlightStream stream = flightClient.getStream(new Ticket(ticket));
        headerFactory.clearHeaders();
        return stream;
    }

    public void close() throws InterruptedException
    {
        flightClient.close();
        allocator.close();
    }
}
