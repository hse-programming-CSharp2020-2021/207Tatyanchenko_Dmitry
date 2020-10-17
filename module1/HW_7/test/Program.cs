using System;

namespace test
{
    class MainClass
    {
        public static int TipaBinPoisk(int[] two, int value, int first, int last)
        {
            if (first == last)
            {
                return two[last];
            }

            int middle = (first + last) / 2;

            Console.WriteLine($"{first} {last} {middle}");
            if (two[middle] == value) return two[middle];
            else if (two[middle] > value) return TipaBinPoisk(two, value, first, middle - 1);
            else if (two[middle] < value)
            {
                if (two[middle] * 2 > value) return two[middle];
                else return TipaBinPoisk(two, value, middle + 1, last);
            }
             

            return 0;
        }

        public static void Main(string[] args)
        {
            int[] two = new int[15];//первая степнеь 2, большаяя 10000 - 2^14
            two[0] = 1;
            for (int i = 1; i < 15; i++)
            {
                two[i] = two[i - 1] * 2;
            }
            Console.WriteLine(TipaBinPoisk(two, 20000, 0,14));


        }
    }
}
