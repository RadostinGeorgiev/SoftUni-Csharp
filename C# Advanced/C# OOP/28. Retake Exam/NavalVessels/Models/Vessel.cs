using System;
using System.Collections.Generic;
using System.Text;
using NavalVessels.Models.Contracts;
using static NavalVessels.Utilities.Messages.ExceptionMessages;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private double armorThickness;
        private ICaptain captain;


        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            ArmorThickness = armorThickness;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(InvalidVesselName);
                }

                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get => this.captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(InvalidCaptainToVessel);
                }

                this.captain = value;
            }
        }


        public double ArmorThickness
        {
            get => this.armorThickness;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.armorThickness = value;
            }
        }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets { get; }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(InvalidTarget);
            }

            target.ArmorThickness -= MainWeaponCaliber;
            this.Targets.Add(target.Name);
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Armor thickness: {ArmorThickness}")
                .AppendLine($" *Main weapon caliber: {MainWeaponCaliber}")
                .AppendLine($" *Speed: {Speed} knots");

            sb.AppendLine(this.Targets.Count == 0 ? " *Targets: None" : $" *Targets: { string.Join(", ", this.Targets)}");

            return sb.ToString().TrimEnd();
        }
    }
}