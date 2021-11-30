namespace Easter.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Eggs.Contracts;

    public class EggRepository : IRepository<IEgg>
    {
        private readonly ICollection<IEgg> _models;

        public EggRepository()
        {
            this._models = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => 
            (IReadOnlyCollection<IEgg>)this._models;

        public void Add(IEgg egg)
        {
            if (this._models.Contains(egg)) return;
            this._models.Add(egg);
        }

        public bool Remove(IEgg egg) => 
            this._models.Remove(egg);

        public IEgg FindByName(string name) => 
            this._models.FirstOrDefault(e => e.Name == name);
    }
}