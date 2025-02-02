﻿namespace Meadow.Logging
{
    /// <summary>
    /// Class encapsulating logging providers and functions
    /// </summary>
    public class Logger
    {
        private LogProviderCollection _providers = new LogProviderCollection();

        /// <summary>
        /// Gets or sets the current log level
        /// </summary>
        public LogLevel Loglevel { get; set; } = LogLevel.Error;

        /// <summary>
        /// Creates a Logger instance
        /// </summary>
        /// <param name="providers">A collection of providers to add to the Logger</param>
        public Logger(params ILogProvider[] providers)
        {
            foreach (var p in providers)
            {
                AddProvider(p);
            }
        }

        /// <summary>
        /// Creates a Logger instance
        /// </summary>
        /// <param name="provider">A provider to add to the Logger</param>
        public Logger(ILogProvider provider)
        {
            AddProvider(provider);
        }

        /// <summary>
        /// Creates a Logger instance
        /// </summary>
        public Logger()
        {
        }

        /// <summary>
        /// Adds an ILogProvider to the providers collection
        /// </summary>
        /// <param name="provider"></param>
        public void AddProvider(ILogProvider provider)
        {
            lock (_providers)
            {
                _providers.Add(provider);
            }
        }

        /// <summary>
        /// Sends a Trace-level message to all ILogProviders
        /// </summary>
        /// <param name="message">The message to send to Providers</param>
        public void Trace(string message)
        {
            Log(LogLevel.Trace, message);
        }

        /// <summary>
        /// Conditionally sends a Trace-level message to all ILogProviders
        /// </summary>
        /// <param name="condition">The message will be sent to Providers only when this is true</param>
        /// <param name="message">The message to send to Providers</param>
        public void TraceIf(bool condition, string message)
        {
            if (condition) Log(LogLevel.Trace, message);
        }

        /// <summary>
        /// Sends a Debug-level message to all ILogProviders
        /// </summary>
        /// <param name="message">The message to send to Providers</param>
        public void Debug(string message)
        {
            Log(LogLevel.Debug, message);
        }

        /// <summary>
        /// Conditionally sends a Debug-level message to all ILogProviders
        /// </summary>
        /// <param name="condition">The message will be sent to Providers only when this is true</param>
        /// <param name="message">The message to send to Providers</param>
        public void DebugIf(bool condition, string message)
        {
            if (condition) Log(LogLevel.Debug, message);
        }

        /// <summary>
        /// Sends an Info-level message to all ILogProviders
        /// </summary>
        /// <param name="message">The message to send to Providers</param>
        public void Info(string message)
        {
            Log(LogLevel.Information, message);
        }

        /// <summary>
        /// Conditionally sends a Info-level message to all ILogProviders
        /// </summary>
        /// <param name="condition">The message will be sent to Providers only when this is true</param>
        /// <param name="message">The message to send to Providers</param>
        public void InfoIf(bool condition, string message)
        {
            if (condition) Log(LogLevel.Information, message);
        }

        /// <summary>
        /// Sends a Warn-level message to all ILogProviders
        /// </summary>
        /// <param name="message">The message to send to Providers</param>
        public void Warn(string message)
        {
            Log(LogLevel.Warning, message);
        }

        /// <summary>
        /// Conditionally sends a Warn-level message to all ILogProviders
        /// </summary>
        /// <param name="condition">The message will be sent to Providers only when this is true</param>
        /// <param name="message">The message to send to Providers</param>
        public void WarnIf(bool condition, string message)
        {
            if (condition) Log(LogLevel.Warning, message);
        }

        /// <summary>
        /// Sends a Error-level message to all ILogProviders
        /// </summary>
        /// <param name="message">The message to send to Providers</param>
        public void Error(string message)
        {
            Log(LogLevel.Error, message);
        }

        /// <summary>
        /// Conditionally sends a Error-level message to all ILogProviders
        /// </summary>
        /// <param name="condition">The message will be sent to Providers only when this is true</param>
        /// <param name="message">The message to send to Providers</param>
        public void ErrorIf(bool condition, string message)
        {
            if (condition) Log(LogLevel.Error, message);
        }

        private void Log(LogLevel level, string message)
        {
            if (Loglevel > level) return;

            lock (_providers)
            {
                foreach (var p in _providers)
                {
                    p.Log(level, message);
                }
            }
        }
    }
}