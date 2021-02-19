using System;
using System.Text;
namespace stringBuilder
{
    class Program
    {
        class assad
        {
            int i = 1;
        }
        static void Main(string[] args)
        {
            int[][] a = new int[2][];
            a[0] = new int[] { 1, 2, 3 };

            a[1] = new int[] { 2, 3 };
            //Array.Resize(ref a, 5);
            Console.WriteLine(new assad());
            //StringBuilder sb = new StringBuilder(3, 10);
            //sb.Append("vvvvvvvvv");
            //Console.WriteLine(sb.Length.ToString() + " " + sb.Capacity);
            ////sb.Remove(3,4);
            ////Console.WriteLine(sb.Length.ToString() + " " + sb.Capacity);
            //sb.Append("asasd");

            //StringBuilder sb = new StringBuilder("vvvvv", 10);

            //Console.WriteLine(sb.Length.ToString() + " " + sb.Capacity);
            decimal k = 3.0m;
        }
    }
}
