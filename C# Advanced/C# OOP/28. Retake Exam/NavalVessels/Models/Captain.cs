using System;
using System.Collections.Generic;
using System.Text;
using NavalVessels.Models.Contracts;
using static NavalVessels.Utilities.Messages.ExceptionMessages;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience = 0;

        public Captain(string fullName)
        {
            FullName = fullName;
            Vessels = new List<IVessel>();
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(InvalidCaptainName);
                }

                this.fullName = value;
            }
        }


        public int CombatExperience
        {
            get => this.combatExperience;
        }

        public ICollection<IVessel> Vessels { get; }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(InvalidVesselForCaptain);
            }

            Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.combatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");
            if (Vessels.Count > 0)
            {
                foreach (var vessel in Vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}