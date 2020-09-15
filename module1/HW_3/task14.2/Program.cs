//Татьянченко Д.Д.
//Семинар 3 задача 14.2
//Обрабатывает ошибки ввода, перезапускается из терминала при невалидном вводе.

using System;

namespace task14
{
    class MainClass
    {
        public static double Method(double x, double y)
        /*
         * Метод для задачи 2, решающий поставленную задачу через условный оператор.           
         */
        {
            if ((x < y) && (x > 0)) return x + Math.Sin(y);
            else if ((x > y) && (x < 0)) return x + Math.Sin(y);
            else return 0.5 * x * y;
        }
        public static void Main(string[] args)
        {
        Inp: Console.WriteLine("Enter x and y:");
            double x, y;
            if (double.TryParse(Console.ReadLine(), out x) &&
                      double.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine($"Ans: {Method(x, y)}");
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
