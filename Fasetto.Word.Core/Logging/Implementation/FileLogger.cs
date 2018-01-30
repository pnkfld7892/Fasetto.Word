using System;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// Logs to a specific file
    /// </summary>
    public class FileLogger : ILogger
    {
        #region public properties
        /// <summary>
        /// The path of the log file
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// If True, logs the current time with each message
        /// </summary>
        public bool LogTime { get; set; } = true;
        #endregion

        #region Constructor
        /// <summary>
        /// We always need a file path to log to
        /// </summary>
        /// <param name="filePath">The path of the log file to log to</param>
        public FileLogger(string filePath)
        {
            //Set the file path property
            FilePath = filePath;
        }
        #endregion

        #region Logger Methods
        public void Log(string message, LogLevel level)
        {
            // Get current time
            var currentTime = DateTimeOffset.Now.ToString("yyyy-MM-dd hh:mm:ss");

            //prepend timeLogString if desired
            var timeLogString = LogTime ? $"[{currentTime}] " : "";

            //write the message to the log file
            IoC.File.WriteTextToFileAsync($"{timeLogString}{message} {Environment.NewLine}", FilePath, append: true);
        }

        #endregion

    }
}
