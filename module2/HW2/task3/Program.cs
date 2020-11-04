using System;
using System.Collections.Generic;
using System.Linq;

namespace task3
{
    class Polygon
    {
        // Fields.
        int edges;

        // Properties.
        private double Perimetr
        {
            get;
            set;
        }
        public double Area
        {
            get
            {
                return (Perimetr * Perimetr) / (4 * edges * Math.Tan(Math.PI / edges));
            }
        }
        public double Radius
        {
            get
            {
                return Perimetr / (2 * edges * Math.Tan(Math.PI / edges));
            }
        }

        // Constructor.
        public Polygon(int edges = 0, double Perimetr = 0)
        {
            this.edges = edges;
            this.Perimetr = Perimetr;

        }

        // Method.
        public string PolygonData(int areaColor = 0)
        {
            if (areaColor == -1) return $"Edges: {edges}, radius: {Radius.ToString("F3")}, perimetr: {Perimetr.ToString("F3")}, \x1b[31m area: {Area.ToString("F3")}\x1b[0m"; 
            else if (areaColor == 1) return $"Edges: {edges}, radius: {Radius.ToString("F3")}, perimetr: {Perimetr.ToString("F3")}, \x1b[32m area: {Area.ToString("F3")}\x1b[0m";
            else return $"Edges: {edges}, radius: {Radius.ToString("F3")}, perimetr: {Perimetr.ToString("F3")}, area: {Area.ToString("F3")}";
        }

    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            string ans;
            List<Polygon> polygons = new List<Polygon>();

            do
            {
                Console.WriteLine("Enter polygon data(number of edges, perimetr) - to finish entering type <0 0>:");
                Console.Write(">>");
                ans = Console.ReadLine();
                string[] inp = ans.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int edges = -1;
                double perimetr = -1;
                if (inp[0] == "0" && inp[1] == "0") break;
                else
                {
                    if (int.TryParse(inp[0], out edges) && double.TryParse(inp[1], out perimetr) && edges > 2 && perimetr > 0)
                    {
                        polygons.Add(new Polygon(edges, perimetr));
                    }
                    else
                    {
                        Console.WriteLine("Error while parsing." +
                            "Possibly unacceptable values of edges or perimetr entered." +
                            "Press y to continue/any key to quit.");
                        if (Console.ReadKey().Key == ConsoleKey.Y) continue;
                        else break;
                    }
                }

            } while (ans != "0 0");

            if (polygons.Count > 0)
            {
                // Крутая тема, я понял, как лямбда в шарпе работает.
                double maxArea = polygons.Max(poly => poly.Area);
                double minArea = polygons.Min(poly => poly.Area);

                foreach (Polygon poly in polygons)
                {
                    if (poly.Area == maxArea)
                    {
                        Console.WriteLine(poly.PolygonData(1));
                    }
                    else if (poly.Area == minArea)
                    {
                        Console.WriteLine(poly.PolygonData(-1));
                    }
                    else
                    {
                        Console.WriteLine(poly.PolygonData());
                    }
                }
            }

        }
    }
}