using System;

namespace sem_04_03
{
    class MainClass
    {
        public static string[][] MatrixStairs(int n)
        {
            {
                string[][] matrix = new string[n][];
                for (int i = 0; i < n; i++)
                {
                    matrix[i] = new string[i + 1];
                    for (int j = 0; j < i + 1; j++)
                    {
                        matrix[i][j] = "*";
                    }
                }
                return matrix;
            }
        }
        public static string[][] MatrixPiramid(int n)
        {
            {
                string[][] matrix = new string[n/2][];
                int len = n / 2;
                for (int i = 0; i < n/2; i++)
                {
                    matrix[i] = new string[len];
                    for (int j = len - 1 ; j >= len - (2*i + 1); j--)
                    {
                        matrix[i][j] = "*";
                    }
                    len++;
                }
                return matrix;
            }
        }

        public static void Print(string[][] matrix)
        {
            int k = matrix.Length;
            Console.WriteLine();
            for (int i = 0; i < k; i++)
            {
                for (int j = 0 ; j < matrix[i].Length; j++)
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
                Print(MatrixStairs(N));
                Print(MatrixPiramid(N));
            }
            else
            {
                Console.WriteLine("Input error.");
            }
        }
    }
}
