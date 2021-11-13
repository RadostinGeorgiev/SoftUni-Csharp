using System;
using System.Collections.Generic;
using System.Linq;
using Raiding.Factory;
using Raiding.Models;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HeroCreator heroCreator = new HeroCreator();
            ICollection<IBaseHero> heroes = new List<IBaseHero>();

            IBaseHero hero = null;

            int heroesNumber = int.Parse(Console.ReadLine());

            while (heroes.Count != heroesNumber)
            {
                try
                {
                    hero = heroCreator.HeroFactory();
                    heroes.Add(hero);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var baseHero in heroes)
            {
                Console.WriteLine(baseHero.CastAbility());
            }
            Console.WriteLine(heroes.Sum(x => x.Power) >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}