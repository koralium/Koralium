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
    public class DefaultWhereExecutorFactory : IWhereExecutorFactory
    {
        private static Dictionary<Type, IWhereExecutor> executors = new Dictionary<Type, IWhereExecutor>();

        public IWhereExecutor GetWhereExecutor(ExecuteWhereStage executeWhereStage)
        {
            if (!executors.TryGetValue(executeWhereStage.EntityType, out var executor))
            {
                var t = typeof(DefaultWhereExecutor<>).MakeGenericType(executeWhereStage.EntityType);
                executor = (IWhereExecutor)Activator.CreateInstance(t);
                executors.Add(executeWhereStage.EntityType, executor);
            }
            return executor;
        }
    }
}
