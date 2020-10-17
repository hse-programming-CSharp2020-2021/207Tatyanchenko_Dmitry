using System;

namespace sem_03_11
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int N;
            if (int.TryParse(Console.ReadLine(), out N))
            {
                if (N >= 2)
                {
                    int[] a = new int[N];
                    a[0] = 0;
                    a[1] = 1;
                    for (int i = 2; i < N; i++)
                    {
                        a[i] = 34 * a[i - 1] - a[i - 2] + 2;
                    }
                    foreach (int i in a) Console.Write($"{i} ");
                }
                else
                {
                    Console.WriteLine("N<2");
                }

            }
            else
            {
                Console.WriteLine("Input error.");
            }
        }
    }
}
