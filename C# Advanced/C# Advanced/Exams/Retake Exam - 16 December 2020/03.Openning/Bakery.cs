using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {

        private Dictionary<string, Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.data = new Dictionary<string, Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Employee employee)
        {
            if (Capacity > Count && !data.ContainsKey(employee.Name))
            {
                data.Add(employee.Name, employee);
            }
        }

        public bool Remove(string name)
        {
            if (!data.ContainsKey(name)) return false;
            data.Remove(name);
            return true;
        }

        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(x => x.Value.Age).First().Value;
        }

        public Employee GetEmployee(string name)
        {
            return data[name];
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var employee in data)
            {
                sb.AppendLine(employee.Value.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}