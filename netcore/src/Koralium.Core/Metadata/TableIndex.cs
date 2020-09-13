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
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Metadata
{
    public class TableIndex
    {
        public Type Resolver { get; }

        public int IndexId { get; }

        public List<TableColumn> Columns { get; }

        public string Name { get; }

        public IndexMetadata IndexMetadata { get; }

        public TableIndex(Type resolver, int indexId, List<TableColumn> columns, string name, IndexMetadata indexMetadata)
        {
            Resolver = resolver;
            IndexId = indexId;
            Columns = columns;
            Name = name;
            IndexMetadata = indexMetadata;
        }
    }
}
