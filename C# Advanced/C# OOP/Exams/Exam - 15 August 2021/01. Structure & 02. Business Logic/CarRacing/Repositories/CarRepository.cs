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
        private ICollection<ICar> _models;

        public CarRepository()
        {
            this._models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => 
            (IReadOnlyCollection<ICar>)this._models;

        public void Add(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException(InvalidAddCarRepository);
            }

            this._models.Add(car);
        }

        public bool Remove(ICar car) => this._models.Remove(car);

        public ICar FindBy(string property) => 
            this._models.FirstOrDefault(c => c.VIN == property);
    }
}