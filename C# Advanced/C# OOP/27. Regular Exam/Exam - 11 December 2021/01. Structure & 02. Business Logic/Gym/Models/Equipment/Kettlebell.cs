namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double Weight = 10000;
        private const decimal Price = 80m;

        public Kettlebell()
            : base(Weight, Price)
        {
        }
    }
}