using System;
using System.IO;
namespace task33
{
    class MainClass
    {
        public static void InpCreate()
        {
            Random rnd = new Random();
            string[] a = new string[rnd.Next(20)];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rnd.Next(-10, 11).ToString();
            }
            File.WriteAllLines("input.txt", a);
        }
        public static void Main(string[] args)
        {
            InpCreate();
            string[] a = File.ReadAllLines("input.txt");
            string[] vasya = new string[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                vasya[i] = Convert.ToString(Convert.ToInt32(a[i]) >= 0);

            }
            foreach (string i in a) Console.Write(i);
            Console.WriteLine();
            foreach (string i in vasya) Console.Write(i);

            File.WriteAllLines("output.txt", vasya);

        }
    }
}
