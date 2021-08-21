using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new List<Vehicle>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] info = input.Split().ToArray();

                Vehicle vehicle = new Vehicle(info[0], info[1], info[2], double.Parse(info[3]));
                catalogue.Add(vehicle);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Close the Catalogue")
            {
                Console.WriteLine(catalogue.First(x => x.Model == input));

                input = Console.ReadLine();
            }

            double averageHorsePower = 0;
            var cars = catalogue.Where(x => x.TypeOfVehicle == "car");
            if (cars.Count() != 0)
            {
                averageHorsePower = cars.Average(x => x.HorsePower);
            }
            else
            {
                averageHorsePower = 0;
            }
            Console.WriteLine($"Cars have average horsepower of: {averageHorsePower:F2}.");

            var trucks = catalogue.Where(x => x.TypeOfVehicle == "truck");
            if (trucks.Count() != 0)
            {
                averageHorsePower = trucks.Average(x => x.HorsePower);
            }
            else
            {
                averageHorsePower = 0;
            }
            Console.WriteLine($"Trucks have average horsepower of: {averageHorsePower:F2}.");
        }
    }

    class Vehicle
    {

        public string TypeOfVehicle { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }

        public Vehicle(string typeOfVehicle, string model, string color, double horsePower)
        {
            TypeOfVehicle = typeOfVehicle;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Type: {(TypeOfVehicle == "car" ? "Car" : "Truck")}");
            output.AppendLine($"Model: {Model}");
            output.AppendLine($"Color: {Color}");
            output.AppendLine($"Horsepower: {HorsePower}");
            return output.ToString().TrimEnd();
        }
    }
}
