using System;
using System.IO;

namespace ChangeNumbersInBinaryfile
{
    class Program
    {
        static void Main()
        {
            Random rnd = new Random();
            int[] numbers = new int[10];

            BinaryWriter fOut = new BinaryWriter(

                new FileStream("../../../t.dat", FileMode.Create));

            for (int i = 0; i < 10; i++)

                fOut.Write(rnd.Next(100));

            fOut.Close();

            FileStream f = new FileStream("../../../t.dat", FileMode.Open);
            BinaryReader fIn = new BinaryReader(f);
            long n = f.Length / 4; int a;
            for (int i = 0; i < n; i++)
            {
                a = fIn.ReadInt32();
                Console.Write(a + " ");
                numbers[i] = a;
            }

            fOut = new BinaryWriter(new FileStream("../../../t.dat", FileMode.Open));
            fIn.BaseStream.Seek(0, SeekOrigin.Begin);

            // Заменяет числа на ближайшие пока не введено что-то, что не спарсится в инт
            while (true)
            {
                try
                {
                    int number = int.Parse(Console.ReadLine());

                    // Looking for the closest value
                    int delta = int.MaxValue;
                    int index = 0;
                    for (int i = 0; i < n; i++)
                    {
                        if (delta > Math.Abs(numbers[i] - number))
                        {
                            delta = Math.Abs(numbers[i] - number);
                            index = i;
                        }
                    }

                    fOut.BaseStream.Seek(4*index, SeekOrigin.Begin);
                    fOut.Write(number);

                    Console.WriteLine();

                    // Прочитать и напечатать все числа из файла в прямом порядке
                    fIn.BaseStream.Seek(0, SeekOrigin.Begin);
                    for (int i = 0; i < n; i++)
                    {
                        a = fIn.ReadInt32();
                        Console.Write(a + " ");
                    }
                    

                }
                catch (Exception ex)
                {
                    break;
                }

            }
            fIn.Close();
            fOut.Close();
            
            f.Close();
        }
    }
}
