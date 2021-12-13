namespace Gym.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Equipment.Contracts;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private ICollection<IEquipment> models;

        public EquipmentRepository()
        {
            this.models = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models =>
            (IReadOnlyCollection<IEquipment>)this.models;

        public void Add(IEquipment equipment)
        {
            this.models.Add(equipment);
        }

        public bool Remove(IEquipment equipment) => 
            this.models.Remove(equipment);

        public IEquipment FindByType(string type) => 
            this.models.FirstOrDefault(e => e.GetType().Name == type);
    }
}