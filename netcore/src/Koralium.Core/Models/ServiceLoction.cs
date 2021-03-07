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

namespace Koralium.Models
{
    public class ServiceLoction
    {
        /// <summary>
        /// Host name of the service, may include port.
        /// </summary>
        public string Host { get; }

        /// <summary>
        /// Is the service behind TLS or not?
        /// </summary>
        public bool Tls { get; }

        /// <summary>
        /// Additional data that can be passed between partition resolvers and discovery services.
        /// </summary>
        public object AdditionalData { get; }

        public ServiceLoction(
            string host,
            bool tls,
            object additionalData = null)
        {
            Host = host;
            Tls = tls;
            AdditionalData = additionalData;
        }
    }
}
