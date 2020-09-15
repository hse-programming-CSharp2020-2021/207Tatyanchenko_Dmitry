//Татьянченко Д.Д.
//Семинар 2 ДЗ 2

using System;
using System.Collections.Generic;

namespace task2
{
    class MainClass
    {

        public static int[] ToArray(string str)
        /*
         * Вспомогательный метод, преобразующий строку к массиву целых значений 
         * При возникновении ошибки при вводе выдает сообщение в консоль
         */
        {
            int[] a = new int[3];
            for (int j = 0; j < 3; j++)
            {
                try
                {
                    a[j] = int.Parse(str[j].ToString());
                }
                catch (Exception)
                {
                    Console.WriteLine("input error");
                    break;
                }
            }
            return a;
        }

        public static string Biggest_MySort(string str)
        /*
         * Первый вариант решения задачи, основанный на сортировке
         * массива из трех элементов тернарными операциями из задачи с семинара          
         */
        {
            int[] a = ToArray(str);

            int[] b = new int[3];
            b[0] = a[0] > a[1] ? (a[0] > a[2] ? a[0] : a[2]) : (a[1] > a[2] ? a[1] : a[2]);
            b[2] = a[0] < a[1] ? (a[0] < a[2] ? a[0] : a[2]) : (a[1] < a[2] ? a[1] : a[2]);
            b[1] = a[0] == b[0] ? (a[1] == b[2] ? a[2] : a[1]) : (a[0] == b[2] ? (a[1] == b[0] ? a[2] : a[1]) : a[0]);

            str = "";
            foreach (int i in b)
            {
                str += i.ToString();
            }
            return str;
        }

        public static string Biggest_Chelovecheskiy(string str)
            /*
             * Второй вариант решения задачи с использованием списка и
             * метода Sort()
             * К сожалению, в исходном методе не предусмотрена сортировка по убыванию, 
             * поэтому добавим в строку значения с конца
             */           
        {
            List<int> a = new List<int>();
            a.AddRange(ToArray(str));
            a.Sort();
            str = "";
            for (int i = 2; i > -1; i--)
            {
                str += a[i];
            }

            return str;
        }

        public static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Console.WriteLine("First method: " + Biggest_MySort(str));
            Console.WriteLine("Second method: " + Biggest_Chelovecheskiy(str));

        }
    }
}

