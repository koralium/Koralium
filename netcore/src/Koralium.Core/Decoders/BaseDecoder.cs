using Google.Protobuf.Collections;
using Koralium.Core.Interfaces;
using Koralium.Core.Metadata;
using Koralium.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Core.Decoders
{
    public abstract class BaseDecoder : IDecoder
    {
        protected int count = 0;
        protected int globalCount = 0;
        protected int nullCounter = 0;

        public abstract IDecoder Create(int columnId, TableColumn column);

        public virtual void NewPage(Page page)
        {
            count = 0;
            globalCount = 0;
            nullCounter = 0;
        }

        public abstract void Decode(Block block, Action<int, object> setter, int? numberOfRows = int.MaxValue);

        protected void Decode<T>(RepeatedField<uint> nulls, RepeatedField<T> values, Action<int, object> setter, int? numberOfRows)
        {
            if (numberOfRows == null)
            {
                numberOfRows = int.MaxValue;
            }
            var localCount = 0;
            while ((nulls.Count > nullCounter || values.Count > count) && numberOfRows > localCount)
            {
                if (nulls.Count > nullCounter && nulls[nullCounter] == globalCount)
                {
                    setter(globalCount, null);
                    nullCounter++;
                    globalCount++;
                    localCount++;
                    continue;
                }
                if (values.Count > count)
                {
                    setter(globalCount, values[count]);
                    count++;
                    globalCount++;
                    localCount++;
                }
            }
        }
    }
}
