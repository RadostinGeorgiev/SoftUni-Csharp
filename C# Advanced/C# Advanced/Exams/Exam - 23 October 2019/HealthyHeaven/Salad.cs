using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        private List<Vegetable> products;

        public Salad(string name)
        {
            Name = name;
            products = new List<Vegetable>();
        }

        public string Name { get; set; }

        public void Add(Vegetable product)
        {
            products.Add(product);
        }

        public int GetTotalCalories() => products.Sum(x => x.Calories);
        public int GetProductCount() => products.Count;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"* Salad {Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:");
            foreach (var vegetable in products)
            {
                sb.AppendLine(vegetable.ToString());
            }

            return sb.ToString().Trim();
        }
    }

}