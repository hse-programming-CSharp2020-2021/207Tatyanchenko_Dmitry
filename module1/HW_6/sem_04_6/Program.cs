using System;

namespace sem_04_6
{
    class MainClass
    {
        public static int Det3(int[][] matrix)
        {
            return matrix[0][0] * matrix[1][1] * matrix[2][2] +
                   matrix[0][1] * matrix[1][2] * matrix[2][0] +
                   matrix[1][0] * matrix[2][1] * matrix[0][2] -
                   matrix[2][0] * matrix[1][1] * matrix[0][2] -
                   matrix[0][0] * matrix[2][1] * matrix[1][2] -
                   matrix[1][0] * matrix[0][1] * matrix[2][2];
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
            Random rnd = new Random();
            int[][] matrix = new int[3][];
            int[][] m1 = new int[3][];
            int[][] m2 = new int[3][];
            for (int i =0;i<3;i++)
            {
                matrix[i] = new int[6];
                m1[i] = new int[3];
                m2[i] = new int[3];
                for (int j = 0; j<6; j++)
                {
                    matrix[i][j] = rnd.Next(0, 21);
                    if (j < 3) m1[i][j] = matrix[i][j];
                    else m2[i][j-3] = matrix[i][j];
                }
            }

            Print(matrix);

            int[] ans = new int[2] { Det3(m1), Det3(m2) };

            foreach (int i in ans) Console.WriteLine(i);

        }
    }
}
