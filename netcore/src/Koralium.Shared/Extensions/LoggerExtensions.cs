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
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Shared.Extensions.Logging
{
    public static class LoggerExtensions
    {
        /// <summary>
        /// Helper method to log using a function, the function is only called if the log level is active.
        /// This is useful to log more computationally heavy messages only when the log level is active.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logger"></param>
        /// <param name="logFunction"></param>
        /// <returns></returns>
        public static void LogConditionally<T>(this ILogger<T> logger, LogLevel logLevel, Action<ILogger<T>> logFunction)
        {
            if (logger.IsEnabled(logLevel))
            {
                logFunction?.Invoke(logger);
            }
        }
    }
}
