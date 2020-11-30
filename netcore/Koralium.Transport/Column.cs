using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Koralium.Transport
{
    public class Column
    {
        /// <summary>
        /// Name of the column
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The type that this specific column is in
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Function to get the column value of an object
        /// </summary>
        public Func<object, object> GetFunction { get; }

        /// <summary>
        /// Contains the children of the column
        /// </summary>
        public IImmutableList<Column> Children { get; }

        public ColumnType ColumnType { get; set; }

        public Column(string name, Type type, Func<object, object> getFunction, IImmutableList<Column> children, ColumnType columnType)
        {
            Name = name;
            Type = type;
            GetFunction = getFunction;
            Children = children;
            ColumnType = columnType;
        }
    }
}
