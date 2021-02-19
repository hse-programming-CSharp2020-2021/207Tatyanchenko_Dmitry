using System;
using System.Collections.Generic;
using System.Linq;
namespace sort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> list = new List<int[]>() { new int[] {3,1,3 }, new int[] { 3, 0, 3 }, new int[] { 3, 2, 3 } };
            list = list.OrderBy(x => x[1]).ToList();
            foreach (int[] arr in list)
            {
                foreach (int i in arr)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
