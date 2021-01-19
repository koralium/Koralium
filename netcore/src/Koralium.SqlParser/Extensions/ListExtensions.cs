using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser
{
    internal static class ListExtensions
    {
        public static bool AreEqualCaseInsensitive(this List<string> list, List<string> other)
        {
            if (list == null && other == null)
            {
                return true;
            }
            if (list == null || other == null)
            {
                return false;
            }
            if (list.Count != other.Count)
            {
                return false;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (!string.Equals(list[i], other[i], StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AreEqual<T>(this List<T> list, List<T> other)
        {
            if (list == null && other== null)
            {
                return true;
            }
            if (list == null || other == null)
            {
                return false;
            }
            if (list.Count != other.Count)
            {
                return false;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (!Equals(list[i], other[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
