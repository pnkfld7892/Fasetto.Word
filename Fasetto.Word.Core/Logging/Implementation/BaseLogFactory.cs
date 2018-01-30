using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The standard log facotry
    /// Log details to the Console by default
    /// </summary>
    public class BaseLogFactory : ILogFactory
    {
        #region protected methods
        /// <summary>
        /// The list of loggers in this factory
        /// </summary>
        protected List<ILogger> mLoggers = new List<ILogger>();

        /// <summary>
        /// A lock for the logger list to keep ti thread safe
        /// </summary>
        protected object mLoggersLock = new object();
        #endregion


        #region Public Properties
        /// <summary>
        /// The level of logging to output
        /// </summary>
        public LogOutputLevel LogOutputLevel { get; set; }

        /// <summary>
        /// If true, include the origin of where the log message was logged from
        /// such as the class name, line number and file name
        /// </summary>
        public bool IncludeLogOriginDetails { get; set; } = true;

        #endregion

        #region Constructor
        ///<summary>
        ///Default constructor
        /// </summary>
        /// <param name="loggers">Loggers to add, on top of stock loggers already included</param>
        public BaseLogFactory(ILogger[] loggers = null)
        {
            //Add console logger by default
            AddLogger(new DebugLogger());

            //Add any extra loggers
            if (loggers != null)
                foreach (var logger in loggers)
                    AddLogger(logger);
        }
        #endregion

        #region Public Events
        /// <summary>
        /// Fires when ever a new log arrives
        /// </summary>
        public event Action<(string Message, LogLevel Level)> NewLog = (details) => { };

        #endregion

        #region Public Methods
        /// <summary>
        /// Adds the speific logger to this factory
        /// </summary>
        /// <param name="logger">The logger to add</param>
        public void AddLogger(ILogger logger)
        {
            //lock the list so it is thread-safe
            lock(mLoggersLock)
            {
                //If logger isn't already in list
                if(!mLoggers.Contains(logger))
                    //Add to list
                    mLoggers.Add(logger);
            }
        }

        /// <summary>
        /// Removes the specified logger from this factory
        /// </summary>
        /// <param name="logger">the logger to remove</param>
        public void RemoveLogger(ILogger logger)
        {
            lock (mLoggersLock)
            {
                //If logger is in list
                if (mLoggers.Contains(logger))
                    //Add to list
                    mLoggers.Remove(logger);
            }
        }

        
        /// <summary>
        /// Logs the specific to all loggers in this factory
        /// </summary>
        /// <param name="message">The Message to log</param>
        /// <param name="level">Level of the Message being Logged</param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">the code filename that this message was logged from</param>
        /// <param name="lineNumber">the line number of the code file this message was logged from</param>
        public void Log(string message, LogLevel level = LogLevel.Informative, 
           [CallerMemberName] string origin = "",
           [CallerFilePath] string filePath = "",
           [CallerLineNumber] int lineNumber = 0)
        {
            //if we should not log the message as the level is too low...
            if ((int)level < (int)LogOutputLevel)
                return;

            //if the user want to know where the log originate from..
            if (IncludeLogOriginDetails)
                message = $"{message} [{Path.GetFileName(filePath)} > {origin}() > Line {lineNumber}]";

            //Log to all loggers
            mLoggers.ForEach(logger => logger.Log(message, level));

            //Inform Listeners
            NewLog.Invoke((message,level));
        }

        #endregion

   
    }
}
