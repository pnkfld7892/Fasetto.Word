using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// Handles reading/writing and querying the file system
    /// </summary>
    public interface IFileManager
    {
        /// <summary>
        /// Writes the text to the specified file
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="path">The path of the file to write to</param>
        /// <param name="append">If true, append text to end, else overwrite</param>
        /// <returns></returns>
        Task WriteTextToFileAsync(string text, string path, bool append = false);

        /// <summary>
        /// Normalizes a path based or current OS
        /// </summary>
        /// <param name="path">the path to normalize </param>
        /// <returns></returns>
        string NormalizePath(string path);

        /// <summary>
        /// Resoles any relative path to absolute
        /// </summary>
        /// <param name="path">the path to resolve </param>
        /// <returns></returns>
        string ResolvePath(string path);
    }
}
