using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IPerson> inhabitants = new List<IPerson>();

            int peoples = int.Parse(Console.ReadLine());
            string name;
            for (int i = 1; i <= peoples; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 4)
                {
                    name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];
                    string birthday = data[3];
                    Citizen citizen = new Citizen(name, age, id, birthday);
                    inhabitants.Add(citizen);
                }
                else
                {
                    name = data[0];
                    int age = int.Parse(data[1]);
                    string group = data[2];
                    Rebel rebel = new Rebel(name, age, group);
                    inhabitants.Add(rebel);
                }
            }

            while ((name = Console.ReadLine()) != "End")
            {
                var buyer = inhabitants.FirstOrDefault(x => x.Name == name);
                if (buyer == null) continue;
                buyer.BuyFood();
            }

            Console.WriteLine(inhabitants.Sum(x => x.Food));
        }
    }
}