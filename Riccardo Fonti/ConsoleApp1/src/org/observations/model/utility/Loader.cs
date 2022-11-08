
using System;
using System.Collections.Generic;
using System.IO;
/// <summary>
/// Simple class for load file and folder from root,
/// return a list file or single file in the selected directory.
/// </summary>
namespace ConsoleApp1.src.org.observations.model.utility
{

	public class Loader : ILoader
	{
        /// <summary>
        /// Import list from file and return String list.
        /// </summary>
        /// <param name="path">directory path for reading file</param>
        /// <returns>list of data read from file</returns>
        public IList<string> FillList(string path)
        {
            var list = new List<string>();
            try
            {
                using (StreamReader reader = ReadFile(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
                list.Sort();
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible read the file: {0}", e.ToString());
            }
            finally { }
            return list;
        }

        /// <summary>
        /// Return string list of file and/or folder from directory path selected.
        /// </summary>
        /// <param name="path">directory path for reading file</param>
        /// <returns>list of file/folder</returns>
        public IList<string> LoadFileFolder(string path)
        {
            var listFileFolder = new List<string>();
            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path);
                if (!files.Length.Equals(0))
                {
                    foreach (string file in files)
                    {
                        FileInfo fi = new FileInfo(file);
                        listFileFolder.Add(fi.Name.Replace(fi.Extension,""));
                    }
                } 
                else
                {
                    files = Directory.GetDirectories(path);
                    foreach (string file in files)
                    {
                        DirectoryInfo di = new DirectoryInfo(file);
                        listFileFolder.Add(di.Name);
                    }
                        
                }
            }
            return listFileFolder;
        }

        /// <summary>
        /// Return Stream Reader from file path.
        /// </summary>
        /// <param name="path">absolute path for reading file</param>
        /// <returns>StreamReader from file</returns>
        private static StreamReader ReadFile(string path)
        {
            if (!File.Exists(path))
            {
                try
                {
                    using FileStream fs = File.Create(path);
                }
                catch
                {
                    FileInfo fi = new FileInfo(path);
                    Console.WriteLine("Impossible create file: ", fi.Name.Replace(fi.Extension, ""));
                }
            }
            return new StreamReader(path);
        }
    }
}
