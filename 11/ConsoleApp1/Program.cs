using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    public class Stack
    {
        //Создайте коллекцию List<T> и параметризируйте ее типом
        public List<int> stack;
        public Stack(List<int> numbers)
        {
            this.stack = numbers;
            MakeStack();
        }
        public int Length
        {
            get { return stack.Count; }
        }
        private void MakeStack()
        {
            stack.Reverse();
        }
        public bool inNegative()
        {
            bool isNegative = false;
            for (int i = 0; i < stack.Count; i++)
            {
                if (stack[i] < 0)
                {
                    isNegative = true;
                    return isNegative;
                }
            }
            return isNegative;
        }
        public int GetTop()
        {
            return stack[0];
        }
        public int GetMin()
        {
            return stack.Min();
        }
        public int GetMax()
        {
            return stack.Max();
        }
        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < stack.Count; i++)
            {
                sum += stack[i];
            }
            return sum;
        }
        public void Print()
        {
            foreach (int element in stack)
            { Console.Write(element + " "); }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] year = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int n = 4;
            var length = from month in year where month.Length == n select month;// где длинна месяца 4
            var alphabeth = from month in year orderby month select month;// по алфовиту
            var WinSummer = from month in year// зима и лето
                               where month == year[0] || month == year[1] || month == year[7] || month == year[11] ||month == year[5] || month == year[6] 
                               select month;
            var u = from month in year where month.Contains('u') && month.Length >= 4 select month;// поиск буквы
            Console.WriteLine("По алфавиту");
            foreach (string months in alphabeth)
            { Console.WriteLine(months); }
            Console.WriteLine("\nПо длине строки,равной 4");
            foreach (string months in length)
            { Console.WriteLine(months); }
            Console.WriteLine("\nС буквой 'u' ");
            foreach (string months in u)
            { Console.WriteLine(months); }
            Console.WriteLine("\nЗимние и летние месяцы");
            foreach (string months in WinSummer)
            { Console.WriteLine(months); }
            //-----------------------------------Stack---------------------
            Console.WriteLine("\nРабота со стеком");
            List<int> numbers0 = new List<int>() { -899, 1, 3, 6, 7 };
            Stack firstStack = new Stack(numbers0);
            List<int> numbers = new List<int>() { -128, -64, -56, -42, -27 };
            Stack secondStack = new Stack(numbers);
            List<int> numbers3 = new List<int>() { 0 };
            Stack fifthStack = new Stack(numbers3);
            List<int> numbers4 = new List<int>() { -158, -56, -27 };
            Stack sixthStack = new Stack(numbers4);
            Stack[] stacks = new Stack[4];
            stacks[0] = firstStack;
            stacks[1] = secondStack;
            stacks[2] = fifthStack;
            stacks[3] = sixthStack;
            var minMaxTop = from stack in stacks where stack.GetTop() == stack.GetMin() || stack.GetTop() == stack.GetMax() select stack;
            Console.WriteLine("Максимальный минимальный элементы");
            foreach (var stack in minMaxTop)
            { stack.Print(); }
            Console.WriteLine("\nОтрицательные стеки");
            var negative = from stack in stacks where stack.inNegative() select stack;
            foreach (var stack in negative)
            { stack.Print(); }
            Console.WriteLine("\nДлина наименьшего стека");
            var minStack = stacks.Min(stack => stack.Length);
            Console.WriteLine(minStack);
            Console.WriteLine("\nСтеки с длиной до 3");
            var oneThreeLength = from stack in stacks where stack.Length == 1 || stack.Length == 3 select stack;
            foreach (var stack in oneThreeLength)
            { stack.Print(); }
            Console.WriteLine("\nПо сумме элементов");//минимальная
            var sortedStack = from stack in stacks orderby stack.Sum() select stack;
            foreach (var stack in sortedStack)
            { stack.Print(); Console.Read();}


        }
    }
}

                  
