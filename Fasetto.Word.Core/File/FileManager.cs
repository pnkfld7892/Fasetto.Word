using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// Handles reading/writing and querying the file system
    /// </summary>
    public class FileManager : IFileManager
    {
        /// <summary>
        /// Writes the text to the specified file
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="path">The path of the file to write to</param>
        /// <param name="append">If true, append text to end, else overwrite</param>
        /// <returns></returns>
        public async Task WriteTextToFileAsync(string text, string path, bool append = false)
        {
            // ToDo: add exception catching

            //Normalize
            path = NormalizePath(path);

            //resolve to absolute path
            path = ResolvePath(path);

            //Lock the task
            await AsyncAwaiter.AwaitAsync(nameof(FileManager) + path, async () =>
            {
                //TODO: Add IoC.Task.Run that logs to logger on failure

                //Run the synchronous file as a new task
                await IoC.Task.Run(() => 
                {
                    //write log message to file
                    using (var fileStream = (TextWriter)new StreamWriter(File.Open(path, append ? FileMode.Append : FileMode.Create)))
                        fileStream.Write(text);
                });
            });
        }

        /// <summary>
        /// Normalizes a path based or current OS
        /// </summary>
        /// <param name="path">the path to normalize </param>
        /// <returns></returns>
        public string NormalizePath(string path)
        {
            //if on windows
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                //replace any forward-slashes with back-slashes
                return path?.Replace('/', '\\').Trim();

            //else *nix
            else
                //replace any back-slashes with forward-slashes
                return path?.Replace('\\', '/').Trim();

        }

        /// <summary>
        /// Resolves any relative path to absolute
        /// </summary>
        /// <param name="path">the path to resolve </param>
        /// <returns></returns>
        public string ResolvePath(string path)
        {
            return Path.GetFullPath(path);
        }
    }
}
