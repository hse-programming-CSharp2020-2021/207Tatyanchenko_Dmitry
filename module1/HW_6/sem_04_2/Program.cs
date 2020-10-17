using System;

namespace sem_04_2
{
    class MainClass
    {
        public static int[][] Matrix(int n)
        {
            // не всякое число разложится в заданную последовательность массивов(4 например)
            //так что для определенности, возьмеме n массивов длины до n
            {
                int[][] matrix = new int[n][];
                int s = 0;
                for (int i = 0; i < n; i++)
                {
                    matrix[i] = new int[i + 1];
                    for (int j = 0; j < i + 1; j++)
                    {
                        matrix[i][j] = n - s;
                        s++;
                    }
                }
                return matrix;
            }
        }

        public static void Print(int[][] matrix)
        {
            int k = matrix.Length;
            Console.WriteLine();
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }
        public static void Main(string[] args)
        {
            int N;
            if (int.TryParse(Console.ReadLine(), out N))
            {
                Print(Matrix(N));
            }
            else
            {
                Console.WriteLine("Input error.");
            }
        }
    }
}
