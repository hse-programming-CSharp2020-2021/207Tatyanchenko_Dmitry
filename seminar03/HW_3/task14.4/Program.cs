//Татьянченко Д.Д.
//Семинар 3 задача 14.4
//Обрабатывает ошибки ввода, перезапускается из терминала при невалидном вводе.

using System;

namespace task14
{
    class MainClass
    {
        public static int Method(int[] x)
        /*
         * Метод для решения задачи 4.
         * Получает на вход массив из трех целых чисел, возвращает ранниий минимум
         * среди значений по модулю 100(2 последние цифры - номер на этаже).
         */
        {
            int min = -1;
            foreach (int i in x) if (i % 100 < min % 100 || min == -1) min = i; 
            return min;
        }
        public static void Main(string[] args)
        {
        Inp: Console.WriteLine("Enter three integers():");
            int[] x = new int[3];
            if (int.TryParse(Console.ReadLine(), out x[0]) &&
                int.TryParse(Console.ReadLine(), out x[1]) &&
                int.TryParse(Console.ReadLine(), out x[2]))
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
