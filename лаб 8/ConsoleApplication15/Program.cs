using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP8
{ interface IInterface<T>  //обобщенный интерфейс
    {
        void Add(Pechyat t, int index);
        void Delete(int index);
        void Print();  //мб класс,структ, интерф,мет,делег
    }

    public class ArrayClass<T> : IInterface<T> where T : class //наследование 
    {
        public List<Pechyat> list = new List<Pechyat>(); //содерж др обобщ тип
        public void Delete(int index)
        {
            if (index > (list.Capacity - 2) || index < 0)
            {
                throw new Exception1("Указан индекс вне диапазона."); //перегр на осн кол парам(арность)
            }
            list.RemoveAt(index);
        }
        public void Add(Pechyat t, int index)
        {
            if ((index > (list.Capacity - 2) || index < 0) && index != 0)
            {
                throw new Exception1("Указан индекс вне диапазона.");
            }
            list.Insert(index, t);
        }
        public void Print()
        {
            if (list.Capacity == 0)
            {
                throw new Exception2("Список пуст.");
            }
            foreach (Pechyat a in list)
            {
                Console.WriteLine(a);
            }
        }
    }

    public class OOP8
    {
        static void Main(string[] args)
        {
            try
            {
                Pechyat pechyat1 = new Pechyat(100, "Незнайка");
                Pechyat pechyat2 = new Pechyat(150, "Буратино");
                Pechyat pechyat3 = new Pechyat(200, "Золушка");
                ArrayClass<Pechyat> arrayClass = new ArrayClass<Pechyat>();
                arrayClass.Add(pechyat1, 0);
                arrayClass.Add(pechyat2, 1);
                arrayClass.Add(pechyat3, 2);
                arrayClass.Delete(1);
                arrayClass.Print();
            }
            catch (Exception1 e)
            {
                Console.WriteLine(e); //количество индексов
            }
            catch (Exception2 e)// на пустоту списка
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("finally");
                Console.Read();
            }
        }
    }

    public class Pechyat
    {
        int Price;
        string Name;
        public Pechyat(int price, string name)
        {
            Price = price;
            Name = name;
        }
        public override string ToString()
        {
            return base.ToString() + "  " + Price + "  " + Name;
        }
    }
    public class Exception1 : System.Exception
    {
        public Exception1(string message) : base(message)
        {
        }
    }
    public class Exception2 : System.Exception
    {
        public Exception2(string message) : base(message)
        {
        }
    }
}