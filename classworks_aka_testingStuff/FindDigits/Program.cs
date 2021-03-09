using System;
using System.IO;

namespace FindDigits
{
    class Program
    {

        static void Main(string[] args)
        {
            // тупо
            using (FileStream fs = File.OpenRead("../../../Program.cs"))
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                string str = System.Text.Encoding.Default.GetString(bytes);
                foreach (char s in str)
                {
                    if (s >= '0' && s <= '9') Console.WriteLine(s);
                }
            }

            // умно
            using (FileStream fs = File.OpenRead("../../../Program.cs"))
            {
                int t;      // числовое значение прочитанного байта
                int k = 0;  // позиция байта в потоке (в файле)
                while ((t = fs.ReadByte()) != -1)
                {
                    if (t >= (int)'0' && t <= (int)'9')
                    {
                        Console.WriteLine(t + " - " + (char)t + " - " + k);
                    }
                    k++;
                }
            }
        }
    }
}
