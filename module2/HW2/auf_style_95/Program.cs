using System;
using System.Collections.Generic;
using System.Collections;
namespace task3
{
    // Да это не по теме задания, но я так кайфую от того, что смог на шарпе руками реализовать 
    // за 70+ строк то, что в питоне пишется в 1 строчку, что я просто с кайфом оставлю это здесь /\ ауф \/

    class IntArrayComparer : IComparer<int[]>
    {
        int index;
        int reverse;

        int Index
        {
            get
            {
                return index;
            }
            set
            {
                if (value >= 0) index = value;
                else throw new ArgumentException("Negative index.");
            }
        }
        int Reverse
        {
            get
            {
                return reverse;
             }
            set
            {
                if (value == 0) reverse = 1;
                if (value == 1) reverse = -1;
            }
        }

        public IntArrayComparer(int i, bool reverse = false)
        {
            Index = i;
            Reverse = Convert.ToInt32(reverse);
        }

        public int Compare(int[] a1, int[] a2)
        {
            if (a1[Index] > a2[Index]) return reverse;
            else if (a1[Index] < a2[Index]) return -reverse;
            else return 0;
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[][] arr = new int[4][];
            arr[0] = new int[4] { 1, 2, 3, 4 };
            arr[1] = new int[4] { 1, 0, 3, 4 };
            arr[2] = new int[4] { 1, 100, 3, 4 };
            arr[3] = new int[4] { 1, 6, 3, 4 };

            Array.Sort(arr, new IntArrayComparer(1));

            foreach (int[] i in arr)
            {
                foreach (int j in i)
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
            }
        }
    }
}
