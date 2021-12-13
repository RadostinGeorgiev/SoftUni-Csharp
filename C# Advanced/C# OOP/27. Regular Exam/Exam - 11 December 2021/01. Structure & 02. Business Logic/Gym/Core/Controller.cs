namespace Gym.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Athletes;
    using Models.Athletes.Contracts;
    using Models.Equipment;
    using Models.Equipment.Contracts;
    using Models.Gyms;
    using Models.Gyms.Contracts;
    using Repositories;
    using static Utilities.Messages.ExceptionMessages;
    using static Utilities.Messages.OutputMessages;

    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private ICollection<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = gymType switch
            {
                nameof(BoxingGym) => new BoxingGym(gymName),
                nameof(WeightliftingGym) => new WeightliftingGym(gymName),
                _ => throw new InvalidOperationException(InvalidGymType)
            };

            this.gyms.Add(gym);
            return string.Format(SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = equipmentType switch
            {
                nameof(BoxingGloves) => new BoxingGloves(),
                nameof(Kettlebell) => new Kettlebell(),
                _ => throw new InvalidOperationException(InvalidEquipmentType)
            };

            this.equipment.Add(equipment);
            return string.Format(SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
             IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            IEquipment equipment = this.equipment.FindByType(equipmentType);
            if (equipment == null)
            {
                throw new InvalidOperationException(string.Format(InexistentEquipment, equipmentType));
            }


            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);
            return string.Format(EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            IAthlete athlete;
            switch (athleteType)
            {
                case nameof(Boxer):
                    if (gym.GetType().Name == "BoxingGym")
                    {
                        athlete = new Boxer(athleteName, motivation, numberOfMedals);
                    }
                    else
                    {
                        return InappropriateGym;
                    }
                    break;
                case nameof(Weightlifter):
                    if (gym.GetType().Name == "WeightliftingGym")
                    {
                        athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                    }
                    else
                    {
                        return InappropriateGym;
                    }
                    break;
                default:
                    throw new InvalidOperationException(InvalidAthleteType);
            }

            gym.AddAthlete(athlete);
            return string.Format(EntityAddedToGym, athleteType, gymName);
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            gym.Exercise();
            return string.Format(AthleteExercise, gym.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            var weight = gym.Equipment.Sum(e => e.Weight);

            return string.Format(EquipmentTotalWeight, gymName, weight.ToString("F2"));
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in this.gyms)
            {
                 sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}