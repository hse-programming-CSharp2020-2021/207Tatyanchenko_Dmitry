using System;
using System.IO;

namespace ChangeStandartInputStream
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] numbers = new int[100];

            StreamWriter fOut = new StreamWriter(

                new FileStream("../../../t.dat", FileMode.Create));

            for (int i = 0; i < 100; i++)

                fOut.Write(rnd.Next(100));

            fOut.Close();

            Console.SetIn(new StreamReader(new FileStream("../../../t.dat", FileMode.Open)));

            for (int i = 0; i < 100; i++)
            {

                Console.Write(Console.Read()+ " ");
                 }

            
        }
    }
}
