using System;                                                                                              //проц выяв тип в ход прогрр
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace OOPLab12
{

    interface IShowMePls { }
    interface IMeToo { }

    abstract class Library
    {

        public string BookName { get; set; }   //имя книги
        public string Genre { get; set; }      //жанр книги
        public string Author { get; set; }       //автор

    }

    class Book : Library, IShowMePls, IMeToo
    {

        public void ShowMePls(int firstValue, int secondValue)
        {

            Console.WriteLine("Первый параметр: " + firstValue);
            Console.WriteLine("Второй параметр: " + secondValue);

        }

        public override string ToString()
        {

            return $"{BookName} {Genre} {Author}";                                                                          //получ по ссылке

        }

        public Book()
        {

            BookName = "Евгений Онегин";
            Genre = "Роман в стихах";
            Author = "А.С.Пушкин";

        }

        public Book(string _BookName, string _Genre, string _Author)
        {

            BookName = _BookName;
            Genre = _Genre;
            Author = _Author;

        }

    }

    static class Reflector
    {

        public static void ToFile(string typeName)//вывод содержимого в файл
        {
            Type myType = Type.GetType(typeName);  //поиск указаного типа в модуле

            using (StreamWriter streamWriter = new StreamWriter("ClassInfo.txt"))
            {

                streamWriter.WriteLine("Класс: {0}", typeName);
                streamWriter.WriteLine();

                foreach (MemberInfo memberInfo in myType.GetMembers())
                    streamWriter.WriteLine(memberInfo.ToString());

                streamWriter.WriteLine("-------------------------------------------------------");

            }

        }

        public static MethodInfo[] GetPublicMethods(string typeName) //извлечение методов общедоступных
        {

            return Type.GetType(typeName).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        }

        public static FieldInfo[] GetFieldInfo(string typeName)   //информация о полях
        {

            return Type.GetType(typeName).GetFields();

        }

        public static PropertyInfo[] GetPropertyInfo(string typeName)    //иформация о свойствах
        {

            return Type.GetType(typeName).GetProperties();

        }

        public static Type[] GetInterfaceMapping(string typeName)  //получение реализованных классом интефейсов
        {

            return Type.GetType(typeName).GetInterfaces();

        }

        public static void SpecificMethods(string typeName, string parameterType)  //методы с зад типом параметра
        {

            foreach (MethodInfo methodInfo in Type.GetType(typeName).GetMethods())
            {

                if (methodInfo.ReturnType == Type.GetType(parameterType))
                    Console.WriteLine(methodInfo);
            }

        }

        public static void InvokeMethod(string typeName, string methodName)  //вывод метода с текст файла
        {

            Type myType = Type.GetType(typeName);
            MethodInfo methodInfo = Type.GetType(typeName).GetMethod(methodName);
            
            List<object> parameters = new List<object>();

            using (StreamWriter streamWriter = new StreamWriter("InputParameters.txt"))
            {

                streamWriter.WriteLine(1);
                streamWriter.WriteLine(2);

            }

            using (StreamReader streamReader = new StreamReader("InputParameters.txt"))
            {

                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    parameters.Add(Int32.Parse(line));
                }

            }

            methodInfo.Invoke(Activator.CreateInstance(myType), parameters.ToArray());//создание экземпляра

        }

    }

    class Program//классы
    {
        public const string author = "Margarit Kabanova, DEVY - 9";
        static void Main(string[] args)
        {

            Reflector.ToFile("OOPLab12.Book");

            Console.WriteLine("***** Публичные методы *****");
            
            foreach (MethodInfo methodInfo in Reflector.GetPublicMethods("OOPLab12.Book"))
                Console.WriteLine(methodInfo.ToString());

            Console.WriteLine(" ");

            Console.WriteLine("*****  Поля *****");

            foreach (FieldInfo fieldInfo in Reflector.GetFieldInfo("OOPLab12.Book"))
                Console.WriteLine(fieldInfo.ToString());

            Console.WriteLine(" ");

            Console.WriteLine("***** Свойства *****");

            foreach (PropertyInfo property in Reflector.GetPropertyInfo("OOPLab12.Book"))
                Console.WriteLine(property.ToString());

            Console.WriteLine(" ");

            Console.WriteLine("***** Интерфейсы *****");

            foreach (Type implementedInterfaces in Reflector.GetInterfaceMapping("OOPLab12.Book"))
                Console.WriteLine(implementedInterfaces.ToString());

            Console.WriteLine(" ");

            Console.WriteLine(" ***** Специфичские методы *****");

            Reflector.SpecificMethods("OOPLab12.Book", "System.Void");

            Console.WriteLine(" ");

            Console.WriteLine("***** Рефлекс. Вызов *****");

            Reflector.InvokeMethod("OOPLab12.Book", "ShowMePls");

            Console.WriteLine(" ");
            Console.Read();
        }

    }
}
