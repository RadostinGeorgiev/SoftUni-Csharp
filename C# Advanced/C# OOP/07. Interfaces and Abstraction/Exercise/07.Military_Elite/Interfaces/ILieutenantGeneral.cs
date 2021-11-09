using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<ISoldier> Privates { get; }

        void AddPrivate(ISoldier @private);
    }
}