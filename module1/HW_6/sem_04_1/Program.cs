using System;

namespace sem_04_1
{
    class MainClass
    {
        public static int[,] MatrixTriangleBot(int n)
        {
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j < i) matrix[i, j] = -1;
                    else if (j > i) matrix[i, j] = 1;
                }
            }
            return matrix;
        }
        public static int[,] MatrixTriangleTop(int n)
        {
            {
                int[,] matrix = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j < n - (i + 1)) matrix[i, j] = -1;
                        if (j > n - (i + 1)) matrix[i, j] = 1;
                    }
                }
                return matrix;
            }
        }
        public static void Print(int[,] matrix)
        {
            int k = matrix.GetUpperBound(0)+1;
            Console.WriteLine();
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (matrix[i, j] == 1) Console.Write($" {matrix[i, j]} ");
                    else Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }


        public static void FindDot(int[,] a, int mode, ref int i, ref int j)
        {
            switch (mode)
            {
                case 1:
                    while (a[i, j] != -1) j++;
                    break;
                case 2:
                    while (a[i, j] != -1) i++;
                    break;
                case 3:
                    while (a[i, j] != -1) j--;
                    break;
                case 4:
                    while (a[i, j] != -1) i--;
                    break;
            }

        }

        public static int[,] MatrixHelix(int n)
        {
            {
                int[,] matrix = new int[n, n];
                for (int p = 0; p < n; p++)
                {
                    for (int l = 0; l < n; l++)
                    {
                        matrix[p, l] = -1;
                    }
                }

                double len = n;
                int mode = 1;
                int s = 0;
                int i = 0, j = 0;


                while(len > 0) 
                {
                    for (int k = 0; k < (int)len; k++)
                    {
                        FindDot(matrix, mode, ref i, ref j);
                        matrix[i, j] = s;
                        s++;
                        //Print(matrix);
                    }
                    len -= 0.5;
                    mode++;
                    if (mode == 5) mode = 1;
                }


                return matrix;
            }
        }
        public static void Main(string[] args)
        {
            int N;
            if (int.TryParse(Console.ReadLine(), out N))
            {
                Print(MatrixTriangleBot(N));
                Print(MatrixTriangleTop(N));
                Print(MatrixHelix(N));
            }
            else
            {
                Console.WriteLine("Input error.");
            }
        }
    }
}
