using System;
using System.Linq;

namespace task7
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[][] table = new int[4][];
            table[0] = new int[3] { 20, 24, 25 };
            table[1] = new int[3] { 21, 20, 18 };
            table[2] = new int[3] { 23, 27, 24 };
            table[3] = new int[3] { 22, 19, 20 };

            int s = 0;
            for (int i = 0; i < 4; i++) s += table[i].Sum();
            Console.WriteLine($"Total: {s}.");

            int[] index = new int[2];
            int max = int.MinValue;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (table[i][j] > max)
                    {
                        max = table[i][j];
                        index[0] = i;
                        index[1] = j;
                    }
                }
            }
            Console.WriteLine($"Max: {table[index[0]][index[1]]}, quarter: {index[0]}, branch: {index[1]}.");

            int index1 = 0;
            int[] sum = new int[3];
            max = int.MinValue;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    sum[i] += table[j][i];
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (sum[i] > max)
                {
                    max = sum[i];
                    index1 = i;
                }
            }
            Console.WriteLine($"Branch: {index1}, sum: {max}.");

            index1 = 0;
            sum = new int[4] {0,0,0,0};
            max = int.MinValue;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum[i] += table[i][j];
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (sum[i] > max)
                {
                    max = sum[i];
                    index1 = i;
                }
            }
            Console.WriteLine($"Quarter: {index1}, sum: {max}.");
        }
    }
}
