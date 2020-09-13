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
using Koralium.SqlToExpression.Executors;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression.Stages.ExecuteStages
{
    public class ExecuteOffsetStage : IExecuteStage
    {
        public Type Type { get; }

        public int? Skip { get; }

        public int? Take { get; }

        public ExecuteOffsetStage(Type type, int? skip, int? take)
        {
            Type = type;
            Skip = skip;
            Take = take;
        }

        public ValueTask<IQueryable> Accept(IQueryExecutor queryExecutor)
        {
            return queryExecutor.Visit(this);
        }
    }
}
