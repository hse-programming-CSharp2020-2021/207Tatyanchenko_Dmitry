using System;

namespace task5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int k;
            if (int.TryParse(Console.ReadLine(), out k) && k >= 1)
            {
                for (int i = 1; i <= k; i++)
                {
                    double sum = 0;
                    for (int j = 1; j <= i; j++)
                    {
                        sum += (k + 0.3) / (3 * k * k + 5);
                    }
                    Console.Write($"{sum} ");
                }
            }
            else { Console.Write("err"); }
        }
    }
}
