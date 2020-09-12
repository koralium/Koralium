using Koralium.Core.Interfaces;
using Koralium.Core.Models;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Koralium.Core.Metadata
{
    public class TableColumn
    {
        public ColumnMetadata Metadata { get; }

        public string Name { get; }

        public int GlobalIndex { get; }

        public Func<object, object> PropertyAccessor { get; }

        public MemberInfo Member { get; }

        public IReadOnlyList<TableColumn> Children { get; }

        public Type ColumnType { get; }

        public Action<object, object> SetDelegate { get; }

        public IEncoder Encoder { get; }

        public IDecoder Decoder { get; }


        public TableColumn(
            ColumnMetadata metadata,
            string name,
            int globalIndex,
            Func<object, object> propertyAccessor,
            MemberInfo member,
            Type columnType,
            IReadOnlyList<TableColumn> children,
            IEncoder encoder,
            IDecoder decoder)
        {
            Metadata = metadata;
            Name = name;
            GlobalIndex = globalIndex;
            PropertyAccessor = propertyAccessor;
            Member = member;
            ColumnType = columnType;
            Children = children;
            Encoder = encoder;
            Decoder = decoder;
        }

        public ColumnMetadata ToColumnMetadata(ref int globalIndex)
        {
            ColumnMetadata column = new ColumnMetadata()
            {
                ColumnId = globalIndex++,
                Name = Name,
                Type = Metadata.Type
            };

            foreach (var child in Children)
            {
                column.SubColumns.Add(child.ToColumnMetadata(ref globalIndex));
            }
            return column;
        }
    }
}
