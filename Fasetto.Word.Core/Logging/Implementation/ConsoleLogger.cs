using System;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// Logs the Messages to the console
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Logs the given mesage to the system Console
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="level">The levlel of the message</param>
        public void Log(string message, LogLevel level)
        {
            //save old color
            var consoleOldColor = Console.ForegroundColor;

            //default log color value
            var consoleColor = ConsoleColor.White;

            // Color consoel base on level
            switch (level)
            {
                //debug is blue
                case LogLevel.Debug:
                    consoleColor = ConsoleColor.Blue;
                    break;
                //Verbose is Gray
                case LogLevel.Verbose:
                    consoleColor = ConsoleColor.Gray;
                    break;
                //warning is Yellow
                case LogLevel.Warning:
                    consoleColor = ConsoleColor.DarkYellow;
                    break;
                //critical is red
                case LogLevel.Error:
                    consoleColor = ConsoleColor.Red;
                    break;
                //success is green
                case LogLevel.Success:
                    consoleColor = ConsoleColor.Green;
                    break;
            }

            Console.ForegroundColor = consoleColor;

            //Write to console
            Console.WriteLine(message);

            //Reset Console Color
            Console.ForegroundColor = consoleOldColor;
        }
    }
}
