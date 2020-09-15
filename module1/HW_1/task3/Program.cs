// Татьянченко Д.Д.
// Семинар 1 ДЗ 4
// Программа использует метод Cоnvert для решения задачи.

using System;

namespace task30
{
    class MainClass
    {
        public static void Main(string[] args)
        {
       
            Console.WriteLine("Input an ASCII code of chr(numer in range 32..127)");
            string str = Console.ReadLine();
            int a = Convert.ToInt32(str);
            Console.WriteLine("According to current ASCII your symbol is: " + Convert.ToChar(a));
        }
    }
}
