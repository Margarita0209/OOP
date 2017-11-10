using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{   
    public class Owner
    {
        public int id;
        public string name;
        public string organization;
        public Owner(int id, string name, string organization)
        {
            this.id = id;
            this.name = name;
            this.organization = organization;
        }
    }
    static class MathObject
    {
        public static int radical(int a, int b) => (a * b) * (a * b);
        public static int squaringsmm(int a, int b) => (a + b) * (a + b);
        public static int plusmulti(int a, int b) => (a + b) * a * b;
        public static bool isLetter(this String st, char a)
        {
            for (Int32 index = 0; index < st.Length; index++)
            {
                if (st[index] == a)
                {
                    Console.WriteLine("Symbol in the sentence");
                    return true;
                }
            }
            Console.WriteLine("Symbol isn't in the sentence");
            return false;
        }
       public static bool isLetter22(this STRING str, char a)
        {
            for (Int32 index = 0; index < str.str1.Length; index++)
            {
                if (str.str1[index] == a)
                {
                    Console.WriteLine("Symbol in the sentence");
                    return true;
                }
            }
            Console.WriteLine("Symbol isn't in the sentence");
            return false;
        }
        public static void isLetter1(this STRING st)
        { string str2 = "";
            for (Int32 index = 0; index < st.str1.Length; index++)
                if (!char.IsDigit(st.str1[index]))
                {
                    str2 += st.str1[index];
                }
            Console.WriteLine("Deleted.New sentence: "+str2);
        }
        public static void isLetter23(this string st)
        {
            string str2 = "";
            for (Int32 index = 0; index < st.Length; index++)
                if (!char.IsDigit(st[index]))
                {
                    str2 += st[index];
                }
            Console.WriteLine("Deleted.New sentence: " + str2);
        }
    }

    public class STRING
    {
        public string str1;
        public STRING()
        {
            str1 = "hello";
        }
        public STRING(string s)
        {
            str1 = s;
        }
        public static bool operator !=(STRING SS, STRING SS1)// перегрузка !=
        {
            if (SS.str1.Length != SS1.str1.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator ==(STRING SS, STRING SS1)// перегрузка =
        {
            if (SS.str1.Length == SS1.str1.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator true(STRING SS)// перегрузка troe
        {
            for (int i = 0; i < SS.str1.Length; ++i)
            {
                if (SS.str1[i] == '.'|| SS.str1[i] == ',' || SS.str1[i] == ';' || SS.str1[i] == '?' || SS.str1[i] == '!')
                {
                    return true;
                }
            }
            return false;

        }
        public static bool operator false(STRING SS)// перегрузка false
        {

            for (int i = 0; i < SS.str1.Length; ++i)
            {
                if (SS.str1[i] != '.')
                {
                    return true;
                }
            }
            return false;
        }
        public static string operator -(STRING SS)//перегрузка базового оператора -
        {

            SS.str1 = SS.str1.Substring(0, SS.str1.Length - 1);
            return SS.str1;
        }
        Owner information = new Owner(24, "Margarita", "BSTU");
        public void Information()
        {
            Console.WriteLine("Id: "+information.id+". Name: "+information.name +". Organization: "+information.organization+".");
        }
        public class Date
        {
            public string date;
            public Date()// конструктор без параметров
            {
                 date = "30 October 2017";
            }
            public void INFORAMTION()// вывод
            {
                Console.WriteLine("Date: " + date);
            }
     
        }
        class Program
        {
            static void Main(string[] args)
            {
                STRING a = new STRING("hel.lo");
                STRING b = new STRING("people");
                Console.WriteLine(a != b);
                Console.WriteLine(a == b);
                if (a)// проверка на знак припенания
                {
                    Console.WriteLine(true);
                }
                else
                {
                    Console.WriteLine(false);
                }
                STRING c = new STRING("flowers");
                Console.WriteLine(-c);
                STRING f = new STRING();
                f.Information();
                STRING.Date date = new STRING.Date();
                date.INFORAMTION();

                Console.WriteLine("Radical = " + MathObject.radical(10, 10) + " Squaring = " + MathObject.squaringsmm(2, 5) + " Plus and multipliction = " + MathObject.plusmulti(4, 5));

                String strin = "wonder";
                strin.isLetter('o');
                String strin1 = "100 dogs";
                strin1.isLetter23();

                STRING str = new STRING("sun");
                str.isLetter22('s');

                STRING st = new STRING("18 years");
                st.isLetter1();
                Console.Read();
            }
        } 
    }
}
