using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OOPLab13
{

    class Program
    {

        static void Main(string[] args)
        {

            // Начало слежения за Debug в папке с программой
            Thread thread = new Thread(KABLog.Start);
            thread.Start();

            // Демонстрация работы KABDiskInfo
            KABDiskInfo.FreeSpace("C:\\");
            KABDiskInfo.FileSystemInfo("C:\\");
            KABDiskInfo.DrivesFullInfo();

            // Демонстрация работы KABDirInfo
            KABDirInfo.FileCount(@"D:\Универ\2 курс\черчение");                                                                            //кол ф
            KABDirInfo.CreationTime(@"D:\Универ\2 курс\черчение");
            KABDirInfo.SubdirectoriesCount(@"D:\Универ\2 курс\черчение");                                                                 //подкат
            KABDirInfo.ParentDirectory(@"D:\Универ\2 курс\черчение");

            // Демонстрация работы KABFileInfo
            KABFileInfo.FullPath(@"D:\Downloads\vs_community_RUS.exe");
            KABFileInfo.BasicFileInfo(@"D:\Downloads\vs_community_RUS.exe");
            KABFileInfo.CreationTime(@"D:\Downloads\vs_community_RUS.exe");

            // Демонстрация работы KABFileManager
            KABFileManager.InspectDrive(@"D:\");
            KABFileManager.CopyFiles(@"D:\diff_files", ".txt");
            KABFileManager.ArchiveUnarchive();

            // Остановка процесса наблюдения
            thread.Abort();

            // Удаление каталогов
            Console.WriteLine("Удалить каталоги? 1 - да");

            int key = int.Parse(Console.ReadLine());

            if (key == 1)
            {

                System.IO.Directory.Delete("KABInspect", true);
                System.IO.Directory.Delete("Unzipped", true);

            }

            // Демонстрация работы KABLog
            KABLog.SearchByDate("26.12.2017");

        }

    }

}
