using System.Text;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmorThickness = 200;
        private bool submergeMode = false;

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name,
                mainWeaponCaliber,
                speed,
                InitialArmorThickness)
        {
        }

        public override void RepairVessel()
        {
            ArmorThickness = InitialArmorThickness;
        }


        public bool SubmergeMode
        {
            get => this.submergeMode;
        }

        public void ToggleSubmergeMode()
        {
            this.submergeMode = !this.submergeMode;

            if (SubmergeMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string submerge = SubmergeMode ? "ON" : "OFF";

            sb.AppendLine(base.ToString())
                .AppendLine($" *Submerge mode: {submerge}");

            return sb.ToString().TrimEnd();
        }
    }
}