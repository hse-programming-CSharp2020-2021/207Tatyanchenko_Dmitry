using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ClassLibrary;
// Как создать файл в кодировке windows-1251 на мак????

namespace MegaTaskPlus
{
    class Program
    {
        static string dataFilePath = "data.txt";
        static string outFilePath = "out.txt";

        static void Main(string[] args)
        {
            // Reading N.
            int N;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out N))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect input. Try again.");
                }
            }


            while (true)
            {
                Street[] streets = ParseStreets(dataFilePath, N);

                if (streets != null)
                {
                    // Saving to out.txt file.
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(File.Open(outFilePath, FileMode.Create)))
                        {
                            foreach (Street st in streets)
                            {
                                sw.WriteLine(st);
                                Console.WriteLine(st);
                            }
                            Console.Write($"All saved to {outFilePath}.");
                        
                        }
                }
                    catch (Exception ex)
                {
                    Console.WriteLine("Usnexpected exception occured while saving to the file." + ex.Message + "Please solve the proglem and reload the pogrm.");
                    Environment.Exit(0);
                }
                break;
                }
                else
                {
                    Console.WriteLine("Do you want to try again or quit? y/any key");
                    if (Console.ReadKey().Key == ConsoleKey.Y) { continue; }
                    else break;

                }
            }


            // part 2

            Street[] newStreets = ParseStreets(outFilePath,N);
            Console.WriteLine("\nMagic streets:");
            foreach (Street st in newStreets)
            {
                if (~st % 2 != 0 && -st) Console.WriteLine(st);
            }

        }


        // Returns parsed original streets if the file is appropriate
        // Returns null if the file is damaged
        // Returns null if the file does not exist.
        public static Street[] ParseStreets(string filePath, int N)
        {
            if (File.Exists(filePath))
            {
                // В нормальной ситуации я бы просто подружил File.ReadAllLines и Linq, но нам же надо использовать потоки....

                // Но все-таки в одном месте не стану городить огород, а то много уже будет.
                int n = Math.Min(N, File.ReadAllLines(filePath).Length);

                string[][] cityMatrix = new string[n][];

                Street[] streets = new Street[n];
                try
                {
                    using (StreamReader sr = new StreamReader(File.Open(filePath, FileMode.Open)))
                    {

                        for (int i = 0; i < n; i++)
                        {
                            string[] lineSplit = sr.ReadLine().Split(' ');

                            for (int j = 1; j < lineSplit.Length; j++)
                            {
                                if (!(int.TryParse(lineSplit[j], out int k) && k >= 0 && k <= 100))
                                {
                                    // File is damaged - building our own streets.
                                    Console.WriteLine("The file was damaged.");
                                    return BuildStreets(N);
                                }
                                else
                                {
                                    cityMatrix[i] = lineSplit;
                                }
                            }
                        }
                        // Parsing the city matrix to streets array.

                        for (int i = 0; i < n; i++)
                        {
                            int[] houses = new int[cityMatrix[i].Length - 1];
                            for (int j = 1; j < cityMatrix[i].Length; j++)
                            {
                                houses[j - 1] = int.Parse(cityMatrix[i][j]);
                            }
                            streets[i] = new Street(cityMatrix[i][0], houses);
                        }

                        return streets;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Usnexpected exception occured while reading the file." + ex.Message + "Please solve the proglem and reload the pogrm.");
                    Environment.Exit(0);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Whoops. File disappeared.");
                return null;
            }
        }

        public static Street[] BuildStreets(int N)
        {
            Console.WriteLine("Generating streets randomly.");
            // Building the streets randomly.
            Street[] streets = new Street[N];
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                // Building houses.
                int[] houses = new int[rnd.Next(10)];
                for (int j = 0; j < houses.Length; j++)
                {
                    houses[j] = rnd.Next(101);
                }

                // Getting random name.
                StringBuilder builder = new StringBuilder();

                for (int k = 0; k < rnd.Next(10); k++)
                {
                    // Uppercase letters start at ASCII code 65 and there are 26 letters in the alphabet
                    builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rnd.NextDouble() + 65))));
                }

                streets[i] = new Street(builder.ToString(), houses);
            }

            return streets;
        }
    }
}
