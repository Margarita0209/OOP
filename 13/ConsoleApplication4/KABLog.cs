using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOPLab13
{
    static class KABLog                 // работа с kablog.txt
    {                                    //з все действ пользователя
                                         //------------------------------------------------------------------------------------------------------------------------------------------
        static FileSystemWatcher watcher = new FileSystemWatcher      //созд экз
        {

            Path = @"D:\Универ\2 курс\ООП\OOPLab13-master\OOPLab13\bin\Debug",    //набл за опред директ
            IncludeSubdirectories = true,
            NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName

        };

        //-----------------------------------------------------------------------------------------------------------------------------------------
        public static void Start()
        {
            //слеж и фикс
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);

            watcher.EnableRaisingEvents = true;

        }

        //-----------------------------------------------------------------------------------------------------------------------------------------
        public static void SearchByDate(string date)                                                                                 //пои инф
        {

            watcher.EnableRaisingEvents = false;

            using (StreamReader sr = new StreamReader("kablogfile.txt"))
            {

                while (!sr.EndOfStream)
                {

                    if (sr.ReadLine().StartsWith(date))
                    {

                        Console.WriteLine(sr.ReadLine());

                    }

                }

            }

        }

        //----------------------------------------------------------------------------------------------------------------------------------------
        private static void OnChanged(object sender, FileSystemEventArgs e)                                              //ук что делать 
        {                                                                                                                   //после изм

            using (StreamWriter sw = new StreamWriter("kablogfile.txt", true))
            {

                sw.WriteLine(DateTime.Now + "   " + e.ChangeType + "    путь: " + e.FullPath);

            }
            Console.Read();

        }

    }

}