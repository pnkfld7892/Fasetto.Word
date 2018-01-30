using System;
using System.Collections.Generic;
using System.Text;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The level of detials to output for a logger
    /// </summary>
    public enum LogOutputLevel
    {
        /// <summary>
        /// Logs Everything
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Logs everything but debug
        /// </summary>
        Verbose = 2,

        /// <summary>
        /// Logs all informative messages
        /// Ignoring Verbose and Debug messages
        /// </summary>
        Informative = 3,

        /// <summary>
        /// Log only critical errors and warnings and success, no general information
        /// </summary>
        Critical = 4,

        /// <summary>
        /// The logger will not output
        /// </summary>
        Nothing = 7
    }
}
