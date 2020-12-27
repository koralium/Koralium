using Apache.Arrow;
using Apache.Arrow.Types;
using Data.Koralium.Decoders;
using Data.Koralium.Internal;
using System.Collections.Generic;

namespace Data.Koralium.Utils
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
