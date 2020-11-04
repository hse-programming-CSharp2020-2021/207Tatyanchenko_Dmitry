using System;

namespace task3
{
    class Polygon
    {
        // Fields.
        int edges;
        double radius;

        // Properties.
        private int Perimetr
        {
            get; set;
        }
        private double Area
        {
            get; set;
        }

        // Constructor.
        public Polygon(int edges = 0, double radius = 0, int Perimetr = 0, double Area = 0)
        {
            this.edges = edges;
            this.radius = radius;
            this.Perimetr = Perimetr;
            this.Area = Area;
        }

        // Method.
        public string PolygonData()
        {
            return $"Edges: {edges}, radius: {radius}, perimetr: {Perimetr}, area: {Area}";
        }

    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Polygon poly = new Polygon(1, 1, 1, 1);
            Console.WriteLine(poly.PolygonData());
        }
    }
}
