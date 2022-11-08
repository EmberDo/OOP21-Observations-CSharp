
using System.Collections.Generic;
/// <summary>
/// Simple class for load file and folder from root,
/// return a list file or single file in the selected directory.
/// </summary>
namespace ConsoleApp1.src.org.observations.model
{
    public interface ILoader
    {
        /// <summary>
        /// Return string list of file and/or folder from directory path selected.
        /// </summary>
        /// <param name="path">directory path for reading file</param>
        /// <returns>list of file/folder</returns>
        IList<string> LoadFileFolder(string path);

        /// <summary>
        /// Import list from file and return String list.
        /// </summary>
        /// <param name="path">directory path for reading file</param>
        /// <returns>list of data read from file</returns>
        IList<string> FillList(string path);
    }
}