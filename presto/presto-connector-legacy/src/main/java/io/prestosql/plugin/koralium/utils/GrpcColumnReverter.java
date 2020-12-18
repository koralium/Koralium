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
package io.prestosql.plugin.koralium.utils;

import io.prestosql.plugin.koralium.KoraliumExecutionColumn;
import io.prestosql.plugin.koralium.KoraliumType;
import io.prestosql.plugin.koralium.Presto;

import java.util.ArrayList;
import java.util.List;

public final class GrpcColumnReverter
{
    private GrpcColumnReverter()
    {
        //NOOP
    }

    public static List<KoraliumExecutionColumn> BuildExecutionColumns(List<Presto.ColumnMetadata> columns)
    {
        List<KoraliumExecutionColumn> output = new ArrayList<>();
        for (int i = 0; i < columns.size(); i++) {
            Presto.ColumnMetadata column = columns.get(i);

            KoraliumType type = KoraliumType.valueOf(column.getType().getNumber());
            KoraliumExecutionColumn executionColumn = new KoraliumExecutionColumn(type, column.getColumnId(), i, KoraliumType.CreatePrestoType(column));

            List<KoraliumExecutionColumn> children = BuildExecutionColumns(column.getSubColumnsList());

            for (KoraliumExecutionColumn child : children) {
                executionColumn.addChild(child);
            }
            output.add(executionColumn);
        }
        return output;
    }
}
