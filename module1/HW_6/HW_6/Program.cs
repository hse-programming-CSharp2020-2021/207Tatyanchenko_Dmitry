using System;
using System.Linq;
using System.Collections.Generic;

namespace sem_03_9
{
    class MainClass
    {
        public static void ArrayHill(ref double[] a)
        {
            double[] b = new double[a.Length];
            Array.Copy(a, b, a.Length);
            Array.Sort(b);
            //foreach (double i in a) Console.Write($"{i} ");
            //foreach (double i in b) Console.Write($"{i} ");
            int first = 0;
            int second = 0;
            int flag = 1;
            for (int i = 0; i < a.Length; i++)
            {
                if (flag == 1)
                {
                    a[first] = b[i];
                    first++;
                }
                else
                {
                    a[a.Length - second - 1 ] = b[i];
                    second++;
                }
                flag *= -1;
            }

        }
        public static void Main(string[] args)
        {
            int N;
            if (int.TryParse(Console.ReadLine(),out N))
            {
                Random rnd = new Random();
                double[] a = new double[N];
                int flag = 1;
                for (int i = 0; i < N; i++)
                {
                    a[i] = flag * 10 * rnd.NextDouble();
                    flag *= -1;
                }
                foreach (double i in a) Console.Write("{0:F3} ", i);
                Console.WriteLine();
                ArrayHill(ref a);
                foreach (double i in a) Console.Write("{0:F3} ", i);
            }
            else 
            {
                Console.WriteLine("Input error.");
             }
        }
    }
}
