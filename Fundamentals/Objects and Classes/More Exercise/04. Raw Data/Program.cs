using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Raw_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>(numberCars);

            for (int i = 1; i <= numberCars; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string model = info[0];
                int speed = int.Parse(info[1]);
                int power = int.Parse(info[2]);
                int cargoWeight = int.Parse(info[3]);
                string cargoType = info[4];

                Car car = new Car(model, speed, power, cargoType, cargoWeight);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                Console.WriteLine(string.Join(Environment.NewLine,
                    cars.Where(x => x.Cargo.Type == "fragile" && x.Cargo.Weight < 1000)));
            }
            else if (command == "flamable")
            {
                Console.WriteLine(string.Join(Environment.NewLine,
                    cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)));
            }
        }
    }

    class Car
    {
        public Car(string model, int speed, int power, string type, int weight)
        {
            Model = model;
            Engine = new Engine(speed, power);
            Cargo = new Cargo(type, weight);
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }

        public override string ToString()
        {
            return $"{Model}";
        }
    }

    class Engine
    {
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }

        public int Speed { get; set; }
        public int Power { get; set; }
    }

    class Cargo
    {
        public Cargo(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type { get; set; }
        public int Weight { get; set; }
    }
}
