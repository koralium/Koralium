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
using Koralium.Grpc;
using Koralium.Transport.LegacyGrpc.Interfaces;

namespace Koralium.Transport.LegacyGrpc.Encoders
{
    class Int32Encoder : IEncoder
    {
        public Block CreateBlock(Page page)
        {
            return new Block()
            {
                Ints = new Int32Block()
            };
        }

        public uint Encode(in object value, in Block block, in int rowNumber)
        {
            block.Ints.Values.Add((int)value);
            return 4;
        }

        public void Finish()
        {
            //No operation needed
        }
    }
}
