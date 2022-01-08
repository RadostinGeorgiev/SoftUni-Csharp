using System;

namespace _06._Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalFloors = int.Parse(Console.ReadLine());
            int totalApartment = int.Parse(Console.ReadLine());

            for (int currentFloor = totalFloors; currentFloor >= 1; currentFloor--)
            {
                var typeOfApartment = 'L';

                if (currentFloor == totalFloors)
                {
                    typeOfApartment = 'L';
                }
                else if (currentFloor % 2 == 0)
                {
                    typeOfApartment = 'O';
                }
                else
                {
                    typeOfApartment = 'A';
                }

                for (int currentApartment = 0; currentApartment < totalApartment; currentApartment++)
                {
                    Console.Write($"{typeOfApartment}{currentFloor}{currentApartment} ");
                }
                Console.WriteLine("");
            }
        }
    }
}