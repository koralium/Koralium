using System;

namespace Data.Koralium.Utils
{
    internal abstract class ListCreator
    {
        public abstract Type ElementType { get; }

        public abstract object Build();

        public abstract void AddElement(object obj);
    }
}
