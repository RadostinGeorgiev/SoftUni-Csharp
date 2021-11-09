using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IMission> Missions { get; }

        void AddMission(IMission mission);
    }
}