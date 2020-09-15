// Татьянченко Д.Д.
// Семинар 1 ДЗ 5

using System;

namespace task40
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input U:");
            string u = Console.ReadLine();
            Console.WriteLine("Input R:");
            string r = Console.ReadLine();
            double U = Convert.ToDouble(u), R = Convert.ToDouble(r);
            Console.WriteLine("I: " + U / R + " " + "P: " + Math.Pow(U, 2) / R);

        }
    }
}
