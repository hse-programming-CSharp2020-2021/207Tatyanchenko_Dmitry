using System;

namespace sem_04_4
{
    class MainClass
    {
        public static int Det2(int[][] matrix)
        {
            return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
        }
        public static int Det3(int[][] matrix)
        {
            return matrix[0][0] * matrix[1][1] * matrix[2][2] +
                   matrix[0][1] * matrix[1][2] * matrix[2][0] +
                   matrix[1][0] * matrix[2][1] * matrix[0][2] -
                   matrix[2][0] * matrix[1][1] * matrix[0][2] -
                   matrix[0][0] * matrix[2][1] * matrix[1][2] -
                   matrix[1][0] * matrix[0][1] * matrix[2][2];
        }

        public static void Main(string[] args)
        {
            int[][] matrix = new int[2][];
            matrix[0] = new int[] { 1, 2 };
            matrix[1] = new int[] { 3, 4 };

            int[][] matrix3 = new int[3][];
            matrix3[0] = new int[] { 1, 2, 3 };
            matrix3[1] = new int[] { 4, 5, 6 };
            matrix3[2] = new int[] { 7, 8, 9 };

            Console.WriteLine($"{Det2(matrix)} {Det3(matrix3)}");

        }
    }
}
