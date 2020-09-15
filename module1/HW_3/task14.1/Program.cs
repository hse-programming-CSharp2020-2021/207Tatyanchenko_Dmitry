//Татьянченко Д.Д.
//Семинар 3 задача 14.1
//Обрабатывает ошибки ввода, перезапускается из терминала при невалидном вводе.

using System;

namespace task14
{
    class MainClass
    {
        public static bool Method(double x, double y)
        /*
         * Метод для решения задачи 2.
         * 1.Принадлежит ли точка кругу? - проверка длины радиус-вектора
         * 2.Принадлежит ли точка заданному сектору? - проверка тангенса
         * (оставляем только часть круга, принадлежащюю 1й и 4й четвертям, 
         * тогда арктангенс определен однозначно) 
         * При делении на 0(x = 0) у/х принимает значение Double.PositiveInfinity
         * ошибки не возникает + истинность выражения не нарушается.       
         */
        {
            return x * x + y * y <= 4 && x >= 0 ?
            (y / x <= 1 && y / x >= Double.NegativeInfinity ? true : false) : false;
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
