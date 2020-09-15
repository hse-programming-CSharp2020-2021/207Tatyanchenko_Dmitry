//Татьянченко Д.Д.
//Семинар 3 задача 6

using System;

namespace task6
{
    class MainClass
    {
        public static void Total(double[] a)
        /*
         * Запрашиваемый метод: принимает начальный капитал,
         * процентную ставку и кол-во лет, печатает запрошенную в условии таблицу            
         */
        {
            for (int i = 0; i < a[2]; i++)
            {
                Console.WriteLine($"Year {i + 1}: " +
                                  $"$={a[0] * a[1]:F2}");
                a[0] *= a[1];
            }

        }


        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the initial capital in usd, \n" +
                              "interest rate(percent, whole number; ex: 30% = 30)\n" +
                              "and the number of years.");
            double[] a = new double[3];
            for (int i = 0; i < 3; i++)
                if (double.TryParse(Console.ReadLine(), out a[i])) continue;
                else
                {
                    Console.WriteLine("Input error.");
                    break;
                }
            a[1] /= 100;//Приводим введенную процентную ставку к необходимому формату
            a[1] += 1;
            Total(a);
        }

    }
}

