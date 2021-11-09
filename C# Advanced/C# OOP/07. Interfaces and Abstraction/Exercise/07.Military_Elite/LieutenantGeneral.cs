using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
       private ICollection<ISoldier> privates;

       public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates => (IReadOnlyCollection<ISoldier>)privates;

        public void AddPrivate(ISoldier @private)
        {
            privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine("Privates:");
            foreach (var @private in Privates)
            {
                sb.AppendLine($"  {@private.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}