using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// Handles anything to do with tasks
    /// </summary>
    public class TaskManager : ITaskManager
    {
        #region Task Methods

        public async Task Run(Func<Task> function, [CallerMemberName]string origin = "",
            [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            try
            {
                //attempt to run task
                await Task.Run(function);
            }
            catch(Exception ex)
            {
                //log error
                LogError(ex, origin, filePath, lineNumber);

                //re-throw exception to preserve flow of code
                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken, [CallerMemberName]string origin = "",
            [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            try
            {
                //attempt to run task
                return Task.Run(function,cancellationToken);
            }
            catch (Exception ex)
            {
                //log error
                LogError(ex);

                //re-throw exception to preserve flow of code
                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<Task<TResult>> function, [CallerMemberName]string origin = "",
            [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            try
            {
                //attempt to run task
                return Task.Run(function);
            }
            catch (Exception ex)
            {
                //log error
                LogError(ex);

                //re-throw exception to preserve flow of code
                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken, [CallerMemberName]string origin = "",
            [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            try
            {
                //attempt to run task
                return Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                //log error
                LogError(ex);

                //re-throw exception to preserve flow of code
                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<TResult> function, [CallerMemberName]string origin = "",
            [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            try
            {
                //attempt to run task
                return Task.Run(function);
            }
            catch (Exception ex)
            {
                //log error
                LogError(ex);

                //re-throw exception to preserve flow of code
                throw;
            }
        }

        public Task Run(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName]string origin = "",
            [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            try
            {
                //attempt to run task
                return Task.Run(function,cancellationToken);
            }
            catch (Exception ex)
            {
                //log error
                LogError(ex);

                //re-throw exception to preserve flow of code
                throw;
            }
        }

        public Task Run(Action action, CancellationToken cancellationToken, [CallerMemberName]string origin = "",
            [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            try
            {
                //attempt to run task
                return Task.Run(action, cancellationToken);
            }
            catch (Exception ex)
            {
                //log error
                LogError(ex);

                //re-throw exception to preserve flow of code
                throw;
            }
        }

        public Task Run(Action action, [CallerMemberName]string origin = "",
            [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            try
            {
                //attempt to run task
                return Task.Run(action);
            }
            catch (Exception ex)
            {
                //log error
                LogError(ex);

                //re-throw exception to preserve flow of code
                throw;
            }
        }

        #endregion

        #region Private Helper Methods

        /// <summary>
        /// Logs the given error to the log factory
        /// </summary>
        /// <param name="ex">The exception to log</param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">the code filename that this message was logged from</param>
        /// <param name="lineNumber">the line number of the code file this message was logged from</param>
        private void LogError(Exception ex, [CallerMemberName]string origin = "",
            [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            IoC.Logger.Log($"An unexpected error occurred running an IoC.Task.Run: {ex.Message}", LogLevel.Debug, origin, filePath, lineNumber);
        }
        #endregion
    }
}
