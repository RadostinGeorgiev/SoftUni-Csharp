using System;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            Radius = radius;
        }


        public double Radius
        {
            get => radius;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                radius = value;
            }
        }

        public override double CalculatePerimeter() => 2 * Math.PI * Radius;

        public override double CalculateArea() => Math.PI * Radius * Radius;

        public override string Draw() => base.Draw() + GetType().Name;
    }
}