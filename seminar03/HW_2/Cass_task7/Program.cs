// Татьянченко Д.Д.
// Семинар 2 задание 7
// Программа принимает 3 булевских переменных и печатает значение заданной логической функции


using System;

namespace Cass_task7
{
    class MainClass
    {
        public static void Main()
        {
        Try: try
            {
                Console.WriteLine("Input 3 boolean arguments:");
                bool[] args = new bool[3];
                for (int i = 0; i < 3; i++) args[i] = Convert.ToBoolean(Console.ReadLine());
                Console.WriteLine($"!(X&Y|Z) is:{!(args[0] && args[1] || args[2])}");
            }
            catch (System.FormatException)
            {
            Inp: Console.WriteLine("Invalid input, try once more?(Y/N)");
                string rpl = Console.ReadLine();
                switch (rpl.ToLower())
                {
                    case "y":
                        goto Try;

                    case "n":
                        break;

                    default:
                        goto Inp;

                }
            }
        }
    }
}
