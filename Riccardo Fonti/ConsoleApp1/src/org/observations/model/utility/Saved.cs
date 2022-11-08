
using System;
using System.Collections.Generic;
using System.IO;
/// <summary>
/// Simple class for create folder and file.
/// </summary>
namespace ConsoleApp1.src.org.observations.model.utility
{
    public class Saved : ISaved
    {
        /// <summary>
        /// Create a folder and subfolder require for the path requested.
        /// </summary>
        /// <param name="path">absolute path for create folder</param>
        public void MakeDir(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible create directory: {0}", e.ToString());
            }
            finally {}
        }

        /// <summary>
        /// Create a file request in the path selected.
        /// </summary>
        /// <param name="path">absolute path for create file</param>
        public void MakeFile(string path)
        {
            try
            {
                using FileStream fs = File.Create(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible create file: {0}", e.ToString());
            }
            finally { }
        }

        /// <summary>
        /// Create file and write all the file in the list.
        /// </summary>
        /// <param name="path">absolute path for create file if missed</param>
        /// <param name="updateList">list of all file to copy</param>
        public void WriteList(string path, List<string> updateList)
        {
            var list = new List<string>(updateList);
            list.Sort();
            try
            {
                using StreamWriter sw = new StreamWriter(path);
                foreach (string s in list)
                {
                    sw.WriteLine(s);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible write to file: {0}", e.ToString());
            }
            finally { }
        }
    }
}
