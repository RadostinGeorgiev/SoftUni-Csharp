using System;
using System.Linq;
using System.Text;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using static SpaceStation.Utilities.Messages.ExceptionMessages;
using static SpaceStation.Utilities.Messages.OutputMessages;

namespace SpaceStation.Core
{

    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astronautRepository;
        private readonly IRepository<IPlanet> planetRepository;
        private readonly IMission mission;

        private int exploredPlanetsCounter = 0;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            switch (type)
            {
                case "Biologist":
                    astronaut = new Biologist(astronautName);
                    break;
                case "Geodesist":
                    astronaut = new Geodesist(astronautName);
                    break;
                case "Meteorologist":
                    astronaut = new Meteorologist(astronautName);
                    break;
                default:
                    throw new InvalidOperationException(InvalidAstronautType);
            }

            this.astronautRepository.Add(astronaut);
            return string.Format(AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepository.Add(planet);
            return string.Format(PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronautRepository.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException
                    (string.Format(InvalidRetiredAstronaut, astronautName));
            }

            return this.astronautRepository.Remove(astronaut)
                ? string.Format(AstronautRetired, astronautName)
                : "";
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = planetRepository.FindByName(planetName);
            IAstronaut[] astronauts = astronautRepository
                .Models
                .Where(a => a.Oxygen > 60)
                .ToArray();

            if (astronauts.Length == 0)
            {
                throw new InvalidOperationException
                    (InvalidAstronautCount);
            }

            mission.Explore(planet, astronauts);
            exploredPlanetsCounter++;

            IAstronaut[] deadAstronauts = astronautRepository
                .Models
                .Where(a => !a.CanBreath)
                .ToArray();
            return string.Format(PlanetExplored, planet.Name, deadAstronauts.Length);

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanetsCounter} planets were explored!");

            sb.AppendLine("Astronauts info:");
            foreach (IAstronaut astronaut in astronautRepository.Models)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}