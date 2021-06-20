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

import io.trino.Session;
import io.trino.client.Column;
import io.trino.client.QueryData;
import io.trino.client.QueryStatusInfo;
import io.trino.server.testing.TestingTrinoServer;
import io.trino.spi.type.Type;
import io.trino.spi.type.VarcharType;
import io.trino.testing.AbstractTestingTrinoClient;
import io.trino.testing.ResultsSession;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.concurrent.atomic.AtomicReference;
import java.util.stream.Collectors;

import static io.trino.spi.type.BigintType.BIGINT;
import static io.trino.spi.type.BooleanType.BOOLEAN;
import static io.trino.spi.type.DateType.DATE;
import static io.trino.spi.type.DoubleType.DOUBLE;
import static io.trino.spi.type.IntegerType.INTEGER;

public class DataLoader
        extends AbstractTestingTrinoClient<Void>
{
    private final String tableName;
    private final String schemaName;
    private final CsvOutput csvOutput;

    public DataLoader(
            TestingTrinoServer prestoServer,
            Session defaultSession,
            String tableName,
            String schemaName,
            CsvOutput csvOutput)
    {
        super(prestoServer, defaultSession);
        this.tableName = tableName;
        this.schemaName = schemaName;
        this.csvOutput = csvOutput;
    }

    @Override
    protected ResultsSession<Void> getResultSession(Session session)
    {
        return new LoadingSession();
    }

    private class LoadingSession
            implements ResultsSession<Void>
    {
        private final AtomicReference<List<Type>> types = new AtomicReference<>();

        private LoadingSession() {}

        private String escapeSpecialCharacters(String data)
        {
            String escapedData = data.replaceAll("\\R", " ");
            if (data.contains(",") || data.contains("\"") || data.contains("'")) {
                data = data.replace("\"", "\"\"");
                escapedData = "\"" + data + "\"";
            }
            return escapedData;
        }

        @Override
        public void addResults(QueryStatusInfo statusInfo, QueryData data)
        {
            if (csvOutput.header == null && statusInfo.getColumns() != null) {
                String output = "";

                csvOutput.header = statusInfo.getColumns()
                        .stream()
                        .map(Column::getName)
                        .map(this::escapeSpecialCharacters)
                        .collect(Collectors.joining(","));
            }

            if (data.getData() == null) {
                return;
            }

            for (List<Object> fields : data.getData()) {
                csvOutput.addRow(fields.stream()
                        .map(Object::toString)
                        .map(this::escapeSpecialCharacters)
                        .collect(Collectors.joining(",")));
            }
        }

        @Override
        public Void build(Map<String, String> setSessionProperties, Set<String> resetSessionProperties)
        {
            return null;
        }

        private Object convertValue(Object value, Type type) throws ParseException
        {
            if (value == null) {
                return null;
            }

            if (type == DATE && value instanceof String) {
                return new SimpleDateFormat("yyyy-MM-dd").parse((String) value);
            }
            if (type == BOOLEAN || type == DATE || type instanceof VarcharType) {
                return value;
            }
            if (type == BIGINT) {
                return ((Number) value).longValue();
            }
            if (type == INTEGER) {
                return ((Number) value).intValue();
            }
            if (type == DOUBLE) {
                return ((Number) value).doubleValue();
            }
            throw new IllegalArgumentException("Unhandled type: " + type);
        }
    }
}
