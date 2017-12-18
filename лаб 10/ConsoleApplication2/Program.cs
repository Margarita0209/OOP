using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab10
{
    class Human//из л5 для коллекции
    {
        private string name;

        public Human(string name)
        {
            this.name = name;
        }

        public string Name
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

        public void EventHappend()
        {
            Console.WriteLine("Случилось событие");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание коллекции и ее заполнение
            ArrayList array = new ArrayList();
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                array.Add(rand.Next(0, 50)); // [0 - 50]
            }

            // Добавление строки
            string buffer = "hello";
            array.Add(buffer);

            //Удаление элемента
            array.RemoveAt(2);

            //Вывести коллекцию и кол-во элементов
            Console.WriteLine("Количество элементов = " + array.Count + ". Сама коллекция: ");

            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine("Элемент " + i + " = " + array[i]);
            }

            //Поиск по значению
            Console.WriteLine("Введите значение");
            int key = int.Parse(Console.ReadLine());
            Console.WriteLine("Элемент под индексом " + array.IndexOf(key));//-1 - элемент не найден

            //Обобщенная коллекция HashSet<long>
            HashSet<long> set = new HashSet<long>();
            for (int i = 0; i < 5; i++)
            {
                set.Add(rand.Next(0, 50)); // [0 - 50]
            }

            Console.WriteLine("HashSet: " + String.Join(", ", set));


            //Удалить n элементов
            Console.WriteLine("Введите n");
            key = int.Parse(Console.ReadLine());
            for (int i = 0; i < key; i++)
            {
                Console.WriteLine("Введите значение удаляемого элемента");
                int value = int.Parse(Console.ReadLine());
                set.Remove(value);
            }

            Console.WriteLine("HashSet: " + String.Join(", ", set));

            //Добавьте другие элементы (используйте  все  возможные  методы добавления для вашей коллекции)
            //Только Add()

            set.Add(3);

            //Создайте вторую коллекцию (см.таблицу) и заполните ее данными из первой коллекции.
            //LinkedList<T>

            LinkedList<HashSet<long>> list = new LinkedList<HashSet<long>>();
            list.AddFirst(set);

            //Вывод коллекции
            Console.WriteLine("LList: " + list.First.Value); //в связи с особенностью HashSet не
                                                               //можем вывести значения элементов

            //Поиск значения 
            Console.WriteLine("Введите значение элемента");//для поиска тоже самое
            int val = int.Parse(Console.ReadLine());
            Console.WriteLine(list.Find(set));

            //Повторите задание п.2 для пользовательского типа данных
            //(в качестве типа T возьмите любой свой класс  из лабораторной 5 Наследование)

            HashSet<Human> setTwo = new HashSet<Human>();
            Human andrey = new Human("Andrey");
            Human misha = new Human("Misha");

            setTwo.Add(andrey);
            setTwo.Add(misha);


            Human mishaTwo = new Human("Misha");
            setTwo.Remove(mishaTwo);

            Console.WriteLine("HashSet: " + String.Join(", ", setTwo));


            /*
             * Создайте объект наблюдаемой коллекции ObservableCollection<T>.
             * Создайте произвольный метод и зарегистрируйте его на событие  CollectionChange.
             * Напишите демонстрацию с добавлением и удалением элементов.
             * В качестве типа T используйте свой класс из лабораторной No5
             */

            ObservableCollection<Human> observable = new ObservableCollection<Human>();
            observable.CollectionChanged += CollectionChanged;

            observable.Add(misha);
        }

        private static void CollectionChanged(object sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {Console.Read(); }
    }
}

