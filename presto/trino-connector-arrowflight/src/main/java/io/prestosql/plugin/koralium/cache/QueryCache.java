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
package io.prestosql.plugin.koralium.cache;

public interface QueryCache
{
    boolean containsQuery(String query);

    //Get a new entry for the cache, this is not yet added to the cache
    QueryCacheEntry newEntry(String query);

    QueryCacheEntry get(String query);

    void add(QueryCacheEntry entry);
}
