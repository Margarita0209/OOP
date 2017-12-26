using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOPLab13
{
    static class KABFileInfo                                                                                                       //метод
    {
        public static void FullPath(string path)
        {

            FileInfo fileInfo = new FileInfo(path);

            Console.WriteLine("Полный путь к файлу {0}: {1}", fileInfo.Name, fileInfo.FullName);
            Console.WriteLine();

        }

        //---------------------------------------------------------------------------------------------------------------------------базов.инф
        public static void BasicFileInfo(string path)
        {

            FileInfo fileInfo = new FileInfo(path);

            Console.WriteLine("Имя файла: {0}", fileInfo.Name);
            Console.WriteLine("Расширение файла: {0}", fileInfo.Extension);
            Console.WriteLine("Размер файла: {0}", fileInfo.Length);
            Console.WriteLine();

        }

        //-------------------------------------------------------------------------------------------------------------------------------------
        public static void CreationTime(string path)
        {

            FileInfo fileInfo = new FileInfo(path);

            Console.WriteLine("Время создания файла {0}: {1}", fileInfo.Name, fileInfo.CreationTime);
            Console.WriteLine();

        }

    }

}

