using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new Dictionary<string, Ingredient>();
        }

        private Dictionary<string, Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => Ingredients.Sum(x => x.Value.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.ContainsKey(ingredient.Name) &&
                Ingredients.Count < Capacity &&
                ingredient.Alcohol <= MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient.Name, ingredient);
            }
        }

        public bool Remove(string name)
        {
            if (!Ingredients.ContainsKey(name)) return false;
            Ingredients.Remove(name);
            return true;
        }

        public Ingredient FindIngredient(string name) =>
            Ingredients.FirstOrDefault(x => x.Value.Name == name).Value;

        public Ingredient GetMostAlcoholicIngredient() =>
            Ingredients.OrderByDescending(x => x.Value.Alcohol).FirstOrDefault().Value;


        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var kVP in Ingredients)
            {
                sb.AppendLine(kVP.Value.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}