using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;
        public Commando(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>)missions;

        public void AddMission(IMission mission)
        {
            missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine("Missions:");
            foreach (var mission in Missions)
            {
                sb.AppendLine($"  {mission}");
            }

            return sb.ToString().Trim();
        }
    }
}