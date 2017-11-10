using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Создать класс Bus: Фамилия и инициалы водителя, Номер автобуса, 
//Номер маршрута, Год начала эксплуатации. 
//Свойства и конструкторы должны обеспечивать проверку 
//корректности. Добавить метод вывода возраста автобуса. 
//Создать массив объектов. Вывести: 
//a) список автобусов для заданного номера маршрута; 
//b) список автобусов, которые эксплуатируются больше заданного 
//срока; 
namespace lp3
{
    class Bus
    {
        private string familia_driver; /* private- доступ только методам в определяемом типе и вложенных в него*/
        public string Familia_driver/* public- досуп не ограничен ( все методы во всех сборках)*/
        {
            get
            {
                return familia_driver;
            }
            set
            {
                familia_driver = value;
            }
        }
        private string initial_driver;/* закрытое поле*/
        public string Initial_driver/*свойство*/
        {
            get/* способ получения свойства*/
            {
                return initial_driver;
            }
            set/* способ установки свойства*/
            {
                initial_driver = value;/* преоставляет передоваемое значение */
            }
        }
        private int number_bus;
        public int Number_bus
        {
            get
            {
                return number_bus;
            }
            set
            {
                number_bus = value;
            }
        }
        private int number_route;
        public int Number_route
        {
            get
            {
                return number_route;
            }
            set
            {
                number_route = value;
            }
        }
        private string mark;
        public string Mark
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value;
            }
        }
        private int bus_year;
        public int Year
        {
            get
            {
                return bus_year;
            }
            set
            {
                bus_year = value;
            }
        }
        private int mileage;
        public int Mileage
        {
            get
            {
                return mileage;
            }
            set
            {
                mileage = value;
            }
        }
        public static int count = 0;
        public Bus()//без параметров  
        {
            count++;
            Console.WriteLine("Количество объектов: " + count);
        } /* ref-передача переменной по ссылке*/
        public Bus(string familia, string initial, ref int nomer, int znak)//с параметрами 
        {
            familia_driver = familia;
            initial_driver = initial;
            if (nomer < 1 || znak < 1)
            {
                Console.WriteLine("Что-то не так");
            }
            else
            {
                bus_year = nomer;
                number_route = znak;
            }
            count++;
            Console.WriteLine("Фамилия водителя " + familia_driver + "Инициалы водителя " + initial_driver + "Год автобуса: " + bus_year + "Номерной знак: " + number_route);
        }
        public Bus(int god = 2016)//праметры по умолчанию 
        {
            count++;
            bus_year = god;
        }
        static Bus()//статический конструктор 
        {
            Console.WriteLine("Статический конструктор");
        }
        private Bus(int nomer, int znak)//закрытый конструктор 
        {
            this.number_bus = nomer;
            this.number_route = znak;
            this.hesh = this.GetHashCode();//поле только дя чтения 
        }
        public readonly long hesh;
        public int Vozrost()
        {
            int today = 2017;
            return today = bus_year;
        }/* override- переопределение метода*/
        public override bool Equals(object obj)/* проверка на тождество*/
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Bus bus = (Bus)obj;
            return (this.Number_bus == bus.Number_bus && this.Number_route == bus.Number_route);
        }
        public override int GetHashCode()/*Возвращает заданный для объекта хэш-код*/
        {
            int Hash = 269;
            Hash = string.IsNullOrEmpty(Familia_driver) ? 0 : Familia_driver.GetHashCode();
            Hash = (Hash * 47) + Number_bus.GetHashCode();
            return Hash;
        }
        public override string ToString()
        {
            return "Type" + base.ToString() + Familia_driver + " " + Number_bus;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int a = 2013;
            int b = 2016;
            Bus[] bus = new Bus[2];
            bus[0] = new Bus("lala", "l.a.", ref a, 12);
            bus[1] = new Bus("lala", "l.m.", ref b, 142);
            string familia;
            familia = Console.ReadLine();
            for (int i = 0; i < 2; i++)
            {
                if (familia == bus[i].Familia_driver)
                {
                    Console.WriteLine(bus[i]);
                }
            }
            int srok;
            srok = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 2; i++)
            {
                if (srok > bus[i].Vozrost())
                {
                    Console.WriteLine((i + 1) + " Автобус используется больше срока");
                }
                else
                {
                    Console.WriteLine((i + 1) + " Автобус используется меньше срока");
                }
            }
            Console.Read();
        }

    }
    
}

