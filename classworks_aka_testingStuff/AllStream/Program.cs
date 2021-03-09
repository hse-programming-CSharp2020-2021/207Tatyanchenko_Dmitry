using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AllStream
{
    class Program
    {
        static string FilePath = "../../../File.txt";
        static string FileStreamPath = "../../../FileStream.txt";
        static string StreamWriterPath = "../../../StreamWriter.txt";
        static string BinaryWriterPath = "../../../BinaryWriter.bin";

        static void Main(string[] args)
        {
            Random rnd = new Random();

            string[] numbers = new string[10];
            for (int i = 0; i < 10; i++) numbers[i] = rnd.Next().ToString();

            // using file class
            File.WriteAllLines(FilePath, numbers);
            Console.WriteLine("File class : ");
            foreach (string str in File.ReadAllLines(FilePath)) Console.WriteLine(str);
            Console.WriteLine();

            // using FileStream
            using (FileStream fs = new FileStream(FileStreamPath, FileMode.OpenOrCreate))
            {
                for (int i = 0; i < 10; i++)
                {
                    fs.Write(Encoding.Default.GetBytes(numbers[i]));
                }

                Console.WriteLine("FileStream : ");
                int cur = 0;
                byte[] num = new byte[4];
                for (int i = 0; i < 10; i++)
                {
                    fs.Read(num, cur, cur + 4);
                    Console.WriteLine(BitConverter.ToInt32(num));
                    cur += 4;
                }
            }

            // using StreamWriter
            using (StreamWriter sw = new StreamWriter(File.Open(StreamWriterPath, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; i++)
                {
                    sw.WriteLine(numbers[i]);
                }
            }

            // using BinaryWriter
            using (BinaryWriter bw = new BinaryWriter(File.Open(BinaryWriterPath, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; i++)
                {
                    bw.Write(numbers[i]);
                    bw.Write("\n");
                }
            }





        }
    }
}
