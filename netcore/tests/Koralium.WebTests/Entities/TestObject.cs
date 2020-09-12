namespace Koralium.WebTests.Entities
{
    public class TestObject
    {
        public string TestTest { get; set; }

        public OtherObject OtherObject { get; set; }

        public override int GetHashCode() => TestTest.GetHashCode();

        public override bool Equals(object obj)
        {
            if(obj is TestObject testObject)
            {
                return testObject.TestTest.Equals(TestTest) && testObject.OtherObject.Equals(OtherObject);
            }
            return false;
        }
    }
}
