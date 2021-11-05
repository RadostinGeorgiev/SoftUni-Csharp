using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> data;

        public Restaurant(string name)
        {
            Name = name;
            data = new List<Salad>();
        }

        public string Name { get; set; }

        public void Add(Salad salad)
        {
            data.Add(salad);
        }

        public bool Buy(string name) => data.RemoveAll(x => x.Name == name) > 0;


        public Salad GetHealthiestSalad()
        {
            int minCalories = 0;
            Salad bestSalad = null;

            foreach (var salad in data)
            {
                int currentCalories = salad.GetTotalCalories();
                if (currentCalories < minCalories)
                {
                    minCalories = currentCalories;
                    bestSalad = salad;
                }
            }

            return bestSalad;
        }

        public string GenerateMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} have {data.Count} salads:");
            foreach (var salad in data)
            {
                sb.AppendLine(salad.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}