using System;

namespace task10_3
{
    class MainClass
    {
        public static double dx = 0.05;
        public static double y(double x, double a, double b, double c)
        {
            if (x < 1.2) return a * x * x + b * x + c;
            if (x == 1.2) return a / x + Math.Sqrt(x * x + 1);
            if (x > 1.2) return (a + b * x) / Math.Sqrt(x * x + 1);
            return 0;
        }



        public static void Table()
        {

            double a, b, c;
            if (double.TryParse(Console.ReadLine(), out a) &&
                double.TryParse(Console.ReadLine(), out b) &&
                double.TryParse(Console.ReadLine(), out c))
            {
                Console.Write($"y: ");
                for (double x = 1; x < 2; x += dx)
                {

                    Console.Write("{0:F2} ", y(x, a, b, c));
                }
            }
            else { Console.WriteLine("err"); }
        }
        public static void Main(string[] args)
        {
            Console.Write($"x: ");
            for (double x = 1; x < 2; x += dx)
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine();

            Table();

        }
    }
}
