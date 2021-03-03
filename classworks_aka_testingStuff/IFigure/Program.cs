using System;

namespace IFigure
{
    interface IFigure
    {
        // returns area of the figure.
        public double Area();
    }

    class Square : IFigure
    {
        public double Length { get; set; }

        public Square(double length)
        {
            this.Length = length;
        }

        public double Area()
        {
            return Length * Length;
        }
    }

    class Circle : IFigure
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Area()
        {
            return Radius * Radius;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            void ExtraordinaryArea<T>(T[] figures, double threshold) where T:IFigure
            {
                foreach(IFigure figure in figures)
                {
                    if (figure.Area() > threshold) Console.WriteLine($"Big area: {figure.Area()}");
                }
            }

            Random rnd = new Random();

            IFigure[] figures = new IFigure[10];
            for (int i = 0; i < 5; i++)
            {
                figures[i] = new Square(rnd.Next(0,100));
                Console.WriteLine(figures[i].Area());
            }
            for (int i = 5; i < 10; i++)
            {
                figures[i] = new Circle(rnd.Next(0, 100));
                Console.WriteLine(figures[i].Area());
            }

            ExtraordinaryArea<IFigure>(figures, 20);


        }
    }
}
