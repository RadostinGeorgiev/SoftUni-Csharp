namespace CarRacing.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Racers.Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public class RacerRepository : IRepository<IRacer>
    {
        private ICollection<IRacer> models;

        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => 
            (IReadOnlyCollection<IRacer>)this.models;

        public void Add(IRacer racer)
        {
            if (racer == null)
            {
                throw new ArgumentException(InvalidAddRacerRepository);
            }

            this.models.Add(racer);
        }

        public bool Remove(IRacer racer) => 
            this.models.Remove(racer);

        public IRacer FindBy(string property) => 
            this.models.FirstOrDefault(r => r.Username == property);
    }
}