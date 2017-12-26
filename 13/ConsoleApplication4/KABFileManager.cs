using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace OOPLab13
{
    static class KABFileManager                                                                                               //файл и директ
    {


        //-------------------------------------------------------------------------------------------------------------------
        public static void InspectDrive(string driveName)
        {

            DirectoryInfo dir = new DirectoryInfo(driveName);
            FileInfo[] file = dir.GetFiles();

            Directory.CreateDirectory(@"KABInspect");

            using (StreamWriter sw = new StreamWriter(@"KABInspect\kabdirinfo.txt"))// Зап сод 1-ого уровня ук д
            {
                foreach (DirectoryInfo d in dir.GetDirectories())
                    sw.WriteLine(d.Name);

                foreach (FileInfo f in file)
                    sw.WriteLine(f.Name);
            }

            File.Copy(@"KABInspect\kadirinfo.txt", @"KABInspect\kabdirinfo_renamed.txt");
            File.Delete(@"KABInspect\kabdirinfo.txt");

        }

        //------------------------------------------------------------------------------------------------------------------------
        public static void CopyFiles(string path, string ext)
        {

            string dirpath = @"KABFiles";                                                                                       //созд папку

            Directory.CreateDirectory(dirpath);

            DirectoryInfo di = new DirectoryInfo(path);

            FileInfo[] files = di.GetFiles();

            foreach (FileInfo file in files)     //коп ук ф из зад  пути по зад расш
            {                                     //и перем в п файлз

                if (file.Extension == ext)
                    file.CopyTo($@"{dirpath}\{file.Name}");

            }

            Directory.Move(@"KABFiles", @"KABInspect\KABFiles");

        }


        //------------------------------------------------------------------------------------------------------------------------архив разорх
        public static void ArchiveUnarchive()
        {

            string dirpath = @"KABInspect\KABFiles";
            string zippath = @"KABInspect\KABFiles.zip";
            string unzippath = @"Unzipped";

            //ZipFile.CreateFromDirectory(dirpath, zippath);
           // ZipFile.ExtractToDirectory(zippath, unzippath);

        }

    }

}
