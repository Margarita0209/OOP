using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2
{
    class Program
    {
        static float readFloat()
        {
            Console.Write("Введите число: ");
            return float.Parse(Console.ReadLine());
        }

        static Tuple<int, int, int, char> createTuple(int[] arr, string str)
        {
            int min = Int32.MaxValue, max = Int32.MinValue, sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (min > arr[i]) min = arr[i];
                if (max < arr[i]) max = arr[i];
                sum += arr[i];
            }
            return Tuple.Create(min, max, sum, str.ElementAtOrDefault(0));
        }

        static void Main(string[] args)
        {
            byte byteVal = 8;
            sbyte sbyteVal = 8;
            short shortVal = 16;
            ushort ushortVal = 16;
            int intVal = 32;
            uint uintVal = 32;
            long longVal = 64;
            ulong ulongVal = 64;
            float floatVal = 32;
            double doubleVal = 64;
            char charVal = 'б';
            bool boolVal = true;
            decimal decimalVal = 128.5m;
            object objectVal = "objectSring";
            string stringVal = "Это строка";

            //Неявные преобразования
            doubleVal = floatVal;
            longVal = intVal;
            decimalVal = ulongVal;
            uintVal = byteVal;
            objectVal = stringVal;
            //Явные преобразования
            byteVal = (byte)intVal;
            byteVal = Convert.ToByte(longVal);
            ushortVal = (ushort)intVal;
            ulongVal = (ulong)decimalVal;
            doubleVal = Convert.ToDouble(decimalVal);
            //Упаковка
            object intboxed = intVal;
            //Распаковка
            int intunboxed = (int)intboxed;
            //Неявная типизация переменной
            var keyword = 20;
            var maybeDouble = doubleVal;

            int? nullableInt = null;
            Nullable<int> oneMorenullableInt = null;
            bool? someBool = null; //(null|false|true )
            if (someBool == null)
            {
                nullableInt = 10;
            }

            string sVal = "some string";
            string sVal2 = "one more string";
            string sVal3 = "uups";
            if (sVal == sVal2)
            {
                Console.WriteLine("sVal == sVal2");
            }
            if (sVal != sVal2)
            {
                Console.WriteLine("sVal != sVal2");
            }
            if (sVal.CompareTo(sVal2) > 0)
            {
                Console.WriteLine("sVal > sVal2");
            }
            else if (sVal.CompareTo(sVal2) < 0)
            {
                Console.WriteLine("sVal < sVal2");
            }
            sVal3 = String.Concat(sVal3, " ", sVal2);
            Console.WriteLine("String.Concat: " + sVal3);
            sVal3 = String.Copy(sVal2);
            Console.WriteLine("String.Copy: " + sVal3);

            Console.WriteLine("String.Substring: " + sVal3.Substring(2));
            Console.WriteLine("String.Split: ");
            string[] strArr = sVal3.Split(new char[] { ' ' });
            foreach (string substr in strArr)
            {
                Console.WriteLine(substr);
            }
            Console.WriteLine("String.Insert: " + sVal3.Insert(3, " insert"));
            intVal = sVal3.IndexOf("more");
            Console.WriteLine("String.Remove: " + sVal3.Remove(intVal, 5));

            sVal3 = "";
            sVal2 = null;
            if (sVal2 == null) Console.WriteLine(" sVal2 is null");
            if (sVal2 != sVal3) Console.WriteLine("sVal2 != sVal3");
            if (String.IsNullOrEmpty(sVal3) && String.IsNullOrEmpty(sVal2)) Console.WriteLine(" sVal2 and sVal3 is null or empty string");
            Console.WriteLine("sVal3+sVal2: '" + sVal3 + sVal2 + "'");

            StringBuilder sb = new StringBuilder("not very first string");
            Console.WriteLine("StringBuilder starting value: " + sb);
            sb.Remove(0, 4);
            sb.Append(" sufix");
            sb.Insert(0, "prefix ");
            Console.WriteLine("StringBuilder result value: " + sb);

            int[,] arr2d = new int[3, 3];
            arr2d = new int[,] { { 1, 2, 3 }, { 11, 12, 13 }, { 21, 22, 23 } };
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("{0,2} {1,2} {2,2}", arr2d[i, 0], arr2d[i, 1], arr2d[i, 2]);
            }

            string[] arrStr = new string[3];
            arrStr[0] = "String 1";
            arrStr[1] = "String 2";
            arrStr[2] = "String 3";
            Console.WriteLine("Массив строк длиной {0}", arrStr.Length);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(arrStr[i]);
            }
            Console.Write("Номер изменяемой строки:");
            intVal = int.Parse(Console.ReadLine()) % 3;
            Console.Write("Новая строка:");
            arrStr[intVal] = Console.ReadLine();
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(arrStr[i]);
            }

            float[][] arrFl = new float[3][];
            arrFl[0] = new float[2];
            arrFl[1] = new float[3];
            arrFl[2] = new float[4];
            arrFl[0][0] = readFloat();
            arrFl[0][1] = readFloat();
            for (int i = 0; i < 3; i++)
            {
                arrFl[1][i] = readFloat();
            }
            for (int i = 0; i < 4; i++)
            {
                arrFl[2][i] = readFloat();
            }

            Console.WriteLine("{0,5} {1,5}", arrFl[0][0], arrFl[0][1]);
            Console.WriteLine("{0,5} {1,5} {2,5}", arrFl[1][0], arrFl[1][1], arrFl[1][2]);
            Console.WriteLine("{0,5} {1,5} {2,5} {3,5}", arrFl[2][0], arrFl[2][1], arrFl[2][2], arrFl[2][3]);

            var someArr = new int[] { 1, 2, 4, 6, 6 };
            Console.WriteLine(someArr + " размером " + someArr.Length);

            var str = "Here some string";
            Console.WriteLine(str.GetType() + " '" + str + "'");

            var tu = Tuple.Create<int, string, char, string, ulong>(13, "str1", 'W', "str2", 777);
            Console.WriteLine("Tuple: int={0} string={1} char={2} string2={3} ulong={4}", tu.Item1, tu.Item2, tu.Item3, tu.Item4, tu.Item5);
            Console.WriteLine("Tuple partial: int={0} char={1} string2={2}", tu.Item1, tu.Item3, tu.Item4);

            intVal = tu.Item1;
            sVal = tu.Item2;
            charVal = tu.Item3;
            sVal2 = tu.Item4;
            ulongVal = tu.Item5;

            var tu2 = createTuple(someArr, "Ёлки");
            Console.WriteLine("Tuple2 : min={0} max={1} sum={2} char='{3}'", tu2.Item1, tu2.Item2, tu2.Item3, tu2.Item4);

            if (tu.Equals(tu2))
            {
                Console.WriteLine("Tuples are equal");
            }
            else
            {
                Console.WriteLine("Tuples are not equal");
            }

            Console.ReadLine();
        }


    }
}
