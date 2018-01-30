namespace Fasetto.Word.Core
{
    /// <summary>
    /// the level of severity for a log message
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Developer specific information
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Verbose information
        /// </summary>
        Verbose = 2,

        /// <summary>
        /// General Information
        /// </summary>
        Informative = 3,

        /// <summary>
        /// A warning
        /// </summary>
        Warning = 4,
        /// <summary>
        /// an error
        /// </summary>
        Error = 5,

        /// <summary>
        /// a success
        /// </summary>
        Success = 6,
    }
}
