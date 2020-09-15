// Татьянченко Д.Д.
// Семинар 1 ДЗ 1 вариант 2
// Программа использует встроенные методы строк для решения задачи

using System;

namespace task10var2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input 3 words in a single line(space after each)");
            string str = Console.ReadLine();
            str = str.Replace(" ", "!");
            Console.WriteLine(str);
        }
    }
}
