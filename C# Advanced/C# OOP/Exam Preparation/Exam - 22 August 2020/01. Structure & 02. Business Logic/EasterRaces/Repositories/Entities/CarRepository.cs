namespace EasterRaces.Repositories.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Cars.Contracts;

    public class CarRepository : IRepository<ICar>
    {
        private ICollection<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public ICar GetByName(string name) => 
            this.models.FirstOrDefault(c => c.Model == name);

        public IReadOnlyCollection<ICar> GetAll() => 
            (IReadOnlyCollection<ICar>)this.models;

        public void Add(ICar car)
        {
            this.models.Add(car);
        }

        public bool Remove(ICar driver) => 
            this.models.Remove(driver);
    }
}