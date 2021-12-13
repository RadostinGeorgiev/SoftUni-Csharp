namespace EasterRaces.Repositories.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Races.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private ICollection<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public IRace GetByName(string name) =>
            this.models.FirstOrDefault(r => r.Name == name);

        public IReadOnlyCollection<IRace> GetAll() =>
            (IReadOnlyCollection<IRace>)this.models;

        public void Add(IRace race)
        {
            this.models.Add(race);
        }

        public bool Remove(IRace race) => 
            this.models.Remove(race);
    }
}