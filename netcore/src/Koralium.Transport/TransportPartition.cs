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
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport
{
    public class TransportPartition
    {
        /// <summary>
        /// The locations that the data can be collected from.
        /// If left null they are assumed to be collected from the current location.
        /// </summary>
        public IReadOnlyList<TransportServiceLocation> Locations { get; }

        /// <summary>
        /// The sql that is used to query the partition.
        /// </summary>
        public string Sql { get; }

        public TransportPartition(IReadOnlyList<TransportServiceLocation> locations, string sql)
        {
            Locations = locations;
            Sql = sql;
        }
    }
}
