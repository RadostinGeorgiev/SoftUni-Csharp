using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> _models;

        public PlanetRepository()
        {
            _models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => 
            _models as IReadOnlyCollection<IPlanet>;

        public void Add(IPlanet planet)
        {
            if (_models.Contains(planet)) return;
            _models.Add(planet);
        }

        public bool Remove(IPlanet planet) => 
            _models.Remove(planet);

        public IPlanet FindByName(string name) => 
            _models.FirstOrDefault(p => p.Name == name);
    }
}