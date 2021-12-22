namespace Gym.Models.Gyms
{
    public class WeightliftingGym : Gym
    {
        private const int DefaultCapacity = 20;

        public WeightliftingGym(string name)
            : base(name, DefaultCapacity)
        {
        }
    }
}