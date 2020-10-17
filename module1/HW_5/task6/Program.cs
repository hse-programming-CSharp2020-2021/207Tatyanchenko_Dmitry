using System;
using System.Linq;
using System.Collections.Generic;

namespace task6
{
    class MainClass
    {
        public static void Comp(ref List<int> a, int i, ref int count)
        {
            if ((a[i] + a[i + 1]) % 3 == 0)
            {
                a.Insert(i, a[i] * a[i + 1]);
                a.RemoveAt(i + 1);
                a.RemoveAt(i + 1);
                count++;
            }
        }
        public static int[] CompWhile(int[] list)
        {
            List<int> a =
             list.ToList();
            List<int> b = new List<int>();
            b.AddRange(a);
            int count = 0;
            do
            {
                b.Clear();
                b.AddRange(a);
                int i = 0;
                while (i < a.Count() - 1)
                {
                    Comp(ref a, i, ref count);
                    i++;
                }
            } while (!a.SequenceEqual(b));
            Console.WriteLine(count);
            return a.ToArray();
        }
        public static void Main(string[] args)
        {
            int N;
            Random rnd = new Random();
            if (int.TryParse(Console.ReadLine(), out N))
            {
                int[] initial = new int[N];
                for (int i = 0; i < N; i++)
                {
                    initial[i] = rnd.Next(-10, 11);
                }
                foreach (int i in initial) Console.Write($"{i} ");
                Console.WriteLine();
                foreach (int i in CompWhile(initial)) Console.Write($"{i} ");
            }
            else
            {
                Console.WriteLine("err");
            }
        }
    }
}
