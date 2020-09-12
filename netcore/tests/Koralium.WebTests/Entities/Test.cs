using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests.Entities
{
    public class Test
    {
        public string Name { get; set; }

        public List<int> TestList { get; set; }

        public List<List<int>> ListInList { get; set; }

        public List<OtherObject> ListOfObject { get; set; }

        public TestObject TestObject { get; set; }

        public float FloatValue { get; set; }

        public bool BoolValue { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Test t)
            {
                return Name.Equals(t.Name) &&
                    TestList.SequenceEqual(t.TestList) &&
                    ListInList.SequenceEqual(t.ListInList, new ListEqualityComparer<int>()) &&
                    ListOfObject.SequenceEqual(t.ListOfObject) &&
                    TestObject.Equals(t.TestObject) &&
                    FloatValue.Equals(t.FloatValue) &&
                    BoolValue.Equals(t.BoolValue);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

    public class ListEqualityComparer<T> : IEqualityComparer<List<T>>
    {
        public bool Equals([AllowNull] List<T> x, [AllowNull] List<T> y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode([DisallowNull] List<T> obj)
        {
            return obj.GetHashCode();
        }
    }
}
