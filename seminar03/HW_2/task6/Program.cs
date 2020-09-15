// Татьянченко Д.Д.
// Семинар 2 ДЗ 6
// Программа использует модификаторы формата валюты и
// методы пространства имен System.Globalization

using System;
using System.Globalization;

namespace task6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input total budget:");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input computer games fraction(per cent):");
            double b = Convert.ToDouble(Console.ReadLine());
            double rez = (a / 100) * b;
            Console.WriteLine("Computer games budget is: " + rez.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")));

        }
    }
}
