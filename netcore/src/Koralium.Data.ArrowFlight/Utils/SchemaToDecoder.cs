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
using Koralium.Data.ArrowFlight.Decoders;
using Koralium.Data.ArrowFlight.Internal;
using System.Collections.Generic;

namespace Koralium.Data.ArrowFlight.Utils
{
    internal static class SchemaToDecoder
    {
        internal static IReadOnlyList<ColumnDecoder> SchemaToDecoders(Schema schema)
        {
            List<ColumnDecoder> columnDecoders = new List<ColumnDecoder>(schema.Fields.Count);
            TypeDecoderVisitor typeDecoderVisitor = new TypeDecoderVisitor();
            for(int i = 0; i < schema.Fields.Count; i++)
            {
                var field = schema.GetFieldByIndex(i);
                var decoder = ArrowTypeToDecoder(field.DataType, typeDecoderVisitor);
                decoder.SetOrdinal((uint)i);

                if(field.IsNullable)
                {
                    //Add null check decoder if the column can be null
                    decoder = new NullDecoder(decoder);
                }

                columnDecoders.Add(decoder);
            }
            return columnDecoders;
        }

        internal static IReadOnlyList<ColumnDecoder> FieldsToDecoders(IReadOnlyList<Field> fields)
        {
            List<ColumnDecoder> columnDecoders = new List<ColumnDecoder>(fields.Count);
            TypeDecoderVisitor typeDecoderVisitor = new TypeDecoderVisitor();
            for (int i = 0; i < fields.Count; i++)
            {
                var field = fields[i];
                var decoder = ArrowTypeToDecoder(field.DataType, typeDecoderVisitor);
                decoder.SetOrdinal((uint)i);

                if (field.IsNullable)
                {
                    //Add null check decoder if the column can be null
                    decoder = new NullDecoder(decoder);
                }

                columnDecoders.Add(decoder);
            }
            return columnDecoders;
        }

        private static ColumnDecoder ArrowTypeToDecoder(IArrowType arrowType, TypeDecoderVisitor typeDecoderVisitor)
        {
            arrowType.Accept(typeDecoderVisitor);
            return typeDecoderVisitor.ColumnDecoder;
        }
    }
}
