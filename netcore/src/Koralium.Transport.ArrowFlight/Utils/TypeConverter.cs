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
using Apache.Arrow;
using Apache.Arrow.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
                case ColumnType.Enum:
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
                case ColumnType.UInt64:
                    return UInt64Type.Default;
                case ColumnType.Byte:
                    return UInt8Type.Default;
                case ColumnType.Binary:
                    return BinaryType.Default;
                case ColumnType.Decimal:
                    return new Decimal128Type(24, 8);
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
