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
using System;
using System.Collections;

namespace Data.Koralium.Utils
{
    internal class GenericListCreator : ListCreator
    {
        private readonly IList _list;
        private readonly bool _toArray;
        public GenericListCreator(IList list, Type elementType, bool toArray = false)
        {
            _list = list;
            _toArray = toArray;
            ElementType = elementType;
        }

        public override Type ElementType { get; }

        public override void AddElement(object obj)
        {
            _list.Add(obj);
        }

        public override object Build()
        {
            if (_toArray)
            {
                var output = Array.CreateInstance(ElementType, _list.Count);
                _list.CopyTo(output, 0);
                return output;
            }
            else
            {
                return _list;
            }
        }
    }
}
