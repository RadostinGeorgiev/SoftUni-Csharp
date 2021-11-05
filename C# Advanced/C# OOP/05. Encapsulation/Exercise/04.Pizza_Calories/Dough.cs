using System;
using System.Collections.Generic;

namespace _04.Pizza_Calories
{
    public class Dough
    {
        private const string InvalidTypeMessage = "Invalid type of dough.";
        private const string InvalidWeightMessage = "Dough weight should be in the range [1..200].";

        private const int CaloriesBase = 2;
        private const double WhiteModifier = 1.5;
        private const double WholegrainModifier = 1.0;
        private const double CrispyModifier = 0.9;
        private const double ChewyModifier = 1.1;
        private const double HomemadeModifier = 1.0;

        private HashSet<string> DoughType = new HashSet<string>()
        {
            "white",
            "wholegrain"
        };

        private HashSet<string> BakingTechnique = new HashSet<string>()
        {
            "crispy",
            "chewy",
            "homemade"
        };
        private string typeOfDough;
        private string techniqueOfBaking;
        private int weight;

        public Dough(string typeOfDough, string techniqueOfBaking, int weight)
        {
            TypeOfDough = typeOfDough;
            TechniqueOfBaking = techniqueOfBaking;
            Weight = weight;
        }

        public string TypeOfDough
        {
            get => typeOfDough;

            set
            {
                if (!DoughType.Contains(value.ToLower()))
                {
                    throw new ArgumentException(InvalidTypeMessage);
                }

                typeOfDough = value;
            }
        }

        public string TechniqueOfBaking
        {
            get => techniqueOfBaking;

            set
            {
                if (!BakingTechnique.Contains(value.ToLower()))
                {
                    throw new ArgumentException(InvalidTypeMessage);
                }

                techniqueOfBaking = value;
            }
        }

        public int Weight
        {
            get => weight;

            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(InvalidWeightMessage);
                }

                weight = value;
            }
        }

        public double Calories => this.GetCalories();

        private double GetCalories()
        {
            double calories = CaloriesBase;

            switch (this.typeOfDough.ToLower())
            {
                case "white":
                    calories *= WhiteModifier;
                    break;
                case "wholegrain":
                    calories *= WholegrainModifier;
                    break;
            }

            switch (this.techniqueOfBaking.ToLower())
            {
                case "crispy":
                    calories *= CrispyModifier;
                    break;
                case "chewy":
                    calories *= ChewyModifier;
                    break;
                case "homemade":
                    calories *= HomemadeModifier;
                    break;
            }

            return calories * this.weight;
        }
    }
}