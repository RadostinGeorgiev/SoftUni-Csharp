using System;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }


        public double Height
        {
            get => height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                height = value;
            }
        }


        public double Width
        {
            get => width;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                width = value;
            }
        }

        public override double CalculatePerimeter() => 2 * (Height + Width);
        public override double CalculateArea() => Height * Width;
        public override string Draw() => base.Draw() + GetType().Name;
    }
}