namespace Easter.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Bunnies;
    using Models.Bunnies.Contracts;
    using Models.Dyes;
    using Models.Dyes.Contracts;
    using Models.Eggs;
    using Models.Eggs.Contracts;
    using Models.Workshops;
    using Repositories;
    using static Utilities.Messages.ExceptionMessages;
    using static Utilities.Messages.OutputMessages;


    public class Controller : IController
    {
        private BunnyRepository _bunnies;
        private EggRepository _eggs;

        public Controller()
        {
            this._bunnies = new BunnyRepository();
            this._eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = bunnyType switch
            {
                "HappyBunny" => new HappyBunny(bunnyName),
                "SleepyBunny" => new SleepyBunny(bunnyName),
                _ => throw new InvalidOperationException(InvalidBunnyType)
            };

            this._bunnies.Add(bunny);

            return string.Format(BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);
            IBunny bunny = this._bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(InexistentBunny);
            }

            bunny.AddDye(dye);

            return string.Format(DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            this._eggs.Add(egg);

            return string.Format(EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = this._eggs.FindByName(eggName);
            var workshop = new Workshop();

            List<IBunny> suitableBunnies = this._bunnies.Models
                .Where(b => b.Energy >= 50)
                .OrderByDescending(b => b.Energy)
                .ToList();

            if (suitableBunnies.Count == 0)
            {
                throw new InvalidOperationException(BunniesNotReady);
            }

            while (!egg.IsDone() && suitableBunnies.Count > 0)
            {
                IBunny bunny = suitableBunnies.First();
                workshop.Color(egg, bunny);

                if (bunny.Dyes.Count == 0)
                {
                    suitableBunnies.Remove(bunny);
                }

                if (bunny.Energy == 0)
                {
                    suitableBunnies.Remove(bunny);
                    this._bunnies.Remove(bunny);
                }
            }

            return string.Format(egg.IsDone() ? EggIsDone : EggIsNotDone, eggName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this._eggs.Models.Count(e => e.IsDone())} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (var bunny in this._bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}")
                  .AppendLine($"Energy: {bunny.Energy}")
                  .AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
            }

            return sb.ToString().Trim();
        }
    }
}