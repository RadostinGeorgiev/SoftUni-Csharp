using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly ICollection<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => 
            this.models as IReadOnlyCollection<IAstronaut>;

        public void Add(IAstronaut astronaut)
        {
            if (this.models.Contains(astronaut)) return;
            models.Add(astronaut);
        }

        public bool Remove(IAstronaut astronaut) =>
            this.models.Remove(astronaut);

        public IAstronaut FindByName(string name) =>
            this.models.FirstOrDefault(a => a.Name == name);
    }
}