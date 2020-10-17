using System;

namespace task10_1
{
    class MainClass
    {
        public static int Count()
        {//поиск за куб
            int[] a = new int[20];
            int count = 0;
            for (int i = 0; i < 20; i++) a[i] = i;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    for (int k = 0; k < 20; k++)
                    {
                        if (a[i] * a[i] + a[j] * a[j] == a[k] * a[k] && a[i] != a[j] && a[i] != a[k] && a[j] != a[k])
                        {
                            count++;
                            Console.Write($"{a[i]} {a[j]} {a[k]} ");
                            Console.WriteLine();
                        }
                    }
                }
            }
            return count;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(Count());
        }
    }
}
