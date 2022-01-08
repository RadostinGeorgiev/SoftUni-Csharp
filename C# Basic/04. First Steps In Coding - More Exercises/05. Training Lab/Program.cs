using System;

namespace _05._Training_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            const double widthWorkingPlace = 0.7;
            const double lengthWorkingPlace = 1.2;
            const double widthCorridor = 1;

            double lengthRoom = double.Parse(Console.ReadLine());
            double widthRoom = double.Parse(Console.ReadLine());

            double workingPlacesInRow = Math.Floor((widthRoom - widthCorridor) / widthWorkingPlace);
            double workingPlacesInColumn = Math.Floor(lengthRoom / lengthWorkingPlace);
            double totalWorkingPlaces = workingPlacesInRow * workingPlacesInColumn - 3;

            Console.WriteLine($"{totalWorkingPlaces:F0}");
        }
    }
}