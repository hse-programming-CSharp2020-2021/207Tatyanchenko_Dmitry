using System;
using System.IO;

namespace task33
{
    //классная штука, работает за n(Log n), использует бинарный поиск и все дела
    class MainClass
    {
        public static void InpCreate()
        {
            Random rnd = new Random();
            string[] a = new string[rnd.Next(30)];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rnd.Next(0, 10001).ToString();
            }
            File.WriteAllLines("input.txt", a);
        }

        public static int TipaBinPoisk(int[] two, int value, int first, int last)
        {
            //возвращает максимальное значение степени 2, не превышающее заданное положительное значение
            if (first == last)
            {
                return two[last];
            }

            int middle = (first + last) / 2;

            //Console.WriteLine($"{first} {last} {middle}");
            if (two[middle] == value) return two[middle];
            else if (two[middle] > value) return TipaBinPoisk(two, value, first, middle - 1);
            else if (two[middle] < value)
            {
                if (two[middle] * 2 > value) return two[middle];
                else return TipaBinPoisk(two, value, middle + 1, last);
            }

            return 0;
        }

        public static void Main(string[] args)
        {
            InpCreate();
            string[] a = File.ReadAllLines("input.txt");

            int[] two = new int[15];//первая степнеь 2, большаяя 10000 - 2^14
            two[0] = 1;
            for (int i = 1; i < 15; i++)
            {
                two[i] = two[i - 1] * 2;
            }

            int[] b = new int[a.Length];
            string[] output = new string[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                if (Convert.ToInt32(a[i]) == 0) b[i] = 0;
                else b[i] = TipaBinPoisk(two, Convert.ToInt32(a[i]), 0, 14);
                output[i] = b[i].ToString();
            }


            foreach (string str in a) Console.Write($"{str} ");
            Console.WriteLine();
            foreach (int i in b) Console.Write($"{i} ");

            File.WriteAllLines("output.txt", output);
        }
    }
}
