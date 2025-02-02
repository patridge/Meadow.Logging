﻿namespace Meadow.Logging
{
    /// <summary>
    /// Logging Level
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// No logging (disabled)
        /// </summary>
        None,
        /// <summary>
        /// Trace or higher
        /// </summary>
        Trace,
        /// <summary>
        /// Debug or higher
        /// </summary>
        Debug,
        /// <summary>
        /// Info or higher
        /// </summary>
        Information,
        /// <summary>
        /// Warning or higher
        /// </summary>
        Warning,
        /// <summary>
        /// Error or higher
        /// </summary>
        Error
    }
}