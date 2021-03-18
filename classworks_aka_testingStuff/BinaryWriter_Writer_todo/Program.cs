using System;
using System.IO;

namespace BinaryWriter_Writer_todo
{
    // Проект 2. Чтение целых из двоичного потока. 
    // ЧИТАТЬ И ЗАПИСЫВАТЬ СТРОГО ПО ОДНОМУ ЧИСЛУ!!! 

    class Program
    {

        static void Main()
        {

            BinaryWriter fOut = new BinaryWriter(

                new FileStream("../../../t.dat", FileMode.Create));

            for (int i = 0; i <= 10; i += 2)

                fOut.Write(i);

            fOut.Close();

            FileStream f = new FileStream("../../../t.dat", FileMode.Open);
            BinaryReader fIn = new BinaryReader(f);
            long n = f.Length / 4; int a;
            for (int i = 0; i < n; i++)
            {
                a = fIn.ReadInt32();
                Console.Write(a + " ");
            }
            Console.WriteLine("\nЧисла в обратном порядке:");
            // 1) TODO: Прочитать и напечатать все числа из файла в обратном порядке
            for (int i = 0; i < n; i++)
            {
                fIn.BaseStream.Seek(-4*(i+1), SeekOrigin.End);
                a = fIn.ReadInt32();
                Console.Write(a + " ");
            }
            // 2) TODO: увеличить  все числа в файле в 5 раз
            fOut = new BinaryWriter(new FileStream("../../../t.dat", FileMode.Open));
            fIn.BaseStream.Seek(0, SeekOrigin.Begin);
            for (int i = 0; i < n; i++)
            {
                a = fIn.ReadInt32();
                fOut.Write(a * 5);
            }
            fOut.Close();
            Console.WriteLine();
            // 3) TODO: Прочитать и напечатать все числа из файла в прямом порядке
            fIn.BaseStream.Seek(0, SeekOrigin.Begin);
            for (int i = 0; i < n; i++)
            {
                a = fIn.ReadInt32();
                Console.Write(a + " ");
            }
            fIn.Close();
            f.Close();
        }
    }
}
