using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            CatalogueVehicle catalog = new CatalogueVehicle();

            while (input != "end")
            {
                //{type}/{brand}/{model}/{horse power / weight}
                string[] info = input
                    .Split("/", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = info[0];

                if (type == "Car")
                {
                    catalog.Cars.Add(new Car
                    {
                        Brand = info[1],
                        Model = info[2],
                        HorsePower = int.Parse(info[3])
                    });
                }
                else if (type == "Truck")
                {
                    catalog.Trucks.Add(new Truck
                    {
                        Brand = info[1],
                        Model = info[2],
                        Weight = int.Parse(info[3])
                    });
                }

                input = Console.ReadLine();
            }

            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");

                foreach (var item in catalog.Cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.HorsePower}hp");
                }
            }

            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");

                foreach (var item in catalog.Trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.Weight}kg");
                }
            }
        }
    }

    class Truck
    {
        //Brand, Model and Weight
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }

    class Car
    {
        //Brand, Model and Horse Power
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }

    class CatalogueVehicle
    {
        //Collections of Trucks and Cars
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

        public CatalogueVehicle()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
    }
}
