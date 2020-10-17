using System;

namespace sem_03_20
{
    class MainClass
    {
        public static void Print(int[] a)
        {
            //printing out an array
            foreach (int i in a) Console.Write($"{i} ");
            Console.WriteLine();
        }
        public static int[] Form()
        {
            //buiding array length N
            int N;
            if (int.TryParse(Console.ReadLine(), out N))
            {
                Random rnd = new Random();
                int[] a = new int[N];
                for (int i = 0; i < N; i++)
                {
                    a[i] = rnd.Next(10, 101);
                }
                return a;
            }
            else
            {
                Console.WriteLine("Input error.");
                return new int[0];
            }
        }
        public static void ArrayItemDouble(ref int[] a, int x)
        {
            //processing the array
            for (int i = 0; i < a.Length; i++) a[i] = x;
        }
        public static void Main(string[] args)
        {
            int[] a = Form();
            Print(a);
            int x;
            if (int.TryParse(Console.ReadLine(), out x))
            {
                ArrayItemDouble(ref a, x);
                Print(a);
            }
            else
            {
                Console.WriteLine("Input error.");
            }
        }
    }
}
