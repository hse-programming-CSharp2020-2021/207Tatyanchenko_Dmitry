using System;
using System.Collections.Generic;

namespace task2
{
    /// <summary>
    ///  Класс точки. Из интеренсного : override ToString()
    /// </summary>
    class Dot
    {
        double x
        { get; set; }
        double y
        { get; set; }

        public double fi
        {
            get
            {
                double fi = 0;
                if (x > 0 && y >= 0) fi = Math.Atan(y / x);
                if (x > 0 && y < 0) fi = Math.Atan(y / x) + 2 * Math.PI;
                if (x < 0) fi = Math.Atan(y / x) + Math.PI;
                if (x == 0 && y < 0) fi = Math.PI / 2;
                if (x == 0 && y > 0) fi = Math.PI * 3 / 2;
                if (x == 0 && y == 0) fi = 0;
                return fi;
            }
        }

        public double r
        {
            get { return Math.Sqrt(x * x + y * y); }
        }

        public Dot()
        {
            this.x = 0;
            this.y = 0;
        }

        public Dot(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"x:{x}, y:{y}, r:{r}";
        }
    }

    /// <summary>
    /// коМпаРатор !1!111! (1й в жизни :)))))))
    /// </summary>
    class DotComparer : IComparer<Dot>
    {
        public int Compare(Dot dot1, Dot dot2)
        {
            if (dot1.r > dot2.r)
            {
                return 1;
            }
            else if (dot1.r < dot2.r)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

    }

    class MainClass
    {

        public static void Main(string[] args)
        {
            Dot[] dots = new Dot[3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\nEnter coordinates of the new point(x y)");
                Console.Write(">>");
                string[] inp = Console.ReadLine().Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
                double x;
                double y;
                if (double.TryParse(inp[0], out x) && double.TryParse(inp[1], out y))
                {
                    dots[i] = new Dot(x, y);
                }
                else
                {
                    Console.WriteLine("Error while parsing.");
                }

            }
            Array.Sort(dots, new DotComparer());
            foreach (Dot dot in dots) Console.WriteLine($"{dot.ToString()}");
        }
    }
}
