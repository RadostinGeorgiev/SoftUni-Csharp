using System;
using System.Text;
using MilitaryElite.Enumerators;
using MilitaryElite.Exeptions;
using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            Corps = TryParseCorps(corps);
        }

        public Corps Corps { get; set; }

        private Corps TryParseCorps(string corpsString)
        {
            bool parsed = Enum.TryParse<Corps>(corpsString, out Corps corps);

            if (parsed) return corps;
            throw new InvalidCorpsException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine($"Corps: {Corps.ToString()}");

            return sb.ToString().Trim();
        }
    }
}