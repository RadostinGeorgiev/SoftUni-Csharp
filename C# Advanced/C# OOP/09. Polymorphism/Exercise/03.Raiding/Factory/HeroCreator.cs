using System;
using Raiding.Models;

namespace Raiding.Factory
{
    public class HeroCreator : Creator
    {
        public override IBaseHero HeroFactory()
        {
            IBaseHero hero;
            string heroName = Console.ReadLine();
            string heroType = Console.ReadLine();

                switch (heroType)
                {
                    case "Druid":
                        hero = new Druid(heroName);
                        break;

                    case "Paladin":
                        hero = new Paladin(heroName);
                        break;

                    case "Rogue":
                        hero = new Rogue(heroName);
                        break;

                    case "Warrior":
                        hero = new Warrior(heroName);
                        break;

                    default:
                        throw new ArgumentException("Invalid hero!");
                }

            return hero;
        }
    }
}