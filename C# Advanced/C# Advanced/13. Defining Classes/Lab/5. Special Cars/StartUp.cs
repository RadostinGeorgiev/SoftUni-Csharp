using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            List<Tire[]> tires = new List<Tire[]>();
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] info = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Tire[] carTires = new Tire[4]
                {
                    new Tire(int.Parse(info[0]), double.Parse(info[1])),
                    new Tire(int.Parse(info[2]), double.Parse(info[3])),
                    new Tire(int.Parse(info[4]), double.Parse(info[5])),
                    new Tire(int.Parse(info[6]), double.Parse(info[7]))
                };
                tires.Add(carTires);
            }

            List<Engine> engines = new List<Engine>();
            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] info = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(info[0]);
                double cubicCapacity = double.Parse(info[1]); ;
                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] info = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = info[0];
                string model = info[1];
                int year = int.Parse(info[2]);
                double fuelQuantity = double.Parse(info[3]);
                double fuelConsumption = double.Parse(info[4]);
                int engineIndex = int.Parse(info[5]);
                int tiresIndex = int.Parse(info[6]);

                Car car = new Car(
                    make,
                    model,
                    year,
                    fuelQuantity,
                    fuelConsumption,
                    engines[engineIndex],
                    tires[tiresIndex]);
                cars.Add(car);
            }

            var specialCars = cars
                .Where(x => x.Year >= 2017)
                .Where(x => x.Engine.HorsePower > 330)
                .Where(x => x.Tires.Sum(x => x.Pressure) >= 9 &&
                             x.Tires.Sum(x => x.Pressure) <= 10);

            foreach (var specialCar in specialCars)
            {
                specialCar.Drive(20);
                Console.WriteLine(specialCar.WhoAmI());
            }
        }
    }
}