using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _05._Dragon_Army
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberDragons = int.Parse(Console.ReadLine());
            Dictionary<string, List<Dragon>> dragons = new Dictionary<string, List<Dragon>>();

            for (int i = 1; i <= numberDragons; i++)
            {
                string[] input = Console.ReadLine().Split();
                string type = input[0];
                string name = input[1];
                int damage = input[2] == "null" ? 45 : int.Parse(input[2]);
                int health = input[3] == "null" ? 250 : int.Parse(input[3]);
                int armor = input[4] == "null" ? 10 : int.Parse(input[4]);

                Dragon dragon = new Dragon(type, name, damage, health, armor);

                if (dragons.ContainsKey(type))
                {
                    if (dragons[type].Any(x => x.Name == name))
                    {
                        var index = dragons[type].FindIndex(x => x.Name == name);
                        dragons[type][index] = dragon;
                    }
                    else
                    {
                        dragons[type].Add(dragon);
                    }
                }
                else
                {
                    dragons.Add(type, new List<Dragon>());
                    dragons[type].Add(dragon);
                }
            }

            foreach (var keyValuePair in dragons)
            {
                Console.WriteLine(
                    $"{keyValuePair.Key}::({keyValuePair.Value.Average(d => d.Damage):F2}/" +
                    $"{keyValuePair.Value.Average(d => d.Health):F2}/" +
                    $"{keyValuePair.Value.Average(d => d.Armor):F2})");

                foreach (var dragon in keyValuePair.Value.OrderBy(x => x.Name))
                {
                    Console.WriteLine(dragon);
                }
            }
        }
    }

    class Dragon
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; } = 250;
        public int Health { get; set; } = 45;
        public int Armor { get; set; } = 10;

        public Dragon(string type, string name, int damage, int health, int armor)
        {
            Type = type;
            Name = name;
            Damage = damage;
            Health = health;
            Armor = armor;
        }

        public override string ToString()
        {
            return $"-{Name} -> damage: {Damage}, health: {Health}, armor: {Armor}";
        }
    }

}
