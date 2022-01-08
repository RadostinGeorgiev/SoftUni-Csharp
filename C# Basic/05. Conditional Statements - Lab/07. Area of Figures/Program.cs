using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfFigure = Console.ReadLine();
            double area = 0.00;

            if (typeOfFigure == "square")
            {
                double length = double.Parse(Console.ReadLine());
                area = length * length;
            }
            else if (typeOfFigure == "rectangle")
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                area = length * width;
            }
            else if (typeOfFigure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                area = Math.PI * radius * radius;
            }
            else if (typeOfFigure == "triangle")
            {
                double length = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                area = length * height / 2;
            }
            Console.WriteLine($"{area:F3}");

        }
    }
}