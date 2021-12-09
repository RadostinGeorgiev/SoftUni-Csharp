namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int INITIAL_ENERGY = 50;

        public SleepyBunny(string name)
            : base(name, INITIAL_ENERGY)
        {
        }

        public override void Work()
        {
            Energy -= 5;
            base.Work();
        }
    }
}