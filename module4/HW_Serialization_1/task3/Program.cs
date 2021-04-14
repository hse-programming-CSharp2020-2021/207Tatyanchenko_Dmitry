using System;
// Класс Quadratic - квадратное уравнение
using System.IO;    // FileStream
// BinaryFormatter: 
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization; // SerializationException
using System.Xml.Serialization;
using System.Xml;
using System.Collections.Generic;

namespace task3
{
    [Serializable]
    public class Quadratic
    {

        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        [XmlIgnore]
        public double Discriminant
        {
            get
            {
                return B * B - 4 * A * C;
            }
        }
        [XmlIgnore]
        public double X1 { get { return (-B - Math.Sqrt(Discriminant)) / (2 * A); } }
        [XmlIgnore]
        public double X2 { get { return (-B + Math.Sqrt(Discriminant)) / (2 * A); }}

        public Quadratic()
        {
        }

        public Quadratic(double A, double B, double C)
        {
            if (A == 0)
            {
                throw new ArgumentException("A == 0 - the equation is degenerate.");
            }

            this.A = A;
            this.B = B;
            this.C = C;
        }

    }
    // делегат-тип для методов обработки объектов класса Quadratic //(уравнений):
    delegate void Qdelegate(List<Quadratic> qe);

    // Класс методов для обработки
    class Processing
    {
        static XmlSerializer serializer = new XmlSerializer(typeof(List<Quadratic>));

        static Random gen = new Random();
        // методы работы с файлами
        // Оценить дискриминант и для неотрицательного - вывести корни: 
        public static void SolutionReal(List<Quadratic> list)
        {
            foreach (Quadratic eq in list)
            {
                if (eq.Discriminant < 0) continue;
                Console.WriteLine(eq.ToString() + "  дискриминант = " +
                    eq.Discriminant);
                Console.WriteLine("\tКорни: Х1={0,3:g3}  \tX2={1,3:g3}",
                   eq.X1, eq.X2);
            }
        }   // SolutionReal()
            // Метод выводит на экран сведения об уравнении:
        public static void PrintEq(List<Quadratic> list)
        {
            foreach (Quadratic eq in list)
            {
                Console.WriteLine(eq.ToString() + "  дискриминант = "
                    + (eq.Discriminant).ToString("g3"));
            }
        }   // PrintEq

        //  Метод читает из файла сериализованные объекты и "не знает" что с 
        //  ними делать:
        public static void Process(string fileName, Qdelegate qDel)
        {
            using (FileStream streamIn = new FileStream(fileName, FileMode.Open))
            {
                List<Quadratic> list = (List<Quadratic>)serializer.Deserialize(streamIn);
                qDel(list);
            }
        }   


        // Создать файл и записать в него объекты, применяя сериализацию.
        // Создать несколько объектов класса и записать их в файл: 
        static public void WriteFile(string nameFile, int numb)
        {
            using (FileStream fs = new FileStream(nameFile, FileMode.Create))
            {
                List<Quadratic> list = new List<Quadratic>();
                for (int j = 0; j < numb; j++)
                {
                    try
                    {   // При А==0 - уравнение вырождается в линейное
                        Quadratic q = new Quadratic(gen.Next(-10, 11),
                            gen.Next(-10, 11), gen.Next(-10, 11));
                        list.Add(q);
                    }
                    catch (ArgumentException ex)
                    {  // Заменить вырожденное уравнение:
                        j--; continue;
                    }
                }
                serializer.Serialize(fs, list);
            }
        }   // WriteFile() 

    }
    class Program
    {

        static void Main(string[] args)
        {
            Processing.WriteFile("equation.ser", 8);
            Console.WriteLine("Выполнена запись в режиме сериализации.");
            Console.WriteLine("Для вывода на экран нажмите любую клавишу.");
            Console.ReadKey(true);
            Console.WriteLine("В файле сведения о следующих уравнениях: ");
            // Обращение с использованием делегата:
            Processing.Process("equation.ser", new Qdelegate(Processing.PrintEq));
            Console.WriteLine("Для решения уравнений нажмите любую клавишу.");
            Console.ReadKey(true);
            Console.WriteLine("\r\nРешения уравнений с вещественными корнями: ");
            Processing.Process("equation.ser", new Qdelegate(Processing.SolutionReal));
            Console.WriteLine("Для завершения работы нажмите ENTER.");
            Console.ReadLine();

        }
    }
}
