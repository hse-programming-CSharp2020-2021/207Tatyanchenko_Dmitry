using System;
using System.Collections.Generic;

namespace task4
{
    class MainClass
    {
        public static int[] Massiv(int a0)
        {
            int i = 0;
            List<int> a = new List<int>();
            a.Add(a0);
            while (a[i] != 1)
            {
                a.Add(a[i] % 2 == 0 ? a[i] / 2 : 3 * a[i] + 1);
                i++;
             }
            return a.ToArray();

        }
        public static void Print(int[] a)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]} ");
                count++;
                if (count == 5)
                {
                    count = 0;
                    Console.WriteLine();
                }
            }

        }
        public static void Main(string[] args)
        {
            int x;
            if (int.TryParse(Console.ReadLine(), out x))
            {
                Print(Massiv(x));
            }
            else
            {
                Console.WriteLine("err");
            }
        }
    }
}
