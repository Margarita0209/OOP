using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab14
{

    public partial class Program
    {

        static void Main(string[] args)
        {

            // экземпляр Library для бинарной сериализации/десериализации
            Library binlibrary = new Library("bin", "bin", "bin");
            // экземпляр Library для soap сериализации/десериализации
            Library soaplibrary = new Library("soap", "soap", "soap");
            // экземпляр Library для json сериализации/десериализации
            Library jsonlibrary = new Library("json", "json", "json");
            // экземпляр Library для xml сериализации/десериализации
            Library xmllibrary = new Library("xml", "xml", "xml");

            // демонстрация бинарной сериализации/десериализации, library.dat
            Serializer.BinarySerialization(binlibrary);
            Serializer.BinaryDeserialization();

            // демонстрация soap сериализации/десериализации, library.soap
            Serializer.SoapSerialization(soaplibrary);
            Serializer.SoapDeserialization();

            // демонстрация json сериализации/десериализации, library.json
            Serializer.JSONSerialization(jsonlibrary);
            Serializer.JSONDeserialization(jsonlibrary);

            // демонстрация xml сериализации/десериализации, library.xml
            Serializer.XMLSerialization(xmllibrary);
            Serializer.XMLDeserialization(xmllibrary);
            Console.Read();
        }

    }

}
