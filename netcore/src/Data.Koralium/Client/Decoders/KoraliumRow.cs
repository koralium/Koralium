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
