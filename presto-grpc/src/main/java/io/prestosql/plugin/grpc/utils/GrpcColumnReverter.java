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
package io.prestosql.plugin.grpc.utils;

import io.prestosql.plugin.grpc.GrpcColumnHandle;
import io.prestosql.plugin.grpc.GrpcExecutionColumn;
import io.prestosql.plugin.grpc.GrpcType;

import java.util.Comparator;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.stream.Collectors;

import static com.google.common.collect.ImmutableList.toImmutableList;

public final class GrpcColumnReverter
{
    private GrpcColumnReverter()
    {
        //NOOP
    }

    public static List<GrpcExecutionColumn> buildColumnsTree(List<GrpcColumnHandle> columns)
    {
        Map<GrpcColumnHandle, GrpcExecutionColumn> lookup = new HashMap<>();

        for (int i = 0; i < columns.size(); i++) {
            GrpcColumnHandle handle = columns.get(i);
            lookup.put(handle, new GrpcExecutionColumn(handle.getGrpcType(), handle.getColumnId(), i, handle.getPrestoType()));
        }

        Set<GrpcExecutionColumn> outColumns = new HashSet<>();
        Set<GrpcExecutionColumn> outObjects = new HashSet<>();
        Set<GrpcExecutionColumn> outArrays = new HashSet<>();
        for (GrpcColumnHandle handle : columns) {
            GrpcExecutionColumn self = lookup.get(handle);

            if (handle.getGrpcType() == GrpcType.OBJECT) {
                List<GrpcColumnHandle> children = handle.getChildren();

                for (GrpcExecutionColumn child : buildColumnsTree(children)) {
                    self.addChild(child);
                }
                outObjects.add(self);
            }
            else if (handle.getGrpcType() == GrpcType.ARRAY) {
                List<GrpcColumnHandle> children = handle.getChildren();

                for (GrpcExecutionColumn child : buildColumnsTree(children)) {
                    self.addChild(child);
                }
                outArrays.add(self);
            }
            else {
                outColumns.add(self);
            }
        }
        List<GrpcExecutionColumn> sortedList = outColumns.stream()
                .sorted(Comparator.comparing(GrpcExecutionColumn::getReturnId, Integer::compareTo))
                .collect(Collectors.toList());

        sortedList.addAll(outObjects.stream()
                .sorted(Comparator.comparing(GrpcExecutionColumn::getReturnId, Integer::compareTo))
                .collect(toImmutableList()));

        sortedList.addAll(outArrays.stream()
                .sorted(Comparator.comparing(GrpcExecutionColumn::getReturnId, Integer::compareTo))
                .collect(toImmutableList()));

        //Sort the child objects as well
        sortedList.forEach(GrpcExecutionColumn::finish);

        return sortedList;
    }

    private static GrpcExecutionColumn buildColumnsTree(GrpcExecutionColumn child, GrpcColumnHandle handle, Map<GrpcColumnHandle, GrpcExecutionColumn> lookup)
    {
        if (lookup.containsKey(handle)) {
            GrpcExecutionColumn returnColumn = lookup.get(handle);
            returnColumn.addChild(child);
            return returnColumn;
        }

        GrpcExecutionColumn column = new GrpcExecutionColumn(handle.getGrpcType(), handle.getColumnId(), -1, handle.getPrestoType());
        lookup.put(handle, column);
        column.addChild(child);

        if (handle.getParent() != null) {
            GrpcExecutionColumn parent = buildColumnsTree(column, handle.getParent(), lookup);
            return parent;
        }
        return column;
    }
}
