//Татьянченко Д.Д.
//Семинар 2 ДЗ 1

using System;

namespace HW_2
{
    class MainClass
    {
        public static double Poly(double x)
            /*
             * Метод, считающий значение полинома через вложенные циклы
             * Сложность О(n^2)
             * Проходим массив коэффициентов циклом, умножаем каждый коэффициент на х
             * пока не будет достигнута нужная степень, возвращаем сумму массива            
             */           
        {
            double rez = 0;
            double[] nums = new double[5] { -4, 2, -3, 9, 12 };
            for (int i = 1; i < 5; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    if (i >= j)
                    {
                        nums[j] *= x;
                    }
                }
            }
            foreach (double i in nums) rez += i;
            return rez;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(Poly(3));
        }
    }
}
