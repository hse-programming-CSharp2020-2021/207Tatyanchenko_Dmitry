using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "\x1b[31m*\x1b[0m";
            Console.WriteLine(str);
        }
    }
}
