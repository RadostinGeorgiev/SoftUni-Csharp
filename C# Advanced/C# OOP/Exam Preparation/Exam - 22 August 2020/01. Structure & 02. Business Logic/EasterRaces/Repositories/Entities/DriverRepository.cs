namespace EasterRaces.Repositories.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Drivers.Contracts;

    public class DriverRepository : IRepository<IDriver>
    {
        private ICollection<IDriver> models;

        public DriverRepository()
        {
            this.models = new List<IDriver>();
        }

        public IDriver GetByName(string name) =>
            this.models.FirstOrDefault(d => d.Name == name);

        public IReadOnlyCollection<IDriver> GetAll() =>
            (IReadOnlyCollection<IDriver>)this.models;

        public void Add(IDriver driver)
        {
            this.models.Add(driver);
        }

        public bool Remove(IDriver driver) => 
            this.models.Remove(driver);
    }
}