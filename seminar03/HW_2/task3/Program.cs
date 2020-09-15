//Татьянченко Д.Д.
//Семинар 2 ДЗ 3

using System;

namespace task3
{
    class MainClass
    {
        public static void Main(string[] args)
        /*
         * Программа решает квадратные уравнения в области действительных чисел
         * При D < 0, выдает сообщение о наличии комплексного корня
         * При а = 0, выдает сообщение о том, что уравнение не является квадратным            
         */
        {
            double[] c = new double[3];
            for (int i = 0; i < 3; i++)
            {
                c[i] = Convert.ToDouble(Console.ReadLine());
            }
            double[] x = new double[2];
            if (c[0] != 0)
            {
                if (c[1] * c[1] - 4 * c[0] * c[2] >= 0)
                {
                    x[0] = (-c[1] - Math.Sqrt(c[1] * c[1] - 4 * c[0] * c[2])) / 2 * c[0];
                    x[1] = (-c[1] + Math.Sqrt(c[1] * c[1] - 4 * c[0] * c[2])) / 2 * c[0];
                    for (int j = 0; j < 2; j++)
                    {
                        Console.WriteLine($"x{j + 1} = {x[j]}");
                    }

                }
                else
                {
                    Console.WriteLine("The equation contains a comlex root.");
                }
            }
            else
            {
                Console.WriteLine("The equation is not quadratic.");
            }
        }
    }
}
