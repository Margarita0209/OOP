using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOPLab13
{
    static class KABDiskInfo
    {
        //------------------------------------------------------------------------------------------------------------------------
        public static void FreeSpace(string driveName)
        {

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {

                if (drive.Name == driveName && drive.IsReady)
                    Console.WriteLine("Доступный объем на диске {0} : {1}", driveName.First(), drive.AvailableFreeSpace);

            }

            Console.WriteLine();

        }

        //---------------------------------------------------------------------------------------------------------------
        public static void FileSystemInfo(string driveName)
        {

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {

                if (drive.Name == driveName && drive.IsReady)
                    Console.WriteLine("Тип файловой системы и формат диска {0} : {1}, {2}", driveName.First(), drive.DriveType, drive.DriveFormat);

            }

            Console.WriteLine();

        }
        //---------------------------------------------------------------------------------------------------------------

        public static void DrivesFullInfo()
        {

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {

                if (drive.IsReady)
                {

                    Console.WriteLine("Имя: {0}", drive.Name);
                    Console.WriteLine("Объем: {0}", drive.TotalSize);
                    Console.WriteLine("Доступный объем: {0}", drive.AvailableFreeSpace);
                    Console.WriteLine("Метка тома: {0}", drive.VolumeLabel);

                }

                Console.WriteLine();

            }

            Console.WriteLine();

        }

    }

}
