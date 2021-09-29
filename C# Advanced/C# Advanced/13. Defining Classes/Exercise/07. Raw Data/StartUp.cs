using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 1; i <= number; i++)
            {
                string[] info = Console.ReadLine()
                    .Split();
                string model = info[0];

                int engineSpeed = int.Parse(info[1]);
                int enginePower = int.Parse(info[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(info[3]);
                string cargoType = info[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tire[] tires = new Tire[4];
                tires[0] = new Tire(double.Parse(info[5]), int.Parse(info[6]));
                tires[1] = new Tire(double.Parse(info[7]), int.Parse(info[8]));
                tires[2] = new Tire(double.Parse(info[9]), int.Parse(info[10]));
                tires[3] = new Tire(double.Parse(info[11]), int.Parse(info[12]));

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            switch (command)
            {
                case "fragile":
                    cars.FindAll(x => x.Cargo.Type == "fragile" && x.Tires.Any(t => t.Pressure < 1))
                        .ForEach(Console.WriteLine);
                    break;
                case "flammable":
                    cars.FindAll(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250)
                        .ForEach(Console.WriteLine);
                    break;
            }
        }
    }
}