//Татьянченко Д.Д.
//Семинар 3 задача 13.1


using System;

namespace task13
{
    class MainClass
    {
        public static bool Similar(int a)
        /*
         * Вспомогательный метод, определяющий, равны ли все цифры числа.           
         */
        {
            for (int i = 1; i < a.ToString().Length; i++)
            {
                if (a.ToString()[i] != a.ToString()[i - 1]) return false;
            }
            return true;
        }
        public static int[] Row()
        /*
         * Основной метод, ищущий первое число, удовлетворяющее условиям.
         * Возвращает искомое число и последний член прогрессии.
         */
        {
            int[] a = new int[2] { 0, 1 };
            while (true)
            {
                a[0] += a[1];
                if (Similar(a[0]) && a[0] >= 100 && a[0] < 1000)
                {
                    return a;
                }
                else
                {
                    a[1]++;
                }

            }
        }
        public static void Main(string[] args)
        {
            int[] a = Row();
            Console.WriteLine(a[0]);
            Console.WriteLine($"1 + 2 + 3 +...+ {a[1] - 1} + {a[1]}");
        }
    }
}
