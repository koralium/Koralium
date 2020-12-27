
namespace Data.Koralium.Decoders
{
    internal class DoubleDecoder : PrimitiveDecoder<double>
    {
        public override float GetFloat(in int index)
        {
            return (float)Array.Values[index];
        }

        public override double GetDouble(in int index)
        {
            return Array.Values[index];
        }

        public override decimal GetDecimal(in int index)
        {
            return (decimal)Array.Values[index];
        }
    }
}
