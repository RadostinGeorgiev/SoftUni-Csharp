using System;
using System.Collections.Generic;

namespace Racing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < numbers; i++)
            {
                string[] carsInfo = Console.ReadLine().Split();
                string model = carsInfo[0];
                double fuelAmount = double.Parse(carsInfo[1]);
                double fuelConsumptionFor1km = double.Parse(carsInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km, 0);
                cars.Add(model, car);
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandArgs = input.Split();
                string model = commandArgs[1];
                double amountOfKm = double.Parse(commandArgs[2]);
                if (!cars[model].MoveCar(amountOfKm))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars.Values));
        }
    }
}