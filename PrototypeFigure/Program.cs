using System;
using System.Text;

namespace PrototypeFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IFigure figure = new Rectangle(4, 5);
            IFigure clonedRectangle = figure.Clone();
            figure.GetInfo();
            clonedRectangle.GetInfo();

            figure = new Circle(3);
            IFigure clonedCircle = figure.Clone();
            figure.GetInfo();
            clonedCircle.GetInfo();

            figure = new Triangle(3, 4, 5);
            IFigure clonedTriangle = figure.Clone();
            figure.GetInfo();
            clonedTriangle.GetInfo();
            Console.Read();
        }
    }
    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }
    class Rectangle : IFigure
    {
        int width;
        int height;
        public Rectangle(int w, int h)
        {
            Width = w;
            Height = h;
        }

        public int Width { get => Width1; set => Width1 = value; }
        public int Height { get => Height1; set => Height1 = value; }
        public int Width1 { get => width; set => width = value; }
        public int Height1 { get => height; set => height = value; }

        public IFigure Clone()
        {
            return new Rectangle(this.Width, this.Height);
        }
        public void GetInfo()
        {
            Console.WriteLine("Прямокутник довжиною {0} и шириною {1}", Height, Width);
        }
    }
    class Circle : IFigure
    {
        int radius;
        public Circle(int r)
        {
            Radius = r;
        }

        public int Radius { get => Radius1; set => Radius1 = value; }
        public int Radius1 { get => radius; set => radius = value; }

        public IFigure Clone()
        {
            return new Circle(this.Radius);
        }
        public void GetInfo()
        {
            Console.WriteLine("Круг радіусом {0}", Radius);
        }
    }
    class Triangle : IFigure
    {
        int firstSide;
        int secondSide;
        int thierdSide;
        public Triangle(int firstSide, int secondSide, int thierdSide)
        {
            this.FirstSide = firstSide;
            this.SecondSide = secondSide;
            this.ThierdSide = thierdSide;
        }

        public int FirstSide { get => FirstSide1; set => FirstSide1 = value; }
        public int SecondSide { get => SecondSide1; set => SecondSide1 = value; }
        public int ThierdSide { get => ThierdSide1; set => ThierdSide1 = value; }
        public int FirstSide1 { get => firstSide; set => firstSide = value; }
        public int SecondSide1 { get => secondSide; set => secondSide = value; }
        public int ThierdSide1 { get => thierdSide; set => thierdSide = value; }

        public IFigure Clone()
        {
            return new Triangle(this.FirstSide, this.SecondSide, this.ThierdSide);
        }
        public void GetInfo()
        {
            Console.WriteLine("Трикутник зі сторонами {0},{1},{2} ", FirstSide, SecondSide, ThierdSide);
        }

    }
}
