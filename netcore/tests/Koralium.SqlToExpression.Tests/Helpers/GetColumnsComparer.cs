using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlToExpression.Tests.Helpers
{
    public static class GetColumnsComparer
    {
        public static void Compare(ColumnMetadata expected, ColumnMetadata actual)
        {
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Type, actual.Type);
        }

        public static void Compare(IReadOnlyList<ColumnMetadata> expected, IReadOnlyList<ColumnMetadata> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);

            for(int i = 0; i < expected.Count; i++)
            {
                Compare(expected[i], actual[i]);
            }
        }
    }
}
