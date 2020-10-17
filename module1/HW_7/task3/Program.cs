using System;
using System.Text;
using System.IO;

namespace task3
{
    class MainClass
    {
        public static string[] Gen()
        {
            Random rnd = new Random();

            string[] lines = new string[6];

            for (int i = 0; i < 6; i++)
            {
                //забиваем строку заданной длины символами кириллицы, оставляя место для пробелов
                int len = rnd.Next(20, 51);
                int spaces = rnd.Next(3, 10);
                string str = "";
                for (int j = 0; j < len - spaces; j++) str += Convert.ToChar(rnd.Next('а', 'я'));

                //вставляем несколько пробелов в случайных местах
                for (int j = 0; j < spaces; j++)
                {
                    int rem = rnd.Next(3, str.Length);
                    str = str.Insert(rem, " ");

                }

                //ставим точку
                str += '.';

                //записываем строку в массив
                lines[i] = str;
            }

            return lines;
        }
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string[] text = Gen();
            File.WriteAllLines("dialog.txt", text);

            foreach (string i in text)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            foreach (string i in File.ReadLines("dialog.txt"))
            {
                Console.WriteLine(i.Remove(i.Length - 1 )); //да, долго капец, ну и что?
            }




        }
    }
}
