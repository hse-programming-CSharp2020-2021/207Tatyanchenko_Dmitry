// Татьянченко Д.Д.
// Семинар 2 ДЗ 7
// Программа выводит значение дробной части числа с точностью 5 знаков после запятой


using System;

namespace task7
{
    class MainClass
    {
        public static double[] Int_Fract(double a)
            /*
             * Метод, отделяющий целую часть числа от дробной вычитанием           
             */           
        {
            double[] r = new double[2];
            r[0] = (int)a;
            r[1] = Math.Round(a - r[0],5);
            return r;
        }

        public static double[] Square(double a)
        /*
        * Метод, возвращающий квадрат числа
        * и квадратный корень из него
        * в случае, если число отрицательно, возвращает вместо корня -1
        * (условное значение ошибки, обрабатывается дальше в программе)
        */
        {
            double[] r = new double[2];
            if (a >= 0)
            {
                r[0] = a * a;
                r[1] = Math.Sqrt(a);
            }
            else
            {
                r[0] = a * a;
                r[1] = -1;
            }
            return r;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Insert a number:");
            double a = Convert.ToDouble(Console.ReadLine());
            double[] r = Int_Fract(a);
            Console.WriteLine($"Integer part: {r[0]}, fraction part: {r[1]}.");
            r = Square(a);
            if (r[1] != -1) 
            {
                Console.WriteLine("Square: {0}, square root: {1}", r[0], r[1]);
            }
            else 
            {
                Console.WriteLine("Square: {0}, square root of the inserted number lies in range of complex numbers.", r[0]);
            }
        }
    }
}
