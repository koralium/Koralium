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
using Koralium.Data.ArrowFlight.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Koralium.Data.ArrowFlight.Decoders
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
