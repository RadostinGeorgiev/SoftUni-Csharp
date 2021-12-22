namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double DefaultWeight = 10000;
        private const decimal DefaultPrice = 80m;

        public Kettlebell()
            : base(DefaultWeight, DefaultPrice)
        {
        }
    }
}