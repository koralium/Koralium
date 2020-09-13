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
public class KoraliumExecutionColumn
{
    private final KoraliumType koraliumType;
    private final int columnId;
    private List<KoraliumExecutionColumn> children;
    private final Type prestoType;
    //Id that is used to locate the correct block builder
    private final int returnId;

    public KoraliumExecutionColumn(KoraliumType koraliumType, int columnId, int returnId, Type prestoType)
    {
        this.koraliumType = koraliumType;
        this.columnId = columnId;
        this.children = new ArrayList<>();
        this.returnId = returnId;
        this.prestoType = prestoType;
    }

    public void addChild(KoraliumExecutionColumn child)
    {
        children.add(child);
    }

    public int getColumnId()
    {
        return columnId;
    }

    public boolean isObject()
    {
        return koraliumType.equals(KoraliumType.OBJECT);
    }

    public boolean isArray()
    {
        return koraliumType.equals(KoraliumType.ARRAY);
    }

    public List<KoraliumExecutionColumn> getChildren()
    {
        return children;
    }

    public KoraliumType getKoraliumType()
    {
        return koraliumType;
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
        children.forEach(KoraliumExecutionColumn::finish);

        //Sort all the children
        children = children.stream()
                .sorted(Comparator.comparing(KoraliumExecutionColumn::getReturnId, Integer::compareTo))
                .collect(toImmutableList());
    }
}
