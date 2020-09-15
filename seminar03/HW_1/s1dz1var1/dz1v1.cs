// Татьянченко Д.Д.
// Семинар 1 ДЗ 1 вариант 1
// Программа использует конкатенацию для вывода форматированной строки

using System;

namespace s1dz1
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Input 3 words in 3 lines(enter after each)");
            string str1 = Console.ReadLine(), str2 = Console.ReadLine(),str3 = Console.ReadLine();
            Console.WriteLine(str1 + "!" + str2 + "!" + str3);



        }
    }
}
