using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text.Json;
using System.Runtime.Serialization;

namespace GeneralSerializationTask
{
    [Serializable]
    [DataContract]
    public class ConsoleSimbolStruct
    {
        [DataMember]
        public char simb { get; set; }
        [DataMember]
        public int x { get; set; }
        [DataMember]
        public int y { get; set; }

        public ConsoleSimbolStruct(char simb, int x, int y)
        {
            this.simb = simb;
            this.x = x;
            this.y = y;

        }
        public ConsoleSimbolStruct()
        {

        }

    }

    [Serializable]
    [DataContract]
    public class ColorConsoleSymbol : ConsoleSimbolStruct
    {
        [DataMember]
        public int color { get; set; }

        public ColorConsoleSymbol(char simb, int x, int y, int color) : base(simb, x,y)
        {
            this.color = color;
        }
        public ColorConsoleSymbol()
        {

        }
       
    }


    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = rnd.Next(5,10);
            ConsoleSimbolStruct[] symbols = new ConsoleSimbolStruct[n];
            for (int i = 0; i < n; i++)
            {
                if (i %2 ==  0)
                {
                    symbols[i] = new ConsoleSimbolStruct((char)rnd.Next('a', 'z'), rnd.Next(0, 15), rnd.Next(0, 15));
                    Console.WriteLine($"symbol: {symbols[i].simb} x: {symbols[i].x} y: {symbols[i].y}");
                }
                else
                {
                    symbols[i] = new ColorConsoleSymbol((char)rnd.Next('a', 'z'), rnd.Next(0, 15), rnd.Next(0, 15), rnd.Next(0,100));
                    Console.WriteLine($"colored symbol: {symbols[i].simb} x: {symbols[i].x} y: {symbols[i].y} color: {((ColorConsoleSymbol)symbols[i]).color}");
                }
                
            }
            Console.WriteLine("\n");
            ConsoleSimbolStruct[] newSymbols;
            // binary

            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("symbols.dat", FileMode.Create))
            {
                formatter.Serialize(fs, symbols);
                Console.WriteLine("Объект сериализован - binary");
            }

            // десериализация из файла 
            using (FileStream fs = new FileStream("symbols.dat", FileMode.Open))
            {
                newSymbols = (ConsoleSimbolStruct[])formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован - binary");
                foreach (ConsoleSimbolStruct s in newSymbols)
                {
                    if (s is ColorConsoleSymbol)
                    {
                        Console.WriteLine($"colored symbol: {s.simb} x: {s.x} y: {s.y} color: {((ColorConsoleSymbol)s).color}");
                    }
                    else
                    {
                        Console.WriteLine($"symbol: {s.simb} x: {s.x} y: {s.y}");
                    }
                }
            }

            //XML

            XmlSerializer XMLserializer = new XmlSerializer(typeof(ConsoleSimbolStruct[]) ,new Type[] { typeof(ColorConsoleSymbol) });

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("symbols.xml", FileMode.Create))
            {
                XMLserializer.Serialize(fs, symbols);

                Console.WriteLine("Объект сериализован - XML");
            }

            // десериализация
            using (FileStream fs = new FileStream("symbols.xml", FileMode.Open))
            {
                newSymbols = (ConsoleSimbolStruct[])XMLserializer.Deserialize(fs);

                Console.WriteLine("Объект десериализован - XML");
                foreach (ConsoleSimbolStruct s in newSymbols)
                {
                    if (s is ColorConsoleSymbol)
                    {
                        Console.WriteLine($"colored symbol: {s.simb} x: {s.x} y: {s.y} color: {((ColorConsoleSymbol)s).color}");
                    }
                    else
                    {
                        Console.WriteLine($"symbol: {s.simb} x: {s.x} y: {s.y}");
                    }
                }
            }

            // JSON

            // сериализация в файл
            string json = JsonSerializer.Serialize(symbols,new JsonSerializerOptions { });
            File.WriteAllText("symbols.json", json);
            Console.WriteLine("file serialized - JSON");
            Console.WriteLine(json);
            // десериализация
            newSymbols = JsonSerializer.Deserialize<ConsoleSimbolStruct[]>(File.ReadAllText("symbols.json"));
            Console.WriteLine("file deserialized - JSON");
            foreach (ConsoleSimbolStruct s in newSymbols)
            {
                if (s is ColorConsoleSymbol)
                {
                    Console.WriteLine($"colored symbol: {s.simb} x: {s.x} y: {s.y} color: {((ColorConsoleSymbol)s).color}");
                }
                else
                {
                    Console.WriteLine($"symbol: {s.simb} x: {s.x} y: {s.y}");
                }
            }

            // data contract


            using (FileStream fs = new FileStream("symbols.txt", FileMode.Create))
            {
                //Serialize the Record object to a memory stream using DataContractSerializer.  
                DataContractSerializer serializer = new DataContractSerializer(typeof(ConsoleSimbolStruct[]),new Type[] { typeof(ColorConsoleSymbol) });
                serializer.WriteObject(fs, symbols);
                Console.WriteLine("data serialized - data contracts");

                fs.Position = 0;

                //Deserialize the Record object back into a new record object.  
                newSymbols = (ConsoleSimbolStruct[])serializer.ReadObject(fs);

                Console.WriteLine("data deserialized - data contracts");
                foreach (ConsoleSimbolStruct s in newSymbols)
                {
                    if (s is ColorConsoleSymbol)
                    {
                        Console.WriteLine($"colored symbol: {s.simb} x: {s.x} y: {s.y} color: {((ColorConsoleSymbol)s).color}");
                    }
                    else
                    {
                        Console.WriteLine($"symbol: {s.simb} x: {s.x} y: {s.y}");
                    }
                }
            }
        }
    }
}
