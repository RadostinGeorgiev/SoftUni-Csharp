using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (IAstronaut astronaut in astronauts)
            {
                if (!astronaut.CanBreath) continue;

                if (planet.Items.Count == 0) continue;

                while (planet.Items.Count > 0)
                {
                    var item = planet.Items.First();

                    astronaut.Breath();
                    planet.Items.Remove(item);
                    astronaut.Bag.Items.Add(item);

                    if (!astronaut.CanBreath)
                    {
                        break;
                    }
                }
            }
        }
    }
}