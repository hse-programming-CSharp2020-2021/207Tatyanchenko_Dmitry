//Татьянченко Д.Д.
//Семинар 3 задача 4
// Воспользуемся итерационной формулой Геррона(частный случай метода Ньютона)
// для нахождения приближание квадратного корня из неотрицательного числа.

using System;

namespace HW_3
{
    class MainClass
    {
        public static int Accuracy(double a)
        /*
         * Вспомогательный метод, определяющий 
         * кол-во знаков поле запятой 
         * для введенного числа
         */
        {
            string str = Convert.ToString(a);
            int i = 0;
            while (i < str.Length)
            {
                if (str[i] == ',')
                {
                    break;
                }
                else
                {
                    i++;
                    continue;
                }
            }
            return str.Length - i - 1;
        }
        public static bool Sqrt(double a, ref double x0, ref double x1)
        /*
         *  Метод вычисления приближения квадратного корня числа до машинного нуля
         *  Использует формулу Ньютона, в качестве первого приближения взята половина
         *  битового размера переменной типа double(все вводимые переменные имеют такой тип) 
         *  Возвращает будевское значение в точку вызова, изменяет получаемые переменные для 
         *  возврата необходимых значений (х1 - итоговый корень, х0 - кол-во знаков после запятой)        
         */
        {
            if (a > 0)
            {
                while (x1 != x0)
                {
                    x1 = x0;
                    x0 = 0.5 * (x0 + a / x0);
                }
                x0 = Accuracy(x1);
                return true;
            }
            else if (a == 0)
            {
                x1 = 0;
                x0 = -1;
                return true;
            }
            else return false;

        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            double a;
            string str = Console.ReadLine();
            bool er = double.TryParse(str, out a);
            if (er)
            {
                double x0 = 16;
                double x1 = -1;
                if (Sqrt(a, ref x0, ref x1))
                {
                    Console.WriteLine(x0 == -1 ? $"Approximate square root: {x1}\n" +
                                                $"Accuracy: Inserted nubmer is a whole square." :
                                                $"Approximate square root: {x1}\n" +
                                                $"Accuracy: {Accuracy(x1)} digits.");
                }
                else
                {
                    Console.WriteLine("Negative number.");
                }
            }
            else
            {
                Console.WriteLine("Input error.");
            }

        }
    }
}
