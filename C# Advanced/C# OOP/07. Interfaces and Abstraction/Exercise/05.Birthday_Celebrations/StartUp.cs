using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBurthable> inhabitants = new List<IBurthable>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = data[0];

                string id;
                string name;
                string birthday;
                switch (type)
                {
                    case "Citizen":
                        name = data[1];
                        int age = int.Parse(data[2]);
                        id = data[3];
                        birthday = data[4];
                        Citizen citizen = new Citizen(name, age, id, birthday);
                        inhabitants.Add(citizen);
                        break;

                    case "Robot":
                        break;

                    case "Pet":
                        name = data[1];
                        birthday = data[2];
                        Pet pet = new Pet(name, birthday);
                        inhabitants.Add(pet);
                        break;
                }
            }

            string year = Console.ReadLine();

            foreach (var inhabitant in inhabitants)
            {
                if (inhabitant.Birthday.EndsWith(year))
                {
                    Console.WriteLine(inhabitant.Birthday);
                }
            }
        }
    }
}