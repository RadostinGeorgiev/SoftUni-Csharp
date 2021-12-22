namespace CarRacing.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Cars.Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public class CarRepository : IRepository<ICar>
    {
        private ICollection<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => 
            (IReadOnlyCollection<ICar>)this.models;

        public void Add(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException(InvalidAddCarRepository);
            }

            this.models.Add(car);
        }

        public bool Remove(ICar car) => 
            this.models.Remove(car);

        public ICar FindBy(string property) => 
            this.models.FirstOrDefault(c => c.VIN == property);
    }
}