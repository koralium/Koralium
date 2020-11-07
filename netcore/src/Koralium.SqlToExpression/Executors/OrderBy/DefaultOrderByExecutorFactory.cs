﻿/*
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
using System.Collections.Concurrent;


namespace Koralium.SqlToExpression.Executors
{
    public class DefaultOrderByExecutorFactory : IOrderByExecutorFactory
    {
        private static ConcurrentDictionary<Type, IOrderByExecutor> executors = new ConcurrentDictionary<Type, IOrderByExecutor>();
        public IOrderByExecutor GetOrderByExecutor(ExecuteOrderByStage executeOrderByStage)
        {
            if (!executors.TryGetValue(executeOrderByStage.EntityType, out var executor))
            {
                var t = typeof(DefaultOrderByExecutor<>).MakeGenericType(executeOrderByStage.EntityType);
                executor = (IOrderByExecutor)Activator.CreateInstance(t);
                executors.TryAdd(executeOrderByStage.EntityType, executor);
            }
            return executor;
        }
    }
}
