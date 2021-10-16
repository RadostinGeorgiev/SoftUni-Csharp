using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Capacity = capacity;
            Laps = laps;
            MaxHorsePower = maxHorsePower;
            Name = name;
            Type = type;
        }

        public Dictionary<string, Car> Participants { get; set; } = new Dictionary<string, Car>();
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public int Count => Participants.Count;

        public void Add(Car car)
        {
            if (Participants.Count < Capacity &&
                !Participants.ContainsKey(car.LicensePlate) &&
                car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car.LicensePlate, car);
            }
        }

        public bool Remove(string licensePlate)
        {
            return Participants.ContainsKey(licensePlate) && Participants.Remove(licensePlate);
        }

        public Car FindParticipant(string licensePlate)
        {
            return Participants.ContainsKey(licensePlate) ? Participants[licensePlate] : null;
        }

        public Car GetMostPowerfulCar()
        {
            return Participants.Count > 0 ?
                Participants.OrderByDescending(x => x.Value.HorsePower).FirstOrDefault().Value 
                : null;
                //Participants.First(x => x.Value.HorsePower == 
                //                        Participants.Max(x => x.Value.HorsePower)).Value
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var kVP in Participants)
            {
                sb.AppendLine(kVP.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}