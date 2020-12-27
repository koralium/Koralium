using System;
using System.Collections.Generic;

namespace Apache.Arrow
{
    internal static class Utility
    {
        public static IList<T> DeleteListElement<T>(IList<T> values, int index)
        {
            if (index < 0 || index >= values.Count)
            {
                throw new ArgumentException("Invalid index", nameof(index));
            }

            List<T> newList = new List<T>(values.Count - 1);
            for (int i = 0; i < index; i++)
            {
                newList.Add(values[i]);
            }
            for (int i = index + 1; i < values.Count; i++)
            {
                newList.Add(values[i]);
            }

            return newList;
        }

        public static IList<T> AddListElement<T>(IList<T> values, int index, T newElement)
        {
            if (index < 0 || index > values.Count)
            {
                throw new ArgumentException("Invalid index", nameof(index));
            }

            List<T> newList = new List<T>(values.Count + 1);
            for (int i = 0; i < index; i++)
            {
                newList.Add(values[i]);
            }
            newList.Add(newElement);
            for (int i = index; i < values.Count; i++)
            {
                newList.Add(values[i]);
            }

            return newList;
        }

        public static IList<T> SetListElement<T>(IList<T> values, int index, T newElement)
        {
            if (index < 0 || index >= values.Count)
            {
                throw new ArgumentException("Invalid index", nameof(index));
            }

            List<T> newList = new List<T>(values.Count);
            for (int i = 0; i < index; i++)
            {
                newList.Add(values[i]);
            }
            newList.Add(newElement);
            for (int i = index + 1; i < values.Count; i++)
            {
                newList.Add(values[i]);
            }

            return newList;
        }
    }
}
