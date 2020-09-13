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
using Koralium.SqlToExpression.Stages.ExecuteStages;
using System;
using System.Collections.Generic;

namespace Koralium.SqlToExpression.Executors
{
    public class DefaultDistinctExecutorFactory : IDistinctExecutorFactory
    {
        private static Dictionary<Type, IDistinctExecutor> executors = new Dictionary<Type, IDistinctExecutor>();
        public IDistinctExecutor GetDistinctExecutor(ExecuteDistinctStage executeDistinctStage)
        {
            if (!executors.TryGetValue(executeDistinctStage.Type, out var executor))
            {
                var t = typeof(DefaultDistinctExecutor<>).MakeGenericType(executeDistinctStage.Type);
                executor = (IDistinctExecutor)Activator.CreateInstance(t);
                executors.Add(executeDistinctStage.Type, executor);
            }
            return executor;
        }
    }
}
