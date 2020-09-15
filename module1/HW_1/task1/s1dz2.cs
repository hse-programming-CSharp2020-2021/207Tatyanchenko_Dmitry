// Татьянченко Д.Д.
// Семинар 1 ДЗ 2
// Программа использует конкатенацию для вывода форматированных строк

using System;

namespace task11
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("input 3 strings(one in each line)");
            string str1 = Console.ReadLine(), str2 = Console.ReadLine(), str3 = Console.ReadLine();
            Console.WriteLine("-" + str1 + "-");
            Console.WriteLine("-" + str2 + "-");
            Console.WriteLine("-" + str3 + "-");
        }
    }
}
