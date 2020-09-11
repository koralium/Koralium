using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Data.Koralium.Client.Decoders
{
    public class KoraliumRow
    {
        private readonly object[] columnsData;
        public KoraliumRow(int columnCount)
        {
            columnsData = new object[columnCount];
        }

        public void SetData(int ordinal, object data)
        {
            Debug.Assert(ordinal < columnsData.Length);

            columnsData[ordinal] = data;
        }

        public object GetData(int ordinal)
        {
            Debug.Assert(ordinal < columnsData.Length);
            return columnsData[ordinal];
        }
    }
}
