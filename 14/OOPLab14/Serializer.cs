using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;


namespace OOPLab14
{
 /*
     * при xml сериализации/десиализации необходимы 3 условия:
     *          1) класс должен иметь стандартный конструктор без параметров
     *          2) сериализоваться будут только открытые члены, другие будут игнорироваться
     *          3) классы не могут быть abstract и т.д.
    */

    partial class Program
    {
        
        public static class Serializer// содерж метод для всех видов сер/десер
        {


            public static void BinarySerialization(object obj)       // бинарн сериал
            {

                BinaryFormatter bf = new BinaryFormatter();

                using (FileStream fs = new FileStream("book.dat", FileMode.OpenOrCreate))
                {

                    bf.Serialize(fs, obj);

                    Console.WriteLine($"бинарная сериализация: объект {obj.ToString()} был сериализован");

                }

            }
       

            public static void BinaryDeserialization()         // бин десериал
            {

                BinaryFormatter bf = new BinaryFormatter();

                using (FileStream fs = new FileStream("book.dat", FileMode.OpenOrCreate))
                {

                  Library newbook = (Library)bf.Deserialize(fs);

                    Console.WriteLine($"бинарная десериализация: объект {newbook.ToString()} был десериализован\n");

                }

            }

  
            public static void SoapSerialization(object obj)    // soap сериал
            {

                SoapFormatter sf = new SoapFormatter();

                using (FileStream fs = new FileStream("book.soap", FileMode.OpenOrCreate))
                {

                    sf.Serialize(fs, obj);

                    Console.WriteLine($"soap сериализация: объект {obj.ToString()} был сериализован");

                }

            }
      

            public static void SoapDeserialization()    // soap десер
            {

                SoapFormatter sf = new SoapFormatter();

                using (FileStream fs = new FileStream("book.soap", FileMode.OpenOrCreate))
                {

                    Library newbook = (Library)sf.Deserialize(fs);

                    Console.WriteLine($"soap денсериализация: объект {newbook.ToString()} был десериализован\n");

                }

            }

  

            public static void JSONSerialization(object obj)     // json сериал
            {

                DataContractJsonSerializer jf = new DataContractJsonSerializer(obj.GetType());

                using (FileStream fs = new FileStream("book.json", FileMode.OpenOrCreate))
                {

                    jf.WriteObject(fs, obj);

                    Console.WriteLine($"json сериализация: объект {obj.ToString()} был сериализован");

                }

            }
       

            public static void JSONDeserialization(object obj)      // json десер
            {

                DataContractJsonSerializer jf = new DataContractJsonSerializer(obj.GetType());

                using (FileStream fs = new FileStream("book.json", FileMode.OpenOrCreate))
                {

                    Library newbook = (Library)jf.ReadObject(fs);

                    Console.WriteLine($"json десериализация: объект {newbook.ToString()} был десериализован\n");

                }

            }


            public static void XMLSerialization(object obj)    // xml сер
            {

                XmlSerializer xs = new XmlSerializer(obj.GetType());

                using (FileStream fs = new FileStream("book.xml", FileMode.OpenOrCreate))
                {

                    xs.Serialize(fs, obj);

                    Console.WriteLine($"xml сериализация: объект {obj.ToString()} был сериализован");

                }

            }
           

            public static void XMLDeserialization(object obj)   // xml десер
            {

                XmlSerializer xs = new XmlSerializer(obj.GetType());

                using (FileStream fs = new FileStream("book.xml", FileMode.OpenOrCreate))
                {

                    Library newbook = (Library)xs.Deserialize(fs);

                    Console.WriteLine($"xml десериализация: объект {newbook.ToString()} был десериализован\n");

                }

            }

        }

    }

}
