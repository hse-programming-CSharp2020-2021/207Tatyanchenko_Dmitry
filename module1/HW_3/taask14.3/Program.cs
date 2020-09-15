//Татьянченко Д.Д.
//Семинар 3 задача 14.3
//Обрабатывает ошибки ввода, перезапускается из терминала при невалидном вводе.

using System;

namespace task14
{
    class MainClass
    {
        public static double Method(double x)
        /*
         * Метод для решения задачи 3.
         */
        {
            return x <= 0.5 ? 1 : Math.Sin(Math.PI * (x - 1) / 2);
        }
        public static void Main(string[] args)
        {
        Inp: Console.WriteLine("Enter x:");
            double x;
            if (double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine($"Ans: {Method(x)}");
            }
            else
            {
            Ans: Console.WriteLine("Wrong input, try once more? (Y/N)");
                switch (Console.ReadLine().ToLower())
                {
                    case "y":
                        goto Inp;
                    case "n":
                        Console.WriteLine("quit");
                        break;
                    default:
                        goto Ans;
                }

            }
        }
    }
}
