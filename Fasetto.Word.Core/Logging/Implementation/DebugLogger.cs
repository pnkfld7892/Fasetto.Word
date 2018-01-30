using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Fasetto.Word.Core
{
    public class DebugLogger : ILogger
    {
        public void Log(string message, LogLevel level)
        {
            //default category
            var category = default(string);

            switch(level)
            {
                case LogLevel.Debug:
                    category = "information";
                    break;
                case LogLevel.Verbose:
                    category = "verbose";
                    break;
                case LogLevel.Warning:
                    category = "Warning";
                    break;
                case LogLevel.Error:
                    category = "error";
                    break;
                case LogLevel.Success:
                    category = "-----";
                    break;
            }

            Debug.WriteLine(message, category);
        }
    }
}
