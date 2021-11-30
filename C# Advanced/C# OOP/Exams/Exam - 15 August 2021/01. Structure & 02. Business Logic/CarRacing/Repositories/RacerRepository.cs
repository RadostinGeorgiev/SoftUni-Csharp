namespace CarRacing.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Racers.Contracts;
    using Utilities.Messages;

    public class RacerRepository : IRepository<IRacer>
    {
        private ICollection<IRacer> _models;

        public RacerRepository()
        {
            this._models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => (IReadOnlyCollection<IRacer>)this._models;

        public void Add(IRacer racer)
        {
            if (racer == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            this._models.Add(racer);
        }

        public bool Remove(IRacer racer) => this._models.Remove(racer);

        public IRacer FindBy(string property) => 
            this._models.FirstOrDefault(r => r.Username == property);
    }
}