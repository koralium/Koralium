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
