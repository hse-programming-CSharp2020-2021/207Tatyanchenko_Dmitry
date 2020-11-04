using System;

namespace task2
{
    // Красивое решение, прям зашло. Я, короче, случайно удалил проект и вот только что его преписал и вообще с кайфом.
    class MainClass
    {
        public static void Main(string[] args)
        {
            int N;
            if (int.TryParse(Console.ReadLine(), out N))
            {
                int[][] matrix = new int[N][];
                for (int i = 0; i < N; i++)
                {
                    matrix[i] = new int[N];
                    for (int j = 0; j < N; j++)
                    {
                        matrix[i][j] = j + i + 1 > N ? Math.Abs(N - (i + j + 1)) : j + i + 1;
                    }
                }
                foreach (int[] i in matrix)
                {
                    foreach (int j in i)
                    {
                        Console.Write($"{j} ");
                    }
                    Console.WriteLine();
                }
            }

            else
            {
                Console.WriteLine("Input errror.");
            }
        }
    }
}
