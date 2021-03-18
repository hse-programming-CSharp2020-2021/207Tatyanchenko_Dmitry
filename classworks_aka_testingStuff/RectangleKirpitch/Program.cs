using System;
using System.Diagnostics.CodeAnalysis;

namespace RectangleKirpitch
{
    struct Rect : IComparable<Rect>
    {
        public readonly double Area;
        public Rect(double x, double y)
        {
            this.Area = x * y;
        }

        public override string ToString()
        {
            return "Area: " + this.Area.ToString();
        }

        public int CompareTo(Rect rect)
        {
            return this.Area.CompareTo(rect.Area);
        }

    }

    class Brick :IComparable<Brick>
    {
        double v;
        Rect base1;
        public Brick(Rect rect, int h)
        {
            base1 = rect;
            this.v = rect.Area * h;
        }

        public int CompareTo([AllowNull] Brick other)
        {
            return this.v.CompareTo(other.v);
        }

        public override string ToString()
        {
            return "Volume: " + this.v.ToString() + " " + base1.ToString();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Brick[] bricks = new Brick[10]; // old yellow
            for (int i = 0; i < 10; i++)
            {
                bricks[i] = new Brick(new Rect(rnd.Next(10), rnd.Next(10)),rnd.Next(10));
            }
            foreach (Brick br in bricks) Console.WriteLine(br.ToString());
            Array.Sort(bricks);
            foreach (Brick br in bricks) Console.WriteLine(br.ToString());
        }
    }
}
