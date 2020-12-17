package io.prestosql.plugin.koralium.client;

import io.grpc.Metadata;
import org.apache.arrow.flight.CallHeaders;
import org.apache.arrow.flight.CallInfo;
import org.apache.arrow.flight.CallStatus;
import org.apache.arrow.flight.FlightClientMiddleware;

import java.util.Map;

public class FlightHeaderFactory
        implements FlightClientMiddleware.Factory
{
    private Map<String, String> headers;

    public void setHeaders(Map<String, String> headers)
    {
        this.headers = headers;
    }

    @Override
    public FlightClientMiddleware onCallStarted(CallInfo callInfo)
    {
        return new FlightClientMiddleware() {
            @Override
            public void onBeforeSendingHeaders(CallHeaders callHeaders) {
                if (headers != null) {
                    headers.forEach(callHeaders::insert);
                    headers = null;
                }
            }

            @Override
            public void onHeadersReceived(CallHeaders callHeaders) {

            }

            @Override
            public void onCallCompleted(CallStatus callStatus) {

            }
        };
    }
}
