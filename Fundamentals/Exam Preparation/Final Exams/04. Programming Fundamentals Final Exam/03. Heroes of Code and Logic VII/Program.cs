using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int heroesNumber = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();

            for (int i = 1; i <= heroesNumber; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string heroesName = input[0];
                int hitPoints = int.Parse(input[1]);
                int manaPoints = int.Parse(input[2]);
                heroes.Add(heroesName, new List<int>() { hitPoints, manaPoints });
            }

            string info = String.Empty;
            while ((info = Console.ReadLine()) != "End")
            {
                string[] commands = info
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string command = commands[0];
                string heroName = commands[1];

                switch (command)
                {
                    case "CastSpell":
                        int manaPoints = int.Parse(commands[2]);
                        string spellName = commands[3];

                        if (heroes[heroName][1] >= manaPoints)
                        {
                            heroes[heroName][1] -= manaPoints;
                            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName][1]} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        }
                        break;
                    case "TakeDamage":
                        int damage = int.Parse(commands[2]);
                        string attacker = commands[3];

                        heroes[heroName][0] -= damage;

                        if (heroes[heroName][0] > 0)
                        {
                            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName][0]} HP left!");
                        }
                        else
                        {
                            heroes.Remove(heroName);
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        }
                        break;
                    case "Recharge":
                        int amountMP = int.Parse(commands[2]);

                        heroes[heroName][1] += amountMP;
                        if (heroes[heroName][1] > 200)
                        {
                            amountMP += 200 - heroes[heroName][1];
                            heroes[heroName][1] = 200;
                        }

                        Console.WriteLine($"{heroName} recharged for {amountMP} MP!");
                        break;
                    case "Heal":
                        int amountHP = int.Parse(commands[2]);

                        heroes[heroName][0] += amountHP;
                        if (heroes[heroName][0] > 100)
                        {
                            amountHP += 100 - heroes[heroName][0];
                            heroes[heroName][0] = 100;
                        }

                        Console.WriteLine($"{heroName} healed for {amountHP} HP!");
                        break;
                }
            }

            foreach (var keyValuePair in heroes
                .OrderByDescending(x => x.Value[0])
                .ThenBy(x => x.Key))
            {
                Console.WriteLine(keyValuePair.Key);
                Console.WriteLine($"  HP: {keyValuePair.Value[0]}");
                Console.WriteLine($"  MP: {keyValuePair.Value[1]}");
            }
        }
    }
}
