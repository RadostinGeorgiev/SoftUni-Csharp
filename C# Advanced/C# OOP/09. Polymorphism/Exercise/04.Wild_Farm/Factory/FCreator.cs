using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Factory
{
    public abstract class FCreator
    {
        public abstract IFood FoodFactory(string[] foodArgs);
    }
}