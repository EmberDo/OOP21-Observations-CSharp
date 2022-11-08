
using ConsoleApp1.src.org.observations.model;
using ConsoleApp1.src.org.observations.model.utility;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        public const string Prova = "prova";
        public const string Tryme = "tryme";
        public const string Write = "write.txt";
        public const string Scrivi = "scrivi.txt";

        static void Main(string[] args)
        {
            string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            string path = Path.Combine(new string[] { userFolder, "ObservationsC", "save", "students" });

            ISaved save = new Saved();
            ILoader loader = new Loader();

            save.MakeDir(path);
            string path1 = Path.Combine(new string[] { path, "riccardo" });
            string path2 = Path.Combine(new string[] { path, "giovanni" });
            save.MakeDir(path1);
            save.MakeDir(path2);

            foreach (string f in loader.LoadFileFolder(path))
            {
                string pathLoop1 = Path.Combine(new string[] { path, f });
                save.MakeDir(Path.Combine(new string[] { pathLoop1, Prova }));
                save.MakeDir(Path.Combine(new string[] { pathLoop1, Tryme }));
                foreach (var item in loader.LoadFileFolder(pathLoop1))
                {
                    string pathLoop2 = Path.Combine(new string[] { pathLoop1, item });
                    save.MakeFile(Path.Combine(new string[] { pathLoop2, Write }));
                    save.MakeFile(Path.Combine(new string[] { pathLoop2, Scrivi }));
                }
            }
            string path3 = Path.Combine(new string[] { path1, Prova, Scrivi });
            var list = new List<string>
            {
                "riga",
                "colonna",
                "colori",
                "sciroppo",
                "tosse",
                "sole",
                "luna"
            };
            save.WriteList(path3, list);
            Console.WriteLine("List write");
            foreach (string s in loader.FillList(path3))
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("list folder path");
            foreach (string s in loader.LoadFileFolder(path))
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("list file path");
            foreach (string s in loader.LoadFileFolder(Path.Combine(new string[] { path2, Prova })))
            {
                Console.WriteLine(s);
            }
            list = new List<string>(loader.FillList(path3));
            list.Add("nuovo inserimento");
            list.Add("altro inserimento");
            list.Add("ultimo inserimento");
            save.WriteList(path3, list);
            Console.WriteLine("New List write");
            foreach (string s in loader.FillList(path3))
            {
                Console.WriteLine(s);
            }
        }
    }
}

