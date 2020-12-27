using Apache.Arrow;
using Apache.Arrow.Types;
using Data.Koralium.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Koralium.Decoders
{
    internal class StructDecoder : ColumnDecoder
    {
        private readonly IReadOnlyList<ColumnDecoder> _decoders;
        private readonly string[] _names;

        private StructArray _array;

        //These fields are used when doing getFieldValue
        private TypeAccessor _lastUsedFieldValueTypeAccessor = null;
        private IReadOnlyList<PropertyAccessor> _lastUsedFieldValuePropertyAccessors = null;

        public StructDecoder(StructType structType)
        {
            _names = structType.Fields.Select(x => x.Name).ToArray();
            _decoders = SchemaToDecoder.FieldsToDecoders(structType.Fields);
        }

        public override string GetDataTypeName()
        {
            return "struct";
        }

        public override Type GetFieldType()
        {
            return typeof(IReadOnlyDictionary<string, object>);
        }

        public override bool IsDbNull(in int index)
        {
            return _array.IsNull(index);
        }

        public override object GetValue(in int index)
        {
            Dictionary<string, object> output = new Dictionary<string, object>(_decoders.Count);
            for(int i = 0; i < _decoders.Count; i++)
            {
                output.Add(_names[i], _decoders[i].GetValue(index));
            }
            return output;
        }

        public override object GetFieldValue(in int index, Type type)
        {
            if(!Equals(_lastUsedFieldValueTypeAccessor?.Type, type))
            {
                _lastUsedFieldValueTypeAccessor = TypeAccessors.GetTypeAccessor(type);
                _lastUsedFieldValuePropertyAccessors = _lastUsedFieldValueTypeAccessor.GetSetDelegates(_names);
            }

            var obj = Activator.CreateInstance(type);

            for (int i = 0; i < _names.Length; i++)
            {
                if(_lastUsedFieldValuePropertyAccessors[i] != null)
                {
                    _lastUsedFieldValuePropertyAccessors[i].SetValue(obj, _decoders[i].GetFieldValue(index, _lastUsedFieldValuePropertyAccessors[i].PropertyType));
                }
            }

            return obj;
        }

        public override T GetFieldValue<T>(in int index)
        {
            return (T)GetFieldValue(index, typeof(T));
        }

        internal override void NewBatch(IArrowArray arrowArray)
        {
            _array = (StructArray)arrowArray;
            if(_array.Fields.Count != _decoders.Count)
            {
                throw new InvalidOperationException("Number of fields in arrow array does not match the number of fields in the schema");
            }

            for(int i = 0; i < _decoders.Count; i++)
            {
                _decoders[i].NewBatch(_array.Fields[i]);
            }
        }
    }
}
