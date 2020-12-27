using Apache.Arrow;
using Apache.Arrow.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Koralium.Transport.ArrowFlight.Utils
{
    internal static class TypeConverter
    {
        public static IArrowType Convert(Column column)
        {
            switch (column.ColumnType)
            {
                case ColumnType.Bool:
                    return BooleanType.Default;
                case ColumnType.DateTime:
                    return TimestampType.Default;
                case ColumnType.Double:
                    return DoubleType.Default;
                case ColumnType.Float:
                    return FloatType.Default;
                case ColumnType.Int32:
                    return Int32Type.Default;
                case ColumnType.Int64:
                    return Int64Type.Default;
                case ColumnType.String:
                    return StringType.Default;
                case ColumnType.List:
                    return ConvertListType(column);
                case ColumnType.Object:
                    return ConvertObjectType(column);
                case ColumnType.Short:
                    return Int16Type.Default;
                case ColumnType.UInt32:
                    return UInt32Type.Default;
            }
            throw new NotImplementedException();
        }

        private static IArrowType ConvertListType(Column column)
        {
            Debug.Assert(column.Children.Count == 1);

            return new ListType(Convert(column.Children.First()));
        }

        private static IArrowType ConvertObjectType(Column column)
        {
            List<Field> fields = new List<Field>();
            foreach(var child in column.Children)
            {
                fields.Add(new Field(child.Name, Convert(child), child.IsNullable));
            }
            return new StructType(fields);
        }
    }
}
