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
