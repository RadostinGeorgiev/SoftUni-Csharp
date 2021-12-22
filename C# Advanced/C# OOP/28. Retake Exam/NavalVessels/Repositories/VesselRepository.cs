using System.Collections.Generic;
using System.Linq;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private ICollection<IVessel> models;

        public VesselRepository()
        {
            this.models = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models =>
            (IReadOnlyCollection<IVessel>)this.models;

        public void Add(IVessel vessel) => 
            this.models.Add(vessel);

        public bool Remove(IVessel vessel) => 
            this.models.Remove(vessel);

        public IVessel FindByName(string name) => 
            this.models.FirstOrDefault(v => v.Name == name);
    }
}