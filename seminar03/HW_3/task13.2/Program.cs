//Татьянченко Д.Д.
//Семинар 3 задача 13.2
//Программа содержит 2 варианта реализации отражения числа произвольной длины
//Поддерживает перезапуск тела программы без выхода из терминала.

using System;

namespace task13
{
    class MainClass
    {
        public static string Reverse_Str(string str)
        /*
         * Простейший метод отражения числа: 
         * вывод в обратном порядке символов исходной строки           
         */
        {
            string str1 = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                str1 += str[i];
            }
            return str1;
        }

        public static int Reverse_Int(int a, string str)
        /*
         * Метод получения обратной записи числа через 
         * остатки от деления на степени 10
         */
        {
            int rez = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                rez *= 10;
                rez += a % 10;
                a /= 10;
            }
            return rez;
        }
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Input a positive integer:");
                string str = Console.ReadLine();
                int a;
                bool er = int.TryParse(str, out a);
                if (er)
                {
                    Console.WriteLine("First method:");
                    Console.WriteLine(Reverse_Str(str));
                    Console.WriteLine("Second method:");
                    Console.WriteLine(Reverse_Int(a, str));
                    break;

                }
                else
                {
                    Console.WriteLine("Inserted string is not an int, try once more?" +
                        "\n Y/N:");
                Answer: string inp = Console.ReadLine().ToLower();
                    if (inp == "y") continue;
                    else if (inp == "n")
                    {
                        Console.WriteLine("quit");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input, please choose Y or N:");
                        goto Answer;
                    }
                }
            }
        }
    }
}
