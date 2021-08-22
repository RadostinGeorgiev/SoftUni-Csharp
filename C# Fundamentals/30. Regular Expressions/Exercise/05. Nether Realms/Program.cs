using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daemonNames = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            SortedDictionary<string, Daemon> daemons = new SortedDictionary<string, Daemon>();

            foreach (var daemonName in daemonNames)
            {
                string healthPattern = @"[^0-9+\-*\/\.]";
                int health = Regex.Matches(daemonName, healthPattern)
                    .Select(x=>char.Parse(x.Value))
                    .Select(x=>(int)x)
                    .Sum();

                string damagePattern = @"[+-]*\d+\.?\d*";
                double damage = Regex.Matches(daemonName, damagePattern)
                    .Select(x => double.Parse(x.Value))
                    .Sum();

                string finalDamagePattern = @"[*\/]";
                char[] finalDamageActions = Regex.Matches(daemonName, finalDamagePattern)
                    .Select(x => char.Parse(x.Value))
                    .ToArray();
                foreach (var finalDamageAction in finalDamageActions)
                {
                    if (finalDamageAction == '*')
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }

                daemons.Add(daemonName, new Daemon(daemonName, health, damage));
            }

            foreach (var keyValuePair in daemons)
            {
                Console.WriteLine($"{keyValuePair.Key} - {keyValuePair.Value.Health} health, {keyValuePair.Value.Damage:F2} damage");
            }
        }
    }

    class Daemon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }

        public Daemon(string name, int health, double damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
}
