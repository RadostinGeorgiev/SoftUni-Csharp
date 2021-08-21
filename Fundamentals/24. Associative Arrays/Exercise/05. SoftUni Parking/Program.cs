using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> cars = new Dictionary<string, string>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string user = input[1];

                if (command == "register")
                {
                    string plateNumber = input[2];
                    if (cars.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {cars[user]}");
                    }
                    else
                    {
                        cars.Add(user, plateNumber);
                        Console.WriteLine($"{user} registered {plateNumber} successfully");
                    }
                }
                else
                {
                    if (cars.ContainsKey(user))
                    {
                        cars.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }

                }
            }

            foreach (var keyValuePair in cars)
            {
                Console.WriteLine($"{keyValuePair.Key} => {keyValuePair.Value}");
            }
        }
    }
}
