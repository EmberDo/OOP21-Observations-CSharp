
using System.Collections.Generic;
/// <summary>
/// Simple class for create folder and file.
/// </summary>
namespace ConsoleApp1.src.org.observations.model
{

    public interface ISaved
    {
        /// <summary>
        /// Create a folder and subfolder require for the path requested.
        /// </summary>
        /// <param name="path">absolute path for create folder</param>
        void MakeDir(string path);

        /// <summary>
        /// Create a file request in the path selected.
        /// </summary>
        /// <param name="path">absolute path for create file</param>
        void MakeFile(string path);

        /// <summary>
        /// Create file and write all the file in the list.
        /// </summary>
        /// <param name="path">absolute path for create file if missed</param>
        /// <param name="updateList">list of all file to copy</param>
        void WriteList(string path, List<string> updateList);
    }
}
