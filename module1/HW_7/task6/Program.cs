using System;
using System.Collections.Generic;
using System.Linq;

namespace task6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(';');
            List<int> ints = new List<int>();
            foreach (string i in str)
            {
                int n;
                if (int.TryParse(i, out n))
                {
                    ints.Add(n);
                    Console.Write($"{n} ");
                }
            }
            Console.Write("\n" + (double)ints.Sum() / ints.Count());

        }
    }
}
