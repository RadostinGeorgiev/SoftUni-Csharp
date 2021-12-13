namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double Weight = 227;
        private const decimal Price = 120m;

        public BoxingGloves()
            : base(Weight, Price)
        {
        }
    }
}