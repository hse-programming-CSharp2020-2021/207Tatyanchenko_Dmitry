using System;

namespace task6
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

        public static void S1(ref double s, double x, ref int flag, int i)
        {
            s += flag * (Math.Pow(2, i - 1) * Math.Pow(x, i) / (double)Fact(i));
            flag *= -1;
        }
        public static void S2(ref double s, double x, int i)
        {
            s += (Math.Pow(x, i) / (double)Fact(i));
        }
        public static void Main(string[] args)
        {
          
            double x;
            if (double.TryParse(Console.ReadLine(), out x))
            {
                int i = 2;
                double s = 0;
                double s0 = s;
                int flag = 1;
                S1(ref s, x, ref flag, i);
                while (s != s0)
                {
                    s0 = s;
                    S1(ref s, x, ref flag, i);
                    i += 2;
                };
                Console.WriteLine(s);

                i = 1;
                s = 1;
                s0 = s;
                S2(ref s, x, i);
                while (s != s0)
                {
                    s0 = s;
                    S2(ref s, x, i);
                    i ++;
                };
                Console.WriteLine(s);

            }
            else
            {
                Console.WriteLine("err");
            }
        }
    }
}
