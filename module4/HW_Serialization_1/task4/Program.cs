using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace task4
{
    [Serializable]  // атрибут сериализации
    public class Multiple
    { // Кратные числа
        public readonly string name;    // название делителя
        public readonly int divisor;    // значение делителя
        public readonly List<int> numbers = new List<int>();     // массив чисел, кратных divisor

        public override string ToString()
        {
            string mom = "Делитель: " + divisor + " - " + name + "\r\nКратные: ";
            foreach (int m in numbers)
                mom += m + "  ";
            return mom;
        }
        // parameterless constructor
        public Multiple(){}
        // конструктор
        public Multiple(int div, int[] ar)
        {
            if (div <= 0 || div > 9)
                throw new Exception("Неверно выбран делитель!");
            divisor = div;
            switch (div)
            {
                case 1: name = "один"; break;
                case 2: name = "два"; break;
                case 3: name = "три"; break;
                case 4: name = "четыре"; break;
                case 5: name = "пять"; break;
                case 6: name = "шесть"; break;
                case 7: name = "семь"; break;
                case 8: name = "восемь"; break;
                case 9: name = "девять"; break;
            }

            for (int i = 0; i < ar.Length; i++)
                if (ar[i] % div == 0) numbers.Add(ar[i]);   // Укоротили массив
        }   // конструктор


    }   // class Multiple 

    class Program
    {
        static void Main(string[] args)
        {
            Multiple row;           // ссылка на объект класса
            int size = 0;           // размер генеральной совокупности
            do
                Console.Write("Введите размер генеральной совокупности: ");
            while (!int.TryParse(Console.ReadLine(), out size) | size < 1);
            Random gen = new Random();
            int[] data = new int[size];    // генеральная совокупность
            for (int i = 0; i < size; i++)
            {
                data[i] = gen.Next(0, 100);
                Console.Write(data[i] + "  ");
            }
            Console.WriteLine();

            XmlSerializer serializer = new XmlSerializer(typeof(Multiple));

            using (FileStream byteStream = new FileStream("bytes.txt",
                          FileMode.Create, FileAccess.ReadWrite))
            {
                do
                {  // цикл для создания и записи в файл объектов
                    int div;
                    do
                    {    // цикл проверки делителя!
                        do Console.Write("Введите делитель: ");
                        while (!int.TryParse(Console.ReadLine(), out div));
                        try
                        {
                            row = new Multiple(div, data);
                            break;
                    }
                        catch (Exception)
                    {
                        Console.WriteLine("Нужен делитель от 1 до 9!");
                        continue;
                    }
                }
                    while (true);
                    // создан объект row, запишем его код в файл:
                    serializer.Serialize(byteStream, row);
                    byteStream.Flush();
                    Console.WriteLine("\nДля чтения файла - клавиша ESC");
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            }

            using (FileStream fs = new FileStream("bytes.txt", FileMode.Open))
            {
                row = (Multiple)serializer.Deserialize(fs);
                Console.WriteLine(row.ToString());
            }
        }
    }
}
