using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cLab9
{
    class Director
    {
        public delegate void MyDelegate(int value); //Делегат

        public event MyDelegate onRaise; //События

        public event MyDelegate onPenalty;

        public event MyDelegate onOut;

        public void Raise(int value) => onRaise(value); //Вызов события и лямбда-выражения

        public void penalty(int value) => onPenalty(value);

        public void Out() => onOut(0);
    }

    class Employee
    {
        private string name;

        private int salary;

        public Employee(string name)
        {
            this.name = name;
            salary = 100;
        }

        public void Raise(int value) => salary += value; //Лямбда-выражения

        public void Penalty(int value) => salary -= value;

        public void Info(int value) => Console.WriteLine(name + " зарплата: " + salary);
    }

    class Program
    {
        static void Act(int x1, int x2, Action<int, int> act) => act(x1, x2); // для action

        public static int Func(int x1, Func<int, int> func) //для func
        {
            return func(x1);
        }

        static void Main()
        {
            Director Misha = new Director();

            Employee Vasiliy = new Employee("Василий");
            Employee Andrey = new Employee("Андрей");
            Employee Anton = new Employee("Антон");

            Misha.onOut += Vasiliy.Info; //Подписались на событие
            Misha.onOut += Andrey.Info;
            Misha.onOut += Anton.Info;

            Misha.onRaise += Vasiliy.Raise;
            Misha.onRaise += Andrey.Raise;

            Misha.onPenalty += Andrey.Penalty;

            Misha.Raise(70); // Вызов методов, которые вызывают события
            Misha.penalty(110);
            Misha.Out();

            Action<int, int> x;
            x = (int a, int b) => { int c = a * b; };

            Act(10, 20, x); // 200 Action

            Console.WriteLine("Func - " + Func(10, v => v * 20));//func

            string myString = "Привет, мир!";



            myString = myString.UpperCase();
            myString = myString.Punctuation();
            myString = myString.Gaps();

            Console.WriteLine("Строка:" + myString);

        } 
    }

    public static class Extensions//Методы для обработки строк
    {
        public static string UpperCase(this String str)//Перевод всей строки в верхний регистр
        {
            return str.ToUpper();
        }

        public static string Punctuation(this String str)//Удаление ,
        {
            char[] buffer = new char[256];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ',')
                {
                    buffer[i] = ' ';
                }
                else buffer[i] = str[i];
            }

            string s = new string(buffer);
            return s;
        }

        public static string Gaps(this String str) //Удаление лишних пробелов 
        {
            char[] buffer = new char[256];
            int correction = 0;
            bool space = false;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    if (space)
                    {
                        correction++;
                        space = false;
                    }
                    else
                    {
                        space = true;
                        buffer[i - correction] = ' ';
                    }
                }
                else buffer[i - correction] = str[i];
            }
           

            string s = new string(buffer);
            Console.Read();
            return s;
            
        }
        
    }
}
