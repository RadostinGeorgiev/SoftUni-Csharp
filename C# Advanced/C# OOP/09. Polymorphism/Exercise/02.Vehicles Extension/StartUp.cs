using System;
using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IVehicle car = CreateVehicle();
            IVehicle truck = CreateVehicle();
            IVehicle bus = CreateVehicle();

            int commandsNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsNumber; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();
                string action = commandArgs[0];
                string vehicleType = commandArgs[1];
                double value = double.Parse(commandArgs[2]);

                try
                {
                    switch (vehicleType)
                    {
                        case "Car":
                            ActionVehicle(action, car, value);
                            break;

                        case "Truck":
                            ActionVehicle(action, truck, value);
                            break;

                        case "Bus":
                            ActionVehicle(action, bus, value);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ActionVehicle(string action, IVehicle vehicle, double value)
        {
            switch (action)
            {
                case "Drive":
                    Console.WriteLine(vehicle.Drive(value));
                    break;

                case "DriveEmpty":
                    Console.WriteLine(((Bus)vehicle).DriveEmpty(value));
                    break;

                case "Refuel":
                    vehicle.Refuel(value);
                    break;
            }
        }

        private static IVehicle CreateVehicle()
        {
            string[] data = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string type = data[0];
            double fuelQuantity = double.Parse(data[1]);
            double fuelConsumption = double.Parse(data[2]);
            double tankCapacity = double.Parse(data[3]);

            Vehicle vehicle;
            switch (type)
            {
                case "Car":
                    vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
                    break;
                case "Truck":
                    vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                    break;
                case "Bus":
                    vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                    break;
                default:
                    vehicle = null;
                    break;
            }

            return vehicle;
        }
    }
}