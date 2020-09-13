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

namespace Koralium.Metadata
{
    public class MetadataStore
    {
        public IReadOnlyList<KoraliumTable> Tables { get; }
        private readonly Dictionary<Type, IReadOnlyList<TableColumn>> _typeLookup;
        private readonly Dictionary<string, KoraliumTable> _nameToTable = new Dictionary<string, KoraliumTable>();
        private readonly TableMetadataResponse _metadataResponse;

        public MetadataStore(IReadOnlyList<KoraliumTable> tables, Dictionary<Type, IReadOnlyList<TableColumn>> typeLookup)
        {
            Tables = tables;
            _typeLookup = typeLookup;

            foreach(var table in tables)
            {
                _nameToTable.Add(table.Name.ToLower(), table);
            }

            _metadataResponse = new TableMetadataResponse();

            foreach (var table in tables)
            {
                _metadataResponse.Tables.Add(table.TableMetadata);
            }
        }

        public bool TryGetTable(string name, out KoraliumTable koraliumTable)
        {
            return _nameToTable.TryGetValue(name.ToLower(), out koraliumTable);
        }

        public bool TryGetTypeColumns(Type type, out IReadOnlyList<TableColumn> columns)
        {
            return _typeLookup.TryGetValue(type, out columns);
        }

        public KoraliumTable GetTable(int id)
        {
            return Tables[id];
        }

        public TableMetadataResponse GetMetadataResponse()
        {
            return _metadataResponse;
        }
    }
}
