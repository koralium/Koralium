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

public class GrpcTableIndex
{
    private final int tableId;
    private final int indexId;
    private final String key;

    public GrpcTableIndex(int tableId, int indexId, String key)
    {
        this.tableId = tableId;
        this.indexId = indexId;
        this.key = key;
    }

    public String getKey()
    {
        return key;
    }

    public int getTableId()
    {
        return tableId;
    }

    public int getIndexId()
    {
        return indexId;
    }
}
