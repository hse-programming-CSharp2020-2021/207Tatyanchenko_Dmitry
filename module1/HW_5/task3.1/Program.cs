using System;

namespace task3
{
    class MainClass
    {
        public static double Fact(int a)
        {

            double fact = 1;
            for (int i = 1; i <= a; i += 1)
            {
                fact *= i;
            }
            return fact;
        }

        public static double[] Sin1(int N)
        {
            int flag = 1;
            double[] sin = new double[N];
            for (int i = 1; i < N; i++)
            {
                sin[i] = (double)flag / (double)Fact(2*i-1);
                flag *= -1;
            }
            return sin;
        }
        public static double SinX(double[] sin,double x)
        {
            double rez = 0;
            for (int i = 0; i < sin.Length; i++)
            {
                rez += Math.Pow(x,2*i-1) * sin[i];
            }
            return rez;
        }
        public static void Main(string[] args)
        {
            //вычисляем по усл
            double x;
            int N;
            if (double.TryParse(Console.ReadLine(), out x) && int.TryParse(Console.ReadLine(), out N) && N >= 0)
            {
                Console.WriteLine(SinX(Sin1(N), x));
            }
            else
            {
                Console.WriteLine("err");
            }

            //вычисляем нашими методами с точностью до машинного нуля и сравниваем с методом библиотеки Math

            if (double.TryParse(Console.ReadLine(), out x))
            {
                int k = 10;
                while (SinX(Sin1(k), x) != SinX(Sin1(k + 1), x)) k++;
                Console.WriteLine(SinX(Sin1(k), x));
                Console.WriteLine(Math.Sin(x));
            }
            else
            {
                Console.WriteLine("err");
            }
        }
    }
}
