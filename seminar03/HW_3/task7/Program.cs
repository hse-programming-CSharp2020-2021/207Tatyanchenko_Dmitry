//Татьянченко Д.Д.
//Семинар 3 задача 7
//Программа содержит 1 метод, вычисляющий вещественные корни 
//квадратного или линейного уравнения(при А=В=С=0 или А=В=0 С!=0 
//или при наличии комплексных корней, возвращает false)
//программа обрабатывает ошибки ввода.

using System;

namespace task7
{
    class MainClass
    {
        public static bool Eq(double[] c, ref double[] x)
        {
            /*
             * Метод использует стандартную формулу корней квадратного урв.           
             */           
            if (c[0] != 0)
            {
                if (c[1] * c[1] - 4 * c[0] * c[2] >= 0)
                {
                    x[0] = (-c[1] - Math.Sqrt(c[1] * c[1] - 4 * c[0] * c[2])) / 2 * c[0];
                    x[1] = (-c[1] + Math.Sqrt(c[1] * c[1] - 4 * c[0] * c[2])) / 2 * c[0];
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (c[0] == 0 && c[1] != 0)
            {
                x[0] = -c[2] / c[1];
                return true;
            }
            else
            {
                return false;
            }

        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter three quadratic coefficients:");
            double[] c = new double[3];
            for (int i = 0; i < 3; i++)
                if (double.TryParse(Console.ReadLine(), out c[i])) continue;
                else
                {
                    Console.WriteLine("Input error.");
                    break;
                }
            double[] x = new double[2] { 0, 0 };
            if (Eq(c, ref x))
            {
                if (x[1] != 0)
                {
                    Console.WriteLine($"x1 = {x[0]}\nx2 = {x[1]}");
                }
                else
                {
                    Console.WriteLine($"x = {x[0]}");
                }
            }
            else
            {
                Console.WriteLine("The equation has no real roots.");
            }
        }
    }
}
