using System;

namespace sem_03_13
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int A;
            int K;
            if (int.TryParse(Console.ReadLine(), out A) && int.TryParse(Console.ReadLine(), out K) && K <= A && K >= 1)
            {
                int[] a = new int[A];
                for (int i = 0; i < A; i++) a[i] = i;
                for (int i = K; i < A; i += K) Console.Write($"{a[i]} ");
            }
            else
            {
                Console.WriteLine("Input error.");
            }
        }
    }
}
