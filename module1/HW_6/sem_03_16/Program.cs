using System;
using System.Linq;


namespace sem_03_16
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int N;
            if (int.TryParse(Console.ReadLine(), out N))
            {
                Random rnd = new Random();
                int[] a = new int[N];
                for (int i = 0; i < N; i++)
                {
                    a[i] = rnd.Next(100);
                }
                int min = int.MaxValue, max= int.MinValue;
                for(int i = 0; i < N; i++)
                {
                    min = Math.Min(a[i], min);
                    max = Math.Max(a[i], max);
                 }
                foreach (int i in a) Console.Write($"{i} ");
                Console.WriteLine();
                Console.WriteLine($"Index min: {Array.IndexOf(a, min)}");
                Console.WriteLine($"Index min + index max: {Array.IndexOf(a, min) + Array.IndexOf(a, max)}");
            }
            else
            {
                Console.WriteLine("Input error.");
            }
        }
    }
}
