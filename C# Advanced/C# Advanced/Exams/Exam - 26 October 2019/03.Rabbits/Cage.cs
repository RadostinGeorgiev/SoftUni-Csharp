using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.data = new List<Rabbit>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Rabbit rabbit)
        {
            if (Capacity > Count)
            {
                data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            return data.RemoveAll(x => x.Name == name) > 0;
        }

        public void RemoveSpecies(string species)
        {
            data.RemoveAll(x => x.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            data.First(x => x.Name == name).Available = false;
            return data.First(x => x.Name == name);
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            foreach (var rabbit in data.Where(rabbit => rabbit.Species == species))
            {
                rabbit.Available = false;
            }

            return data.Where(x => x.Species == species).ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {Name}:");
            foreach (var rabbit in data.Where(x=>x.Available == true))
            {
                sb.AppendLine(rabbit.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}