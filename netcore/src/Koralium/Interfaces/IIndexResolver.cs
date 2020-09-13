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
using Grpc.Core;
using Koralium.Metadata;
using Koralium.Grpc;
using Microsoft.Extensions.Logging;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Koralium.Interfaces
{
    public interface IIndexResolver
    {
        Task GetData(ILogger logger, IndexRequest dataRequest, KoraliumTable table, TableIndex index, ServerCallContext context, ChannelWriter<Page> channelWriter);
    }
}
