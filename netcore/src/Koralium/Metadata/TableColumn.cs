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
