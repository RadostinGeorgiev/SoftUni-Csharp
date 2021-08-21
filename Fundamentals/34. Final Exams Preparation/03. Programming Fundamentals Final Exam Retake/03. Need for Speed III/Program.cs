using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsNumber = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> cars = new Dictionary<string, List<int>>();

            for (int i = 1; i <= carsNumber; i++)
            {
                string[] carsData = Console.ReadLine()
                    .Split("|");
                string carName = carsData[0];
                int mileage = int.Parse(carsData[1]);
                int fuel = int.Parse(carsData[2]);

                cars.Add(carName, new List<int>() { mileage, fuel });
            }

            string input = String.Empty;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] commands = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string car = commands[1];
                int fuel;

                switch (command)
                {
                    case "Drive":
                        int distance = int.Parse(commands[2]);
                        fuel = int.Parse(commands[3]);

                        if (cars[car][1] < fuel)
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                        else
                        {
                            cars[car][0] += distance;
                            cars[car][1] -= fuel;
                            Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                            if (cars[car][0] >= 100000)
                            {
                                Console.WriteLine($"Time to sell the {car}!");
                                cars.Remove(car);
                            }
                        }
                        break;
                    case "Refuel":
                        fuel = int.Parse(commands[2]);

                        if (cars[car][1] + fuel > 75)
                        {
                            fuel = 75 - cars[car][1];
                        }

                        cars[car][1] += fuel;
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                        break;
                    case "Revert":
                        int kilometers = int.Parse(commands[2]);


                        if (cars[car][0] - kilometers < 10000)
                        {
                            cars[car][0] = 10000;
                        }
                        else
                        {
                            cars[car][0] -= kilometers;
                            Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                        }
                        break;
                }
            }

            foreach (var keyValuePair in cars
                .OrderByDescending(x => x.Value[0])
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{keyValuePair.Key} -> Mileage: {keyValuePair.Value[0]} kms, Fuel in the tank: {keyValuePair.Value[1]} lt.");
            }
        }
    }
}
