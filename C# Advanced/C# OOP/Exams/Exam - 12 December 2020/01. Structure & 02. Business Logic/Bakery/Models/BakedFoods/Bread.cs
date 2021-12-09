namespace Bakery.Models.BakedFoods
{
    public class Bread : BakedFood
    {
        private const int InitialPortion = 200;
        
        public Bread(string name, decimal price)
            : base(name, InitialPortion, price)
        {
        }
    }
}