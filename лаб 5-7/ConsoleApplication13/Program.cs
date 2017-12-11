using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
// 4 variant 5-7
namespace ConsoleApp1
{
    interface IHistory // интерфейс - набор абстрактных членов(методов, свойств и тд.), которые должны быть реализованы в производнных классах.
    {// можно создать объект интерфейса
        void Info();
    }
    interface ITakoije // интерфейс для работы с одноименным методом
    {
        void TotJe();
    }
    enum Color
    {
        Белая, Красная, Розовая, Желтая, Персиковая
    }
    struct Info
    {
        public string date;
        public string sost;
        public string end;
    }

    public abstract class Plant // абстрактный класс cлужит только для порождения потомков-предоставляют базовый функционал для классов-наследников.
    {// нельзя создать объект          зад интерф для всей иерарх. опред полиморфный интерфейс.
        protected string type;
        protected string rose;
        protected string kaktus;

        public Plant()//конструктор 
        {
            rose += "Розы впервые начали выращивать в Древнем Риме,\nхотя основное назначение садов того времени было выращивание полезных растений.";
            kaktus += "Кактусы — семейство многолетних цветковых растений порядка Гвоздичноцветные.\nСчитается, что кактусы выделились эволюционно около 30—35 млн лет назад.";
        }

        public string Type // св-ва
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public override string ToString() // переопределяем метод + так же набр парам,не статик и абстр,если не вирт переопр нельзя
        {
            return "Type " + base.ToString() + " " + Type; // обращение к скрытым членам. base кнструкторы не наследуются
        }
        public abstract void ToConsole(); // метод абстрактного класса
        public abstract void TotJe(); // метод ОДНОИМЕННЫЙ ( в интерфейсе такой же)

    }
    class Flower : Plant, ITakoije  //базовый класс или суперкласс
    {
        protected string typeofflower; // поле тип цветка
        protected string color;
        protected int price;

        public Flower(string clr, int pr) // конструктор . и если треб указ парам,долж б вызв явным образом в списк инициализ
        {
            type = "Цветок";
            Debug.Assert(clr.CompareTo("Бесцветный") != 0, "ошибочка тут у нас нашли бесцветный цветок");
            color = clr;
            if (pr < 0)
            {
                throw new PriceException("Ошибка! Неверно указана цена!");   //наследование пользовательских типов иск от станд классов
            }
            else
                price = pr;
        }
        public string Typeofflower //св-ва
        {
            get
            {
                return typeofflower;
            }
            set
            {
                typeofflower = value;
            }
        }
        public string Color //св-ва
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        public int Price //св-ва
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new PriceException("Ошибка! Неверно указана цена!");
                }
                else
                {
                    price = value;
                }
            }
        }
        public override void ToConsole() // производный класс обязан переопределить и реализовать все абстрактные методы
        {
            Console.WriteLine(this.ToString()); //вызов методов по типу ссылки
        }
        public override void TotJe() // работа с ОДНОИМЕННЫМ методом
        {
            Console.WriteLine("Я одноименный метод(абстрактный)!");
        }
        void ITakoije.TotJe() // работа с ОДНОИМЕННЫМ методом
        {
            Console.WriteLine("Я тоже одноименный метод(я из интерфейса)!");
        }
    }
    sealed partial class Bush : Plant // КУСТ Бесплодный ( запечатанный) класс,запр насл
    {
        protected string typeofbush; // тип куста

        public Bush() // конструктор
        {
            type = "Куст";
        }
        public string Typeofbush // св-ва
        {
            get
            {
                return typeofbush;
            }
            set
            {
                typeofbush = value;
            }
        }
        //переопределим ToString (cтроковое представление объекта)
        public override string ToString()
        {
            return "Type " + base.ToString() + " " + Typeofbush;
        }
        //переопределим Equals
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            Bush odin = (Bush)obj;
            return (this.Typeofbush == odin.Typeofbush);
        }
        public override void TotJe()
        {
            Console.WriteLine("Я одноименный метод(абстрактный)!");
        }
    }
    class Rose : Flower, IHistory
    {
        protected string name; // Имя розы . protected модиф дост к член
        public Rose(string n, string clr, int a) : base(clr, a) // конструктор
        {
            typeofflower = "Роза";
            name = n;
            price = a;
            color = clr;
        }
        public string Name // св-ва
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }


        public override void ToConsole()
        {
            Console.WriteLine(this.ToString());
        }
        public void Info() // реализуем метод интерфейса
        {
            Console.WriteLine(rose);
        }
    }

    class Tulpan : Flower
    {
        protected string name; // Имя тюльпана

        public Tulpan(string n, string clr, int a) : base(clr, a) // конструктор
        {
            typeofflower = "Тюльпан";
            name = n;
            color = clr;
            price = a;
        }
        public string Name // св-ва
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }


        public override void ToConsole()
        {
            Console.WriteLine(this.ToString());
        }
    }
    partial class Bush : Plant
    {
        //переопределим гетхеш
        public override int GetHashCode()
        {
            int hash = Typeofbush.GetHashCode();
            hash *= 31;
            return hash;
        }
        // производный класс обязан переопределить и реализовать все абстрактные методы
        public override void ToConsole()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class Kaktus : Flower, IHistory // цветок кактус наследует интерфейс хистори

    {
        protected string name; // имя кактуса

        public Kaktus(string n, string clr, int a) : base(clr, a) // конструктор
        {
            typeofflower = "Кактус";
            name = n;
            color = clr;
            price = a;
        }
        public string Name // св-ва
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public override void ToConsole() // производный класс обязан переопределить и реализовать все абстрактные методы
        {
            Console.WriteLine(this.ToString());
        }
        public void Info() //  реализуем метод интерфейса
        {
            Console.WriteLine(kaktus);
        }
    }
    class Paper
    {
        protected string type; // тип бумаги

        public Paper() // конструктор
        {
            type = "тип бумаги";
        }
        public string Type // св-ва
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

    }

    class Buket : Paper  //контейнер            сортировки, цветок по цвету
    {
        private List<Flower> data;   //комптатор обектов

        public Buket(params Flower[] values)
        {
            data = new List<Flower>(values.Length);
            Kaktus kak = new Kaktus("Круглый", "Пушистый", 5);
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].GetType() == kak.GetType())
                {
                    throw new KaktusException("Обнаружена ошибка! Кактус не подходит для букета");
                }
                else
                {
                    data.Add(values[i]);
                }
            }
        }
        public void AddFlower(Flower a)
        {
            data.Add(a);
        }
        public int FindPrice()
        {
            int summ = 0;
            foreach (Flower flower in data)
            {
                summ += flower.Price;
            }
            return summ;
        }
        public void ToConsole()
        {
            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine("Flower[{0}] = {1} {2}р.", i, data[i].Typeofflower, data[i].Price);
            }
        }
        public void SortByPrice()
        {
            data.Sort((x, y) => x.Price.CompareTo(y.Price));
        }
        public List<Flower> FindColor(string color)
        {
            List<Flower> lst = new List<Flower>();
            foreach (Flower flower in data)
            {
                if (flower.Color == color)
                {
                    lst.Add(flower);
                }
            }
            return lst;
        }
        public void ToConsoleList(List<Flower> flower)
        {
            for (int i = 0; i < flower.Count; i++)
            {
                Console.WriteLine("Flower[{0}] = {1} {2}", i, flower[i].Typeofflower, flower[i].Color);
            }

        }
    }

    public static class Printer
    {
        public static void iAmPrinting(Plant plant)    //полиморфный метод, наб член класса,кот мб переопред в класс наследник
        {
            Console.WriteLine(plant.GetType());
            Console.WriteLine(plant.ToString());
        }
    }

    class KaktusException : Exception
    {
        public KaktusException(string message)
            : base(message) { }
    }
    class LOLException : Exception
    {
        public LOLException(string message) : base(message) { }
    }
    class PriceException : Exception
    {
        public PriceException(string message)
            : base(message) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rose roza = new Rose("Колючая", "Бесцветный", 6);  //автомат вызов конструтора базового класса
            Rose roza2 = new Rose("Колючка", "Белый", 8);
            Tulpan tulpan = new Tulpan("Снежок", "Красный", 2);
            Kaktus kaktus = new Kaktus("Высокий", "Зеленый", 1);
            Bush bush = new Bush();
            Paper paper = new Paper();
            Console.WriteLine(roza.Type + " " + roza.Typeofflower + " " + roza.Name);
            kaktus.Name = "Колючий";
            Console.WriteLine(kaktus.Type + " " + kaktus.Typeofflower + " " + kaktus.Name);
            Console.WriteLine("------------------");
            roza.ToConsole();
            roza.Info();
            Console.WriteLine("------------------");
            kaktus.ToConsole();
            kaktus.Info();
            Console.WriteLine("------------------");
            // работа с одноименными методами
            roza.TotJe();
            ((ITakoije)roza).TotJe();
            // .

            Console.WriteLine("------------------");
            ((kaktus as ITakoije)).TotJe(); // as преобр типа в ссылочн тип, рассм тольк преобр ссылок или преобр с упаковк
            kaktus.TotJe();
            if (!(roza is Paper)) // Возвращает булевское значение, говорящее, можете ли вы преобразовать данное выражение в указанный тип,
                                  //никогда не генерирует исключение, с пом них можн провер поддерж интерфейса
            {
                Console.WriteLine("Роза - НЕ БУМАГА.");
            }
            Console.WriteLine("------------------");
            Printer.iAmPrinting(roza);
            Printer.iAmPrinting(kaktus);
            Printer.iAmPrinting(bush);
            Console.WriteLine("--00--00---- 6-aя лаба ----00--00--");
            Rose rose2 = new Rose("Мимоза", "Белый", 3);
            Console.WriteLine(roza.Type + " " + roza.Typeofflower + " " + roza.Name + " ");
            Info rose;
            rose.date = "30.10.2017";
            rose.sost = "Нормальное";
            rose.end = "7.11.2017";
            Console.WriteLine("Информация о розе: Дата привоза: " + rose.date + " Состояние : " + rose.sost + " Завянет: " + rose.end);
            Buket kek = new Buket(rose2, roza, roza2, tulpan);
            Console.WriteLine(kek.FindPrice());
            kek.ToConsole();
            Console.WriteLine("Сортировка по цене:");
            kek.SortByPrice();
            kek.ToConsole();
            Console.WriteLine("Поиск по цвету");
            kek.ToConsoleList(kek.FindColor("Красный"));
            Console.WriteLine("--00--00---- 7-aя лаба ----00--00--");
            try                                                                                        //контролируемый блок
            {
                Buket buketik = new Buket(roza, kaktus, tulpan);
            }

            catch (KaktusException ex)                                                               //обработчик исключений
            {
                Console.WriteLine(ex.Message);

            }
            catch (LOLException f)
            {
                Console.WriteLine(f.Message);

            }
            finally                                                                                       //код, очищ ресурсы и др действия
            {

                Buket buketik = new Buket(roza, tulpan);
                buketik.ToConsole();
            }
            try
            {
                Rose rozka = new Rose("Дешёвая", "Тусклый", -2000);
            }
            catch (PriceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("End.");
            }
                        Console.ReadKey();
        }
    }
}
