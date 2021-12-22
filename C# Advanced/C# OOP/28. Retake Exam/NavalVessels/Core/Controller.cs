using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using System.Collections.Generic;
using System.Linq;
using static NavalVessels.Utilities.Messages.OutputMessages;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private ICollection<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);

            if (this.captains.FirstOrDefault(c => c.FullName == fullName) != null)
            {
                return string.Format(CaptainIsAlreadyHired, fullName);
            }

            this.captains.Add(captain);

            return string.Format(SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (this.vessels.Models.FirstOrDefault(v => v.Name == name) != null)
            {
                return string.Format(VesselIsAlreadyManufactured, vesselType, name);
            }

            IVessel vessel;
            switch (vesselType)
            {
                case nameof(Battleship):
                    vessel = new Battleship(name, mainWeaponCaliber, speed);
                    break;
                case nameof(Submarine):
                    vessel = new Submarine(name, mainWeaponCaliber, speed);
                    break;
                default:
                    return InvalidVesselType;
            }

            this.vessels.Add(vessel);

            return string.Format(SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = this.captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            if (captain == null)
            {
                return string.Format(CaptainNotFound, selectedCaptainName);
            }

            IVessel vessel = this.vessels.FindByName(selectedVesselName);
            if (vessel == null)
            {
                return string.Format(VesselNotFound, selectedVesselName);
            }

            if (vessel.Captain != null)
            {
                return string.Format(VesselOccupied, selectedVesselName);
            }

            captain.Vessels.Add(vessel);
            vessel.Captain = captain;

            return string.Format(SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = this.captains.FirstOrDefault(c => c.FullName == captainFullName);

            return captain.Report();
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            return vessel.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(VesselNotFound, vesselName);
            }

            switch (vessel.GetType().Name)
            {
                case "Battleship":
                    var battleship = vessel as Battleship;
                    battleship.ToggleSonarMode();

                    return string.Format(ToggleBattleshipSonarMode, vesselName);

                case "Submarine":
                    var submarine = vessel as Submarine;
                    submarine.ToggleSubmergeMode();

                    return string.Format(ToggleSubmarineSubmergeMode, vesselName);

                default:
                    return string.Format(VesselNotFound, vesselName);
            }
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackingVessel = this.vessels.FindByName(attackingVesselName);
            if (attackingVessel == null)
            {
                return string.Format(VesselNotFound, attackingVesselName);
            }

            if (attackingVessel.ArmorThickness == 0)
            {
                return string.Format(AttackVesselArmorThicknessZero, attackingVesselName);
            }

            IVessel defendingVessel = this.vessels.FindByName(defendingVesselName);
            if (defendingVessel == null)
            {
                return string.Format(VesselNotFound, defendingVesselName);
            }

            if (defendingVessel.ArmorThickness == 0)
            {
                return string.Format(AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attackingVessel.Attack(defendingVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();

            return string.Format(SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(VesselNotFound, vesselName);
            }

            vessel.RepairVessel();

            return string.Format(SuccessfullyRepairVessel, vesselName);
        }
    }
}