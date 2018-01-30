using System;
using System.Runtime.CompilerServices;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// Holds a bunch of loggers to log messages for the user
    /// </summary>
    public interface ILogFactory
    {
        #region Events

        /// <summary>
        /// Fires when ever a new log arrives
        /// </summary>
        event Action<(string Message, LogLevel Level)> NewLog;

        /// <summary>
        /// If true, include the origin of where the log message was logged from
        /// such as the class name, line number and file name
        /// </summary>
        bool IncludeLogOriginDetails { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// The level of logging to output
        /// </summary>
        LogOutputLevel LogOutputLevel { get; set; }


        #endregion

        #region Methods
        /// <summary>
        /// Adds the speific logger to this factory
        /// </summary>
        /// <param name="logger">The logger to add</param>
        void AddLogger(ILogger logger);

        /// <summary>
        /// Removes the specified logger from this factory
        /// </summary>
        /// <param name="logger">the logger to remove</param>
        void RemoveLogger(ILogger logger);

        /// <summary>
        /// Logs the specific to all loggers in this factory
        /// </summary>
        /// <param name="message">The Message to log</param>
        /// <param name="level">Level of the Message being Logged</param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">the code filename that this message was logged from</param>
        /// <param name="lineNumber">the line number of the code file this message was logged from</param>
        void Log(string message, LogLevel level = LogLevel.Informative, [CallerMemberName]string origin = "",
            [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0);

        #endregion

    }
}
