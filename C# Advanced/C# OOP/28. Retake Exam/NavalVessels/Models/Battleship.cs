using System.Text;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double InitialArmorThickness = 300;
        private bool sonarMode = false;

        public Battleship(string name, double mainWeaponCaliber, double speed)
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


        public bool SonarMode => this.sonarMode;

        public void ToggleSonarMode()
        {
            this.sonarMode = !this.sonarMode;

            if (SonarMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string sonar = SonarMode ? "ON" : "OFF";

            sb.AppendLine(base.ToString())
                .AppendLine($" *Sonar mode: {sonar}");

            return sb.ToString().TrimEnd();
        }
    }
}