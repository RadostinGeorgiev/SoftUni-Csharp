namespace Restaurant
{
    public class Fish : MainDish
    {
        public const double FishGrams = 250;

        public Fish(string name, decimal price) 
            : base(name, price, FishGrams)
        {
        }
    }
}
