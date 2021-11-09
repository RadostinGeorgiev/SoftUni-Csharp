using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split();
                string name = data[0];
                string country = data[1];
                int age = int.Parse(data[2]);

                Citizen citizen = new Citizen(name, country, age);

                citizens.Add(citizen);
            }

            citizens.ForEach(Console.WriteLine);
        }
    }
}