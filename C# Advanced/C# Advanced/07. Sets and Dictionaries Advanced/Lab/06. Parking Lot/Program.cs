using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;
            HashSet<string> cars = new HashSet<string>();
            while ((input = Console.ReadLine()) != "END")
            {
                string[] info = input.Split(", ");
                string direction = info[0];
                string carNumber = info[1];

                switch (direction)
                {
                    case "IN":
                        cars.Add(carNumber);
                        break;
                    case "OUT":
                        cars.Remove(carNumber);
                        break;
                }
            }

            Console.WriteLine(cars.Count == 0 ? "Parking Lot is Empty" : string.Join(Environment.NewLine, cars));
        }
    }
}
