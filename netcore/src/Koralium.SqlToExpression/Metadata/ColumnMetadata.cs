using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlToExpression
{
    public class ColumnMetadata
    {
        /// <summary>
        /// Name of the column
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The type that this specific column is in
        /// </summary>
        public Type Type { get; }

        public Func<object, object> GetFunction { get; }

        public ColumnMetadata(string name, Type type, Func<object, object> getFunc)
        {
            Name = name;
            Type = type;
            GetFunction = getFunc;
        }
    }
}
