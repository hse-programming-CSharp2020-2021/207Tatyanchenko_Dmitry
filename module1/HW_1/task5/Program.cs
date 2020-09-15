// Татьянченко Д.Д.
// Семинар 1 ДЗ 6

using System;

namespace task50
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input first leg:");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input second leg:");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Hypotenuse:" + Math.Pow(a*a + b*b, 0.5));
            
        }
    }
}
