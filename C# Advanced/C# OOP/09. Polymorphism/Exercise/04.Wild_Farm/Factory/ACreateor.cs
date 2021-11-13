using WildFarm.Models.Animals.Interfaces;

namespace WildFarm.Factory
{
    public abstract class ACreateor
    {
        public abstract IAnimal AnimalFactory(string[] animalArgs);
    }
}