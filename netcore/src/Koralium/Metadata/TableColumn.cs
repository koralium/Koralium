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
using Koralium.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Koralium.Metadata
{
    public class TableColumn
    {
        public string Name { get; }

        public Func<object, object> PropertyAccessor { get; }

        public MemberInfo Member { get; }

        public IReadOnlyList<TableColumn> Children { get; }

        public Type ColumnType { get; }

        public Action<object, object> SetDelegate { get; }

        public TableColumn(
            string name,
            Func<object, object> propertyAccessor,
            MemberInfo member,
            Type columnType,
            IReadOnlyList<TableColumn> children)
        {
            Name = name;
            PropertyAccessor = propertyAccessor;
            Member = member;
            ColumnType = columnType;
            Children = children;
        }
    }
}
