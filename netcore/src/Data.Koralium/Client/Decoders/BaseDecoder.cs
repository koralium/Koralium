/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Google.Protobuf.Collections;
using Koralium.Grpc;
using System;
using System.Text;

namespace Data.Koralium.Client.Decoders
{
    public abstract class BaseDecoder
    {
        protected int count = 0;
        protected int globalCount = 0;
        protected int nullCounter = 0;

        public virtual void NewPage(Page page)
        {
            count = 0;
            globalCount = 0;
            nullCounter = 0;
        }

        public abstract void ReadBlock(Block block, KoraliumRow[] rows);

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
