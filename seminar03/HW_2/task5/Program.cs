
 //Татьянченко Д.Д.
 //Семинар 2 ДЗ 5
 //Программа использет методы сортировки из программы task2
 //Проверяет неравенство А <= B + C, где А -  наибольшее из введенных чисел
 //Таким образом проверяется неравенство треугольника для трех введенных 
 //вещественных чисел(оно ложно только если наибольшее из чисел больше суммы двух других)
 //Программа не обрабатывает ошибку ввода, т.к в первой строке четко задан формат вводимых данных.
 //(Это сделано чтобы не захламлять код ненужными вложенными циклами,
 //для проверки моего умения обрабатывать ошибки и делать множественный ввод без перезапуска программы, см. зд.4)


using System;
using System.Collections.Generic;

namespace task5
{
    class MainClass
    {
        public static double[] Sort_Tern(double[] a)

        //Первый вариант решения задачи, основанный на сортировке
        //массива из трех элементов тернарными операциями из задачи с семинара          
        
        {

            double[] b = new double[3];
            b[0] = a[0] > a[1] ? (a[0] > a[2] ? a[0] : a[2]) : (a[1] > a[2] ? a[1] : a[2]);
            b[2] = a[0] < a[1] ? (a[0] < a[2] ? a[0] : a[2]) : (a[1] < a[2] ? a[1] : a[2]);
            b[1] = a[0] == b[0] ? (a[1] == b[2] ? a[2] : a[1]) : (a[0] == b[2] ? (a[1] == b[0] ? a[2] : a[1]) : a[0]);

            return b;
        }

        public static double[] Sort_List(double[] a)
        
         //Второй вариант решения задачи с использованием списка и
         //метода Sort()

        {
            List<double> b = new List<double>();
            b.AddRange(a);
            b.Sort();
            for (int i = 0; i < 3; i++)
            {
                a[i] = b[i];
            }
            return a;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter three real numbers(fractional numbers are separated with , !):");
            double[] a = new double[3];
            for (int i = 0; i < 3; i++)
            {
                a[i] = Convert.ToDouble(Console.ReadLine());
            }
            double[] a1 = Sort_Tern(a);
            double[] a2 = Sort_List(a);
            Console.WriteLine("First method: {0} ", a1[0] <= a1[1] + a1[2] ? true : false );
            Console.WriteLine("Second method: {0} ", a2[2] <= a2[1] + a2[0] ? true : false);
        }
    }
}
