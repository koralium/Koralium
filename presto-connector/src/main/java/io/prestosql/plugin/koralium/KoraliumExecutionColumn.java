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

import io.prestosql.spi.type.Type;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

import static com.google.common.collect.ImmutableList.toImmutableList;

//This class is only used during query execution
public class GrpcExecutionColumn
{
    private final GrpcType grpcType;
    private final int columnId;
    private List<GrpcExecutionColumn> children;
    private final Type prestoType;
    //Id that is used to locate the correct block builder
    private final int returnId;

    public GrpcExecutionColumn(GrpcType grpcType, int columnId, int returnId, Type prestoType)
    {
        this.grpcType = grpcType;
        this.columnId = columnId;
        this.children = new ArrayList<>();
        this.returnId = returnId;
        this.prestoType = prestoType;
    }

    public void addChild(GrpcExecutionColumn child)
    {
        children.add(child);
    }

    public int getColumnId()
    {
        return columnId;
    }

    public boolean isObject()
    {
        return grpcType.equals(GrpcType.OBJECT);
    }

    public boolean isArray()
    {
        return grpcType.equals(GrpcType.ARRAY);
    }

    public List<GrpcExecutionColumn> getChildren()
    {
        return children;
    }

    public GrpcType getGrpcType()
    {
        return grpcType;
    }

    public int getReturnId()
    {
        return returnId;
    }

    public Type getPrestoType()
    {
        return prestoType;
    }

    public void finish()
    {
        children.forEach(GrpcExecutionColumn::finish);

        //Sort all the children
        children = children.stream()
                .sorted(Comparator.comparing(GrpcExecutionColumn::getReturnId, Integer::compareTo))
                .collect(toImmutableList());
    }
}
