using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            _data = new Dictionary<string, Racer>();
        }

        private Dictionary<string, Racer> _data;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => _data.Count;

        public void Add(Racer racer)
        {
            if (Count < Capacity && !_data.ContainsKey(racer.Name))
            {
                _data.Add(racer.Name, racer);
            }
        }

        public bool Remove(string name)
        {
            if (!_data.ContainsKey(name)) return false;
            _data.Remove(name);
            return true;
        }

        public Racer GetOldestRacer()
        {
            return _data.OrderByDescending(x => x.Value.Age).FirstOrDefault().Value;
        }

        public Racer GetRacer(string name)
        {
            return _data[name];
        }

        public Racer GetFastestRacer()
        {
            return _data.OrderByDescending(x => x.Value.Car.Speed).FirstOrDefault().Value;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {Name}:");
            foreach (var kVP in _data)
            {
                sb.AppendLine(kVP.Value.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}