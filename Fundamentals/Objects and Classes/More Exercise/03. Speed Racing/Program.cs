using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfCars; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Car car = new Car(info[0], int.Parse(info[1]), double.Parse(info[2]), 0);
                cars.Add(car);
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string model = command[1];
                int distance = int.Parse(command[2]);

                cars.First(x => x.Model == model).IsCarMoveDistance(distance);
                
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }

    class Car
    {
        public Car(string model, int fuelAmount, double fuelConsumptionPerKm, int distance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            TraveledDistance = distance;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public double TraveledDistance { get; set; }

        public void IsCarMoveDistance(int distance)
        {
            double currentConsumption = FuelConsumptionPerKm * distance;
            if (currentConsumption <= FuelAmount)
            {
                FuelAmount -= currentConsumption;
                TraveledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:F2} {TraveledDistance}";
        }
    }
}
