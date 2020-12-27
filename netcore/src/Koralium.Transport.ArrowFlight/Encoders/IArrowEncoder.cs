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
using Apache.Arrow;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.ArrowFlight.Encoders
{
    /// <summary>
    /// Interface for the encoders to take C# data into Apache Arrow format
    /// </summary>
    interface IArrowEncoder
    {
        /// <summary>
        /// Called when a new batch is started.
        /// This should create a new builder
        /// </summary>
        void NewBatch();

        IArrowArray BuildArray();

        void Encode(object row);

        /// <summary>
        /// Pad the arrow array by a set amount, this is used mostly for struct arrays.
        /// </summary>
        /// <param name="length"></param>
        void Pad(int length);

        long Size();
    }
}
