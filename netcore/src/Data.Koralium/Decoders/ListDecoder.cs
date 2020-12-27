using Apache.Arrow;
using Apache.Arrow.Types;
using Data.Koralium.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Data.Koralium.Decoders
{
    internal class ListDecoder : ColumnDecoder
    {
        private readonly ColumnDecoder _childDecoder;
        private readonly Type _listType;

        private ListArray _array;

        public ListDecoder(ListType listType)
        {
            if(listType.Fields.Count != 1)
            {
                throw new ArgumentException("List type contains more than 1 field.", nameof(listType));
            }

            _childDecoder = SchemaToDecoder.FieldsToDecoders(listType.Fields).First();
            _listType = typeof(List<>).MakeGenericType(_childDecoder.GetFieldType());
        }

        public override string GetDataTypeName()
        {
            return "list";
        }

        public override Type GetFieldType()
        {
            return _listType;
        }

        public override object GetFieldValue(in int index, Type type)
        {
            var listCreator = ListCreators.GetListCreator(type);

            var startOffset = _array.ValueOffsets[index];
            var endOffset = _array.ValueOffsets[index + 1];

            for (int i = startOffset; i < endOffset; i++)
            {
                listCreator.AddElement(_childDecoder.GetFieldValue(i, listCreator.ElementType));
            }

            return listCreator.Build();
        }

        public override object GetValue(in int index)
        {
            var list =(IList)Activator.CreateInstance(_listType);

            var startOffset = _array.ValueOffsets[index];
            var endOffset = _array.ValueOffsets[index + 1];

            for (int i = startOffset; i < endOffset; i++)
            {
                list.Add(_childDecoder.GetValue(i));
            }

            return list;
        }

        public override bool IsDbNull(in int index)
        {
            return _array.IsNull(index);
        }

        internal override void NewBatch(IArrowArray arrowArray)
        {
            _array = (ListArray)arrowArray;

            _childDecoder.NewBatch(_array.Values);
        }
    }
}
