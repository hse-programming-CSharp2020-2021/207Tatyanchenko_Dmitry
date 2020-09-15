
 //Татьянченко Д.Д.
 //Семинар 2 ДЗ 5
 //Программа использет методы сортировки из программы task2
 //Программа не обрабатывает ошибку ввода, т.к в первой строке четко задан формат вводимых данных.
 //(Это сделано чтобы не захламлять код ненужными вложенными циклами)


using System;


namespace task5
{
    class MainClass
    {
        public static string Method1(double[] a)

        //Первый вариант решения задачи, основанный на сортировке
        //массива из трех элементов тернарными операциями из задачи с семинара 
        //Проверяет неравенство А <= B + C, где А -  наибольшее из введенных чисел
        //Таким образом проверяется неравенство треугольника для трех введенных 
        //вещественных чисел(оно ложно только если наибольшее из чисел больше суммы двух других)         

        {

            double[] b = new double[3];
            b[0] = a[0] > a[1] ? (a[0] > a[2] ? a[0] : a[2]) : (a[1] > a[2] ? a[1] : a[2]);
            b[2] = a[0] < a[1] ? (a[0] < a[2] ? a[0] : a[2]) : (a[1] < a[2] ? a[1] : a[2]);
            b[1] = a[0] == b[0] ? (a[1] == b[2] ? a[2] : a[1]) : (a[0] == b[2] ? (a[1] == b[0] ? a[2] : a[1]) : a[0]);

            return b[0] < b[1] + b[2] ? "true" : (b[0] == b[1] + b[2] ? "Triangle is a line :(" : "false");
        }

        public static string Method2(double[] b)
        
         //Второй вариант решения задачи с использованием прямых логических операций

        {
            return b[0] < b[1] + b[2] && b[1] < b[0] + b[2] && b[2] < b[1] + b[0] ? "true" :
                  (b[0] == b[1] + b[2] && b[1] == b[0] + b[2] && b[2] == b[1] + b[0] ?
                   "Triangle is a line :(":"false");
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter three real numbers(fractional numbers are separated with , !):");
            double[] a = new double[3];
            for (int i = 0; i < 3; i++)
            {
                a[i] = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine($"First method: {Method1(a)} ");
            Console.WriteLine($"Second method: {Method1(a)} ");
        }
    }
}
