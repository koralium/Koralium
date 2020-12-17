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

import com.google.common.collect.ImmutableList;
import com.google.common.collect.ImmutableMap;
import io.prestosql.plugin.koralium.client.FilterExtractor;
import io.prestosql.plugin.koralium.client.KoraliumClient;
import io.prestosql.plugin.koralium.client.QueryBuilder;
import io.prestosql.spi.HostAddress;
import io.prestosql.spi.connector.*;
import org.apache.arrow.flight.FlightEndpoint;
import org.apache.arrow.flight.FlightInfo;
import org.apache.arrow.flight.Location;

import javax.inject.Inject;

import java.net.URI;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Map;

import static java.util.Objects.requireNonNull;

public class KoraliumSplitManager
        implements ConnectorSplitManager
{
    private final KoraliumClient client;

    @Inject
    public KoraliumSplitManager(KoraliumClient client)
    {
        this.client = requireNonNull(client, "client is null");
    }

    @Override
    public ConnectorSplitSource getSplits(
            ConnectorTransactionHandle transaction,
            ConnectorSession session,
            ConnectorTableHandle connectorTableHandle,
            SplitSchedulingStrategy splitSchedulingStrategy)
    {
        String authToken = session.getIdentity().getExtraCredentials().get("auth_token");

        KoraliumTableHandle tableHandle = (KoraliumTableHandle)connectorTableHandle;

        QueryBuilder queryBuilder = new QueryBuilder();
        String filter = FilterExtractor.getFilter(session, tableHandle.getConstraint().transform(KoraliumPrestoColumn.class::cast));

        String query = "";

        boolean isCount = false;
        if (tableHandle.getDesiredColumns().isPresent() && tableHandle.getDesiredColumns().get().size() == 0) {
            query = queryBuilder.buildCountQuery(tableHandle.getTableName(), filter);
            isCount = true;
        }
        else {
            query = queryBuilder.buildQuery(tableHandle.getDesiredColumns(), tableHandle.getTableName(), filter, tableHandle.getSortOrder(), tableHandle.getLimit());
        }

        Map<String, String> headers = null;

        if (authToken != null) {
            headers = ImmutableMap.of("Authorization", "Bearer " + authToken);
        }

        FlightInfo flightInfo = this.client.getFlightInfo(query, headers);

        List<ConnectorSplit> splits = new ArrayList<>();
        for (FlightEndpoint endpoint : flightInfo.getEndpoints()) {
            ImmutableList.Builder<URI> locationBuilder = new ImmutableList.Builder<>();
            List<Location> locations = endpoint.getLocations();

            if (locations.size() == 0) {
                locationBuilder.add(client.getUri());
            }
            else {
                for (Location location : locations) {
                    locationBuilder.add(location.getUri());
                }
            }

            splits.add(new KoraliumSplit(endpoint.getTicket().getBytes(), locationBuilder.build(), isCount));

        }

        //Collections.shuffle(splits);
        return new FixedSplitSource(splits);
    }
}
