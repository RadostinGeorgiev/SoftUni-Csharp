namespace Easter.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Bunnies.Contracts;

    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly ICollection<IBunny> _models;

        public BunnyRepository()
        {
            this._models = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => 
            (IReadOnlyCollection<IBunny>)this._models;

        public void Add(IBunny bunny)
        {
            if (this._models.Contains(bunny)) return;

            this._models.Add(bunny);
        }

        public abstract bool Remove(IBunny bunny) => 
            this._models.Remove(bunny);

        public IBunny FindByName(string name) => 
            this._models.FirstOrDefault(b => b.Name == name);
    }
}