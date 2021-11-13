using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();

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
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void ActionVehicle(string action, Vehicle vehicle, double value)
        {
            switch (action)
            {
                case "Drive":
                    vehicle.Drive(value);
                    break;

                case "Refuel":
                    vehicle.Refuel(value);
                    break;
            }
        }

        private static Vehicle CreateVehicle()
        {
            string[] data = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string type = data[0];
            double fuelQuantity = double.Parse(data[1]);
            double fuelConsumption = double.Parse(data[2]);

            Vehicle vehicle;
            switch (type)
            {
                case "Car":
                    vehicle = new Car(fuelQuantity, fuelConsumption);
                    break;
                case "Truck":
                    vehicle = new Truck(fuelQuantity, fuelConsumption);
                    break;
                default:
                    vehicle = null;
                    break;
            }

            return vehicle;
        }
    }
}