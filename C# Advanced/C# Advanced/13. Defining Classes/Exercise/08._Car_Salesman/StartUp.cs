using System;
using System.Collections.Generic;
using RawData;

namespace _08._Car_Salesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            for (int i = 1; i <= lines; i++)
            {
                string[] engineInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);
                Engine engine = new Engine(model, power);

                if (engineInfo.Length > 2)
                {
                    if (int.TryParse(engineInfo[2], out _))
                    {
                        int displacement = int.Parse(engineInfo[2]);
                        engine.AddEngineDisplacement(displacement);
                    }
                    else
                    {
                        string efficiency = engineInfo[2];
                        engine.AddEngineEfficiency(efficiency);
                    }
                }

                if (engineInfo.Length > 3)
                {
                    string efficiency = engineInfo[3];
                    engine.AddEngineEfficiency(efficiency);
                }

                if (!engines.ContainsKey(model))
                {
                    engines.Add(model, engine);
                }
            }

            lines = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 1; i <= lines; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                string engineModel = carInfo[1];
                Car car = new Car(model, engines[engineModel]);

                if (carInfo.Length > 2)
                {
                    if (int.TryParse(carInfo[2], out _))
                    {
                        int weight = int.Parse(carInfo[2]);
                        car.AddCarWeight(weight);
                    }
                    else
                    {
                        string color = carInfo[2];
                        car.AddCarColor(color);
                    }
                }

                if (carInfo.Length > 3)
                {
                    string color = carInfo[3];
                    car.AddCarColor(color);
                }

                cars.Add(car);
            }

            cars.ForEach(Console.WriteLine);
        }
    }
}