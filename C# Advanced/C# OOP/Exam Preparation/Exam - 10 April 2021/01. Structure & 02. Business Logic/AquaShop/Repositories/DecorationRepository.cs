namespace AquaShop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Decorations.Contracts;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly ICollection<IDecoration> _decorations;

        public DecorationRepository()
        {
            this._decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models =>
            this._decorations as IReadOnlyCollection<IDecoration>;

        public void Add(IDecoration decoration) =>
            this._decorations.Add(decoration);

        public bool Remove(IDecoration decoration) => 
            this._decorations.Remove(decoration);

        public IDecoration FindByType(string type) => 
            this._decorations.FirstOrDefault(d => d.GetType().Name == type);
    }
}